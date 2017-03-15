using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Shiftwork.Library;
using System.Diagnostics;

namespace Shiftwork.Payload
{
    class AllCheck
    {
        public static void Run(Excel.Workbook book)
        {

            //シフトのデータが入っているセルを全てallRangeに入れます
            //allStringにallRangeの文字列をすべて入れます
            //allStringの中をfor文でチェックします
            //Rangeは読み込むのに時間がかかるため、String型に変換してから処理することで実行時間を短くしています

            //実行結果をmessageに入れます、その時に二列にして表示しているのですが、
            //oddを使って奇数番目を先（左）に、偶数番目を後（右）に入れ、二列に見せかけています
            //実行時間も計測していますが、十分だと思います
 
            //表示結果が見にくいので、重複結果が重複しているとき（10:00と10:10で同じ人が重複しているとき）
            //表示結果を一つにまとめてしまうと良いかと思います
            book.Application.ScreenUpdating = true;
            MainForm._MainFormInstance.inProrgamUse = true;

            int Rows = 0, Columns = 0; 
            Excel.Worksheet jobsheet; 
            Excel.Sheets sheets;
            sheets = book.Worksheets;
            jobsheet = (Excel.Worksheet)sheets.get_Item(sheets.getSheetIndex("仕事シフト")); 
            Excel.Range allRange = jobsheet.Cells[MainForm._MainFormInstance.startaddr_row, MainForm._MainFormInstance.startaddr_col];  
            allRange = allRange.get_Resize(MainForm._MainFormInstance.jobtype + 10 , 90);
            string[,] allString = allRange.DeepToString();
            string message = "";
            bool isChecked=false;
            bool odd = true;
            string first = "",second="",third="";
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (Columns = 0; Columns < 90; Columns++)            //右に移動してチェックするfor文、
            {
                for (Rows = 0; Rows < MainForm._MainFormInstance.jobtype; Rows++) {                //下に移動してチェックする
                    if (allString[Rows, Columns] == null || allString[Rows, Columns] == "")
                        continue;
                    for (int check = 0; check < MainForm._MainFormInstance.jobtype; check++)        //チェックするものがその列にあるかどうか確認する
                    {
                        isChecked = false;　　　　　　//この変数意味ないですね、消すの怖いのでチェックしてから消してください、たぶん問題ないはず
                        if(allString[Rows,Columns] == allString[check, Columns])
                        {
                            if (Rows > check)           //二回表示されるのを防ぐためにRows>checkの時はエラーとみなしません、上のfor文でcheck=Rowsにすれば解決ですけどね
                                break;
                            else if(Rows == check)      //同じものを比較する意味は無いので当然飛ばします
                            { }
                            else  //Rows < check
                            {
                                //メッセージを二列に分けているだけの処理
                                if (odd)
                                {
                                    if (!isChecked)
                                    {
                                        first =  allString[Rows, Columns] + "さんは重複しています                             ";
                                        second= (Rows + MainForm._MainFormInstance.startaddr_row) + "行目　" + (Columns / 6 + 7) + "時" + (Columns % 6 * 10) + "分                                            ";
                                        isChecked = true;
                                    }
                                    third = (check + MainForm._MainFormInstance.startaddr_row) + "行目　" + (Columns / 6 + 7) + "時" + (Columns % 6 * 10) + "分                                            ";
                                }
                                else
                                {
                                    if (!isChecked)
                                    {
                                        first +=  "|" + allString[Rows, Columns] + "さんは重複しています \r\n";
                                        second += "|" + (Rows + MainForm._MainFormInstance.startaddr_row) + "行目　" + (Columns / 6 + 7) + "時" + (Columns % 6 * 10) + "分\r\n";
                                        isChecked = true;
                                    }
                                    third +="|" +  (check + MainForm._MainFormInstance.startaddr_row) + "行目　" + (Columns / 6 + 7) + "時" + (Columns % 6 * 10) + "分\r\n";

                                    message += first + second + third + "\r\n-----------------------------------------------------------------------\r\n";
                                    first = "";
                                    second = "";
                                    third = "";
                                }
                                odd = !odd;
                                //メッセージを二列に分ける処理終了
                            } 
                        }
                    }
                }

            }
            sw.Stop();
            message += first + second + third;
            if (message == "")
                message += "重複はありませんでした";
            MessageBox.Show(sw.ElapsedMilliseconds+"ミリ秒で処理が終了しました\r\n"+message);

            MainForm._MainFormInstance.inProrgamUse = false;
            book.Application.ScreenUpdating = true;
 
        }
    }
}
