using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Shiftwork;

namespace Shiftwork.Library
{
    public static class EWorksheets
    {

        /// <summary>
        /// [拡張]指定されたシート名を持つワークシートのインデックスを返します。
        /// </summary>
        /// <param name="sheetName">検索したいワークシート名です。</param>
        /// <returns>ワークシートのインデックスです。</returns>
        public static int getSheetIndex(this Excel.Worksheets worksheets, string sheetName)
        {
            int sheetIndex = 0;
            if (!worksheets.Contains(sheetName))
            {
                throw new Exception("指定されたワークシートが見つかりませんでした。");
            }
            foreach (Excel.Worksheet sh in worksheets)
            {
                if (sheetName == sh.Name)
                {
                    return sheetIndex + 1;
                }
                ++sheetIndex;
            }
            throw new Exception("不明な例外が発生しました。");
        }

        /// <summary>
        /// [拡張]指定されたシート名を持つワークシートが存在するか判断します。
        /// </summary>
        /// <param name="sheetName">検索したいワークシート名です。</param>
        /// <returns>存在していればtrue,それ以外はfalseを返します。</returns>
        public static bool Contains(this Excel.Worksheets worksheets, string sheetName)
        {
            if (sheetName == null || sheetName == "")
            {
                throw new ArgumentNullException();
            }
            return((from Excel.Worksheet sh in worksheets select sh).Any(sh => sh.Name == sheetName));
        }
        
    }
}
