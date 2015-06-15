using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Shiftwork.Library;
using System.Collections;

namespace Shiftwork.Payload
{
    static class Duplicate
    {
        public static List<List<int[]>> DuplicateCheck(Excel.Range range)
        {
            int columnNum = range.Columns.Count;
            int rowNum = range.Rows.Count;

            List<List<int[]>> ret = new List<List<int[]>>();
            for (int i = 1; i <= columnNum; i++)
            {
                Excel.Range buf = range[1, i];
                buf = buf.get_Resize(rowNum, 1);
                ret.Add(buf.ColumnDuplicateCheck());
            }

            return ret;
        }
    }
}
