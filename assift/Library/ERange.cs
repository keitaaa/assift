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
using System.Collections;

namespace Shiftwork.Library
{
    public static class ERange
    {
        /// <summary>
        /// [拡張]Rangeオブジェクトの各行に対して重複している要素を抽出します。
        /// </summary>
        /// <returns></returns>
        public static List<int[]> extractDuplicate(this Excel.Range range)
        {
            if (range.Columns.Count >= 2)
            {
                throw new ArgumentOutOfRangeException();
            }
            List<int[]> ret = new List<int[]>();
            // 文字列に変換
            string[] columnstring = range.ColumnToString();

            // 配列空白以外の要素のクエリ
            var query = from x in columnstring
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
                    ret.Add(Util.deepSearch(columnstring, s));
                }

            }
            return ret;
        }

        /// <summary>
        /// [拡張]Rangeクラスのオブジェクトの1列目(縦)を文字列配列に変換します。
        /// </summary>
        /// <returns>1次元の文字列配列を返します。</returns>
        public static string[] ColumnToString(this Excel.Range range)
        {
            return range.ColumnToString(1);

        }

        /// <summary>
        /// [拡張]Rangeクラスのオブジェクトの指定された列(縦)を文字列配列に変換します。
        /// </summary>
        /// <returns>1次元の文字列配列を返します。</returns>
        public static string[] ColumnToString(this Excel.Range range, int column)
        {
            if (range == null)
            {
                throw new ArgumentNullException();
            }

            if (range.Cells.Value == null || range.Cells.Value.GetType() == typeof(String))  
            {
                throw new ArgumentException("Rangeオブジェクトが単一セルです。");  
            }  

            //Excel.RangeオブジェクトをSystem.Arrayオブジェクトに変換します。
            System.Array tmpArr = (System.Array)range.Cells.Value;

            if (column < 0 || tmpArr.GetLength(1) < column)
            {
                throw new ArgumentOutOfRangeException();
            }
            //変換先の文字列配列を用意します。
            string[] ret = new string[tmpArr.GetLength(0)];

            //2次元配列の1列目の各行を文字列に変換して、返り値の配列に代入します。
            for (int i = 1; i <= tmpArr.GetLength(0); i++)
            {
                if (tmpArr.GetValue(i, column) == null)
                    ret[i - 1] = "";
                else
                    ret[i - 1] = (string)tmpArr.GetValue(i, column).ToString();
            }

            return ret;
        }

        /// <summary>
        /// [拡張]Rangeクラスのオブジェクトの1行目(横)を文字列配列に変換します。
        /// </summary>
        /// <returns>1次元の文字列配列を返します。</returns>
        public static string[] RowToString(this Excel.Range range)
        {
            return range.RowToString(1);
        }

        /// <summary>
        /// [拡張]Rangeクラスのオブジェクトの指定された行(横)を文字列配列に変換します。
        /// </summary>
        /// <returns>1次元の文字列配列を返します。</returns>
        public static string[] RowToString(this Excel.Range range, int row)
        {
            if (range == null)
            {
                throw new ArgumentNullException();
            }
            if (range.Cells.Value == null || range.Cells.Value.GetType() == typeof(String))
            {
                throw new ArgumentException("Rangeオブジェクトが単一セルです。");
            }

            //Excel.RangeオブジェクトをSystem.Arrayオブジェクトに変換します。
            System.Array tmpArr = (System.Array)range.Cells.Value;

            if (row < 0 || tmpArr.GetLength(0) < row)
            {
                throw new ArgumentOutOfRangeException();
            }

            //変換先の文字列配列を用意します。
            string[] ret = new string[tmpArr.GetLength(1)];

            //2次元配列の1行目の各列を文字列に変換して、返り値の配列に代入します。
            for (int i = 1; i <= tmpArr.GetLength(1); i++)
            {
                if (tmpArr.GetValue(row, i) == null)
                    ret[i - 1] = "";
                else
                    ret[i - 1] = (string)tmpArr.GetValue(row, i).ToString();
            }

            return ret;
        }

        /// <summary>
        /// [拡張]Rangeクラスのオブジェクトを文字列配列に変換します。
        /// </summary>
        /// <returns>文字列配列を返します。</returns>
        public static string[,] DeepToString(this Excel.Range range)
        {
            if (range == null)
            {
                throw new ArgumentNullException();
            }
            if (range.Cells.Value == null || range.Cells.Value.GetType() == typeof(String))
            {
                throw new ArgumentException("Rangeオブジェクトが単一セルです。");
            }

            //Excel.RangeオブジェクトをSystem.Arrayオブジェクトに変換します。
            System.Array tmpArr = (System.Array)range.Cells.Value;

            //変換先の文字列配列を用意します。
            string[,] ret = new string[tmpArr.GetLength(0), tmpArr.GetLength(1)];

            //2次元配列の1列目の各行を文字列に変換して、返り値の配列に代入します。
            for (int i = 1; i <= tmpArr.GetLength(0); i++)
            {
                for (int j = 1; j <= tmpArr.GetLength(1); j++)
                {
                    if (tmpArr.GetValue(i, j) == null)
                        ret[i - 1, j - 1] = "";
                    else
                        ret[i - 1, j - 1] = (string)tmpArr.GetValue(i, j).ToString();
                }
            }

            return ret;
        }


    }
}
