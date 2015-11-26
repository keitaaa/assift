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
    public static class DrawExcel
    {
        public static void Run(Excel.Workbook book)
        {
            book.Application.ScreenUpdating = true;
            MainForm._MainFormInstance.inProrgamUse = false;
            book.Application.DisplayAlerts = true;
        }
    }
}
