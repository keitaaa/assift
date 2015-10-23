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
    public static class Util
    {
        /// <summary>
        /// 指定した配列の全体を検索し、見つかったすべてのインデックスを返します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">検索対象の1次元配列</param>
        /// <param name="value">対象となるオブジェクト</param>
        /// <returns>インデックスの配列</returns>
        public static int[] deepSearch<T>(T[] array, T value)
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
                throw new ArgumentException("検索対象が見つかりませんでした。");
            }
            int[] ret = index.ToArray();
            return ret;
        }

        /// <summary>
        /// [拡張]Rangeオブジェクトの各行に対して重複している要素を抽出します。
        /// </summary>
        /// <returns></returns>
        public static string[] extractDuplicate(string[] array)
        {
            List<string> ret = new List<string>();

            // 配列空白以外の要素のクエリ
            var query = from x in array
                        where x != ""
                        select x;

            // 空白以外の要素数
            // 重複及び空白以外の要素数
            // 2つの要素数が同じであれば、重複はないのでnullを返す。
            if (query.Count() == query.Distinct().Count())
            {
                return null;
            }

            // 重複判定部分
            else
            {
                /* 重複のみの要素のクエリを作成します。
                 * 
                 * <作成手順>
                 * 1)重複を入れるリストに1行すべての要素を追加します。
                 * 2)この要素から、重複を取り除いた要素を引き算します。（これで２つ以上あるものだけのリストになる）
                 * 3)３つ以上のものはまだ２つ以上残っているので、distinctしたクエリを作成します。
                 * 4)完成！！
                 */
                List<string> exceptlist = new List<string>(query);
                foreach (string s in query.Distinct<string>())
                {
                    exceptlist.Remove(s);
                }
                var exceptquery = exceptlist.Distinct<string>();

                foreach (string s in exceptquery)
                {
                    ret.Add(s);
                }
            }

            return ret.ToArray();
        }
        public static Excel.Range MakeRange(Excel.Range range)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 配列の2列目と引数のbureau,4列目と引数のgradeが一致する行の中から、8列目から16列目に存在する仕事名を抽出します。
        /// </summary>
        /// <param name="list">構成員名簿</param>
        /// <param name="bureau">局</param>
        /// <param name="grade">学年</param>
        /// <returns></returns>
        public static string[] jobSearch(string[,] list, string bureau, string grade)
        {
            List<string> jobname = new List<string>();
            for (int i = 0; i < list.GetUpperBound(0) + 1; i++ )
            {
                if ((bureau == "全" || bureau == list[i, 1]) && (grade == "全" || grade == list[i, 3]))
                {
                    for (int n = 7; n < 16; n++)
                    {
                        if (list[i, n] == null || list[i, n] == "") break;
                        jobname.Add(list[i, n]);
                    }
                }
            }
            var query = jobname.Distinct<string>();
            List<string> tmp = new List<string>();
            foreach (string s in query)
            {
                tmp.Add(s);
            }

            return tmp.ToArray<string>();
        }
    }
}