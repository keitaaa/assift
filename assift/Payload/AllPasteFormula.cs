using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Shiftwork.Library;
namespace Shiftwork.Payload
{
    public static class AllPasteFormula
    {
        /// <summary>
        /// すべてを数式として貼り付け
        /// 例外処理しといた方が安心？
        /// </summary>
        public static void Run(Excel.Application app)
        {
            app.ScreenUpdating = false;
            //MainForm._MainFormInstance.inProrgamUse = true;

            int Rows = 24, Columns = 3;   //Rowがy座標
       　   Excel.Worksheet jobsheet;            // 操作中のアプリケーション
            Excel.Workbook book;             // 操作中のワークブック(Workbook -> Sheets)
            Excel.Sheets sheets;
            book = app.ActiveWorkbook;
            sheets = book.Worksheets;
            jobsheet = (Excel.Worksheet)sheets.get_Item(sheets.getSheetIndex("仕事シフト"));
            Excel.Range current = jobsheet.Cells[Rows, Columns];　　　//セル単体です
            Excel.Range wholeRange = null;      //結合されたセル全体です
            string value = "";
            int cellCount = 0;
            for (Rows = 24; Rows < 500; Rows++) {
                for (Columns = 3 ; Columns < 100; Columns++)
                {
                    if (current.MergeCells)    //セルの結合判定
                    {
                        if (current.get_Value() == null) { }

                        else
                        {
                            value = current.get_Value().ToString();
                            wholeRange = current.MergeArea;

                            //数式として貼り付け
                            Excel.Range src = current.Worksheet.Cells[500 + 100, 1];
                            src.Formula = value;//値を数式としてsrcに
                            src.Copy();//クリップボードにコピー
                            wholeRange.PasteSpecial(Excel.XlPasteType.xlPasteFormulas);

                            // クリップボードのクリア
                            System.Threading.Thread t = new System.Threading.Thread(clearClipboard);
                            t.SetApartmentState(System.Threading.ApartmentState.STA);
                            t.Start();
                            t.Join();

                            //MainForm._MainFormInstance.inProrgamUse = false;

                            cellCount = wholeRange.Count;
                            Columns += cellCount;
                        }
                    }
                }

            }
            app.ScreenUpdating = true;
            //終了したときにメッセージボックスとか出してみたいけどやり方わかりません
        }
        public static void clearClipboard()
        {
            Clipboard.SetDataObject(new DataObject());
        }
    }
}
