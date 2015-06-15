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

namespace Shiftwork.Library
{
    static class Util
    {
        /// <summary>
        /// 指定した配列の全体を検索し、見つかったすべてのインデックスを返します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">検索対象の1次元配列</param>
        /// <param name="value">対象となるオブジェクト</param>
        /// <returns>インデックスの配列</returns>
        public static int[] Search<T>(T[] array, T value)
        {
            if (array == null || value == null)
            {
                throw new ArgumentNullException();
            }
            int foundIndex = Array.IndexOf(array, value);
            List<int> index = new List<int>();
            while (0 <= foundIndex)
            {
                //要素が見つかったときは、その位置を表示する
                Debug.WriteLine(value + " : " + foundIndex);
                index.Add(foundIndex);

                if (foundIndex + 1 < array.Length)
                {
                    //次の要素を検索する
                    foundIndex = Array.IndexOf(array, value, foundIndex + 1);
                }
                else
                {
                    //最後まで検索したときはループを抜ける
                    break;
                }
            }
            if (index.Count < 1)
            {
                throw new ArgumentException("検索対象に見つかりませんでした。");
            }
            int[] ret = index.ToArray();
            return ret;
        }


        public static Excel.Range MakeRange(Excel.Range range)
        {

        }
    }
}