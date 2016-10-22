using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Shiftwork.Library;
using System.Diagnostics;

namespace Shiftwork.Payload
{
    public static class AllPasteFormula
    {
        

        /// <summary>
        /// すべてを数式として貼り付け
        /// 例外処理しといた方が安心？
        /// </summary>
        public static void Run(Excel.Workbook book)
        {
            book.Application.ScreenUpdating = false;
            MainForm._MainFormInstance.inProrgamUse = true;
            int Rows = MainForm._MainFormInstance.startaddr_row, Columns = 3;   //Rowがy座標
       　   Excel.Worksheet jobsheet;            // 操作中のアプリケーション
            Excel.Sheets sheets;
            sheets = book.Worksheets;
            jobsheet = (Excel.Worksheet)sheets.get_Item(sheets.getSheetIndex("仕事シフト"));
            Excel.Range current = jobsheet.Cells[Rows, Columns];　　　//セル単体です
            Excel.Range next = jobsheet.Cells[Rows,Columns+1];
            Excel.Range wholeRange = null;      //結合されたセル全体です
            string value = "";
            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (Rows = MainForm._MainFormInstance.startaddr_row; Rows < MainForm._MainFormInstance.jobtype; Rows++)
            {
                if(MainForm._MainFormInstance.APFCheckBoxValue)
                {
                    if (Rows % 100 == 0)
                    {
                        sw.Stop();
                        book.Application.ScreenUpdating = true;
                        MessageBox.Show(Rows / 100 + "00行目まで終わりました\r\nここまでの合計処理時間は"+sw.ElapsedMilliseconds+"ミリ秒です");
                        book.Application.ScreenUpdating = false;
                        sw.Start();
                    }
                }
                for (Columns = 3 ; Columns < 93; Columns++)
                {
                    current = jobsheet.Cells[Rows, Columns];

                    //if (current.MergeCells)    //セルの結合判定
                    {

                        next = jobsheet.Cells[Rows, Columns + 1];
                        if (current.get_Value() == null || current.get_Value().ToString() == "")
                        {
                            Columns = Columns + current.MergeArea.Columns.Count;
                            Columns--;
                        }
                        else 
                        {
                            if (next.get_Value() == current.get_Value())
                            {
                                Columns += current.MergeArea.Columns.Count;
                                Columns--;
                            }
                            else
                            {
                                value = current.get_Value().ToString();
                                wholeRange = current.MergeArea;

                                //数式として貼り付け
                                Excel.Range src = current.Worksheet.Cells[MainForm._MainFormInstance.jobtype + 100, 1];
                                src.Value = value;//値を数式としてsrcに
                                src.Copy();//クリップボードにコピー
                                wholeRange.PasteSpecial(Excel.XlPasteType.xlPasteFormulas);

                                System.Threading.Thread t = new System.Threading.Thread(clearClipboard);
                                t.SetApartmentState(System.Threading.ApartmentState.STA);
                                t.Start();
                                t.Join();


                                Columns += wholeRange.Columns.Count;
                                Columns--;
                                //Columns += cellCount;
                            }
                        }
                    }
                }

            }
            sw.Stop();
            MainForm._MainFormInstance.inProrgamUse = false;
            book.Application.ScreenUpdating = true;
            MessageBox.Show("終わったよ！\r\n合計処理時間は"+sw.ElapsedMilliseconds+"ミリ秒です");
        }
        public static void clearClipboard()
        {
            Clipboard.SetDataObject(new DataObject());
        }
    }
}
