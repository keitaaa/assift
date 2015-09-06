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
            if (MainForm._MainFormInstance.pasteasFormulaBoxValue && target.Columns.Count == 1 && target.MergeCells)
            {
                pasteAsFormula(target);
            }
            if (MainForm._MainFormInstance.duplicateCheckBoxValue)
            {
                target.extractDuplicate();
            }


            
        }
        public static void pasteAsFormula(Excel.Range target)
        {
            Excel.Range cpSrc = null;
            foreach (Excel.Range r in target)
            {
                cpSrc = r.MergeArea;
                break;
            }
            string tmp = cpSrc.get_Value();

            //
            Excel.Range src = target.Worksheet.Cells[int.Parse(System.Configuration.ConfigurationManager.AppSettings["jobtype"]) + 100, 1];
            src.Formula = tmp;
            src.Copy();
            cpSrc.PasteSpecial(Excel.XlPasteType.xlPasteFormulas);

            System.Threading.Thread t = new System.Threading.Thread(clearClipboard);
            t.SetApartmentState(System.Threading.ApartmentState.STA);
            t.Start();
            t.Join();
            //
        }

        public static void clearClipboard()
        {
            Clipboard.SetDataObject(new DataObject());
        }
    }
}
