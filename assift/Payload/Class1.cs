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
            //プログラム処理途中に強制終了されて、例えば描画OFFのままになってしまうことがたまにある
            //そういう時に無理やり元に戻す？ための機能です
            //割と便利なのでもう少し調整してもいいかもね
            book.Application.ScreenUpdating = true;
            MainForm._MainFormInstance.inProrgamUse = false;
            book.Application.DisplayAlerts = true;
        }
    }
}
