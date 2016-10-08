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
    class AllCheck
    {
        public static void Run(Excel.Workbook book)
        {
            book.Application.ScreenUpdating = true;
            MainForm._MainFormInstance.inProrgamUse = true;

            int Rows = 0, Columns = 0;   //Rowがy座標
            Excel.Worksheet jobsheet;            // 操作中のアプリケーション
            Excel.Sheets sheets;
            sheets = book.Worksheets;
            jobsheet = (Excel.Worksheet)sheets.get_Item(sheets.getSheetIndex("仕事シフト"));
            //Excel.Range current = jobsheet.Cells[Rows, Columns];　　　//セル単体です
            Excel.Range allRange = jobsheet.Cells[24, 3];
            allRange = allRange.get_Resize(MainForm._MainFormInstance.jobtype + 10 , 90);
            string[,] allString = allRange.DeepToString();
            string message = "";
            bool isChecked=false;
            bool odd = true;
            string first = "",second="",third="";

            for (Columns = 1; Columns < 90; Columns++)
            {
                for (Rows = 1; Rows < MainForm._MainFormInstance.jobtype; Rows++) {                                      
                    //if (jobsheet.Cells[Rows, Columns].MergeCells)
                    //{
                    //    MessageBox.Show("check");
                    //    //Excel.Range tmp = jobsheet.Cells[Rows,Columns].MergeArea;
                    //    //if (tmp.Cells[1,2] == null && tmp.Cells[1, 2] == "")
                    //    //    MessageBox.Show("このシートには誤りがあります．\r\n　数式として貼り付けボタンを行ってください．\r\n");
                    //}
                    if (allString[Rows, Columns] == null || allString[Rows, Columns] == "")
                        continue;
                    for (int check = 0; check < MainForm._MainFormInstance.jobtype; check++)
                    {
                        isChecked = false;
                        if(allString[Rows,Columns] == allString[check, Columns])
                        {
                            if (Rows > check)
                                break;
                            else if(Rows == check)
                            { }
                            else  //Rows < check
                            {
                                if (odd)
                                {
                                    if (!isChecked)
                                    {
                                        first =  allString[Rows, Columns] + "さんは重複しています                             ";
                                        second= (Rows + 24) + "行目　" + (Columns / 6 + 7) + "時" + (Columns % 6 * 10) + "分                                            ";
                                        isChecked = true;
                                    }
                                    third = (check + 24) + "行目　" + (Columns / 6 + 7) + "時" + (Columns % 6 * 10) + "分                                            ";
                                }
                                else
                                {
                                    if (!isChecked)
                                    {
                                        first +=  "|" + allString[Rows, Columns] + "さんは重複しています \r\n";
                                        second += "|" + (Rows + 24) + "行目　" + (Columns / 6 + 7) + "時" + (Columns % 6 * 10) + "分\r\n";
                                        isChecked = true;
                                    }
                                    third +="|" +  (check + 24) + "行目　" + (Columns / 6 + 7) + "時" + (Columns % 6 * 10) + "分\r\n";

                                    message += first + second + third + "\r\n-----------------------------------------------------------------------\r\n";
                                    first = "";
                                    second = "";
                                    third = "";
                                }
                                odd = !odd;
                            } 
                        }
                    }
                }

            }
            message += first + second + third;
            MessageBox.Show(message);

            MainForm._MainFormInstance.inProrgamUse = false;
            book.Application.ScreenUpdating = true;
 
        }
    }
}
