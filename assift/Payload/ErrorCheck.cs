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
    public static class ErrorCheck
    {
       /// <summary>
        /// Rangeオブジェクトの1行に対して重複チェックを行います。
       /// </summary>
       /// <param name="range">検索対象のRangeオブジェクト</param>
       /// <param name="exclude">除外したいキーワード</param>
       /// <returns></returns>
        public static string duplicateCheck(Excel.Range range, params string[] exclude)
        {
            if (range.Columns.Count >= 2)
            {
                throw new ArgumentOutOfRangeException();
            }

            string[] src = range.ColumnToString();



            return null;
        }
    }
}
