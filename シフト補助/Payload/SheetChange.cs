using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Shiftwork.Library;
using System.Collections;
using System.Configuration;

namespace Shiftwork.Payload
{
    public static class SheetChange
    {

        /// <summary>
        /// シートが変更された時に呼び出されるメソッドです。
        /// </summary>
        /// 引数のRangeオブジェクトですが、セルが結合されていても最左上のセルのみになるようです。
        /// そのためtargetに対して、Columns,Rows実行してもどちらも1です。
        /// 結合セル調べたかったら、target.MergeAreaに対して行う必要があるようです。
        /// <param name="sh">変更されたワークシート</param>
        /// <param name="target">変更された最左上セルオブジェクト</param>
        public static void sheetChanged(object sh, Excel.Range target)
        {
            //TODO:再帰呼び出し対策をちゃんとすること
            Excel.Worksheet sheet = (Excel.Worksheet)sh;
            int start_row = int.Parse(System.Configuration.ConfigurationManager.AppSettings["datastartaddress_row"]);
            int start_column = int.Parse(System.Configuration.ConfigurationManager.AppSettings["datastartaddress_column"]);
            int jobtype = int.Parse(System.Configuration.ConfigurationManager.AppSettings["jobtype"]);

            if (sheet.Name != "仕事シフト")
            {
                return;
            }

            if (target.Row >= (start_row + jobtype))
            {
                return;
            }

            if (MainForm._MainFormInstance.pasteasFormulaBoxValue && !MainForm._MainFormInstance.inProrgamUse && target.MergeCells)
            {
                pasteAsFormula(target);
            }

            if (MainForm._MainFormInstance.duplicateCheckBoxValue)
            {
                //target.extractDuplicate();
            }


            
        }
        public static void pasteAsFormula(Excel.Range target)
        {
            MainForm._MainFormInstance.inProrgamUse = true;

            // MergeAreaにたいしてget_Valueすると、2次元配列になります。単一セルに対して実行してください。
            // 数値が入っていると、get_Valueの返り値はdouble型みたいです。だからtoStringつけとく。
            if(target.Columns.Count != 1 && target.Rows.Count != 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            string value = "";
            if (target.get_Value() == null)
            {
                value = "";
            }
            else
            {
                value = target.get_Value().ToString();
            }
            

            // 何度も出てきますが、Columns.Count,Rows.Countともに1じゃないRangeオブジェクトに対して、MergeAreaを実行すると例外が発生します。
            // 上のif文で確認してるので問題ないとは思いますが、念のためforeach文を使ってます。
            // Rangeオブジェクトは最左上のセルから1つずつのセルを返してくれるイテレータがあるためです。
            Excel.Range cpSrc = null;
            foreach (Excel.Range r in target)
            {
                cpSrc = r.MergeArea;
                break;
            }


            int jobtype = int.Parse(System.Configuration.ConfigurationManager.AppSettings["jobtype"]);
            Excel.Range src = target.Worksheet.Cells[jobtype + 100, 1];
            src.Formula = value;
            src.Copy();
            cpSrc.PasteSpecial(Excel.XlPasteType.xlPasteFormulas);

            // 
            System.Threading.Thread t = new System.Threading.Thread(clearClipboard);
            t.SetApartmentState(System.Threading.ApartmentState.STA);
            t.Start();
            t.Join();

            MainForm._MainFormInstance.inProrgamUse = false;
        }

        public static void clearClipboard()
        {
            Clipboard.SetDataObject(new DataObject());
        }
    }
}
