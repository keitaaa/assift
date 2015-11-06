using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Shiftwork.Library;

namespace Shiftwork.Payload
{
    public static class JobToShift
    {
        public static void Run(Excel.Workbook book)
        {
            book.Application.ScreenUpdating = true;
            MainForm._MainFormInstance.inProrgamUse = true;

            int Rows = 0, Columns = 0;   //Rowがy座標
            Excel.Worksheet jobsheet;// 操作中のアプリケーション
            Excel.Worksheet idvsheet;
            Excel.Sheets sheets;
            sheets = book.Worksheets;
            jobsheet = (Excel.Worksheet)sheets.get_Item(sheets.getSheetIndex("仕事シフト"));
            idvsheet = (Excel.Worksheet)sheets.get_Item(sheets.getSheetIndex("個人シフト"));
            Excel.Range current = idvsheet.Cells[1, 1];　　　//セル単体です
            string value;
            int cellCount = 1;
            Excel.Range wholeRange;

            Excel.Range allJobRange = jobsheet.Cells[24, 3];
            allJobRange = allJobRange.get_Resize(MainForm._MainFormInstance.jobtype + 10, 90 + 10);
            Excel.Range allIdvRange = idvsheet.Cells[1, 1];
            allIdvRange = allIdvRange.get_Resize(MainForm._MainFormInstance.jobtype + 10, 90 + 10);
            allIdvRange.Interior.ColorIndex = 2;
            //allIdvRange.ClearContents();
            //allIdvRange.UnMerge();

            string[,] allString = allJobRange.DeepToString();　//仕事シフトを入れる
            string[,] allIdvString = allIdvRange.DeepToString(); //個人シフトを入れる

            Excel.Range JobRange = jobsheet.Cells[24, 2];
            JobRange = JobRange.get_Resize(MainForm._MainFormInstance.jobtype + 10, 1);
            string[,] jobString = JobRange.DeepToString();  //仕事名を入れる


            for (Rows = 0; Rows < 500; Rows++)
            {
                for (Columns = 0; Columns < 100; Columns++)
                {
                    if (allString[Rows, Columns] == null || allString[Rows, Columns] == "")
                        continue;
                    else
                    {
                        for(int tmp=0; tmp <500; tmp++)
                        {

                            if(allIdvString[tmp,3]==null || allIdvString[tmp, 3] == "")
                            { }
                            else if (allString[Rows,Columns] == allIdvString[tmp,3] )
                            { 
                                allIdvString[tmp,Columns+4] = jobString[Rows, 0];
                                break;
                            }
                        }
                    }
                }
            }

            allIdvRange.set_Value(Type.Missing, allIdvString);

            book.Application.DisplayAlerts = false;
            for (Rows=1; Rows < 500; Rows++)
            {
                for(Columns=1; Columns<100; Columns++)
                {
                    cellCount = 1;
                    value = allIdvString[Rows - 1, Columns - 1];
                    if (value == null || value == "")
                        continue;
                    while (value == allIdvString[Rows - 1, Columns])
                    {
                        cellCount++;
                        Columns++;
                    }


                    wholeRange = idvsheet.Cells[Rows, Columns - cellCount + 1];
                    wholeRange = wholeRange.get_Resize(1,cellCount);
                    wholeRange.Merge();
                    wholeRange.Interior.ColorIndex = 35;
                    wholeRange.BorderAround2();
                }
            }




            book.Application.DisplayAlerts = true;
            book.Application.ScreenUpdating = true;
            MainForm._MainFormInstance.inProrgamUse = false;

        }
    }
}
