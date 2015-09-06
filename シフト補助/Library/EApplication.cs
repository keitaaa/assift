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
using System.Windows.Forms;


namespace Shiftwork.Library
{
    /// <summary>
    /// Microsoft.Office.Interop.Excel名前空間を拡張しています。
    /// </summary>
    static public class EApplication
    {
        static Guid IID_IUnknown = new Guid("00000000-0000-0000-C000-000000000046");
        [DllImport("ole32.dll")]
        static extern int CreateBindCtx(uint reserved, out IBindCtx ppbc);


        /// <summary>
        /// [拡張]引数に指定された名前のワークブックを開いているアプリケーションを設定します。
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <param name="WorkbookName">ワークブック名です。</param>
        static public Excel.Application setApps(this Excel.Application application, string WorkbookName)
        {
            //Excel.Application application = new Excel.Application();
            Boolean isSuccessed = false;

            if (WorkbookName == null || WorkbookName == "")
            {
                throw new ArgumentNullException();
            }

            // IBindCtx
            IBindCtx pBindCtx = null;
            CreateBindCtx(0, out pBindCtx);

            // IRunningObjectTable
            IRunningObjectTable pROT = null;
            pBindCtx.GetRunningObjectTable(out pROT);

            // IEnumMoniker
            IEnumMoniker pEnumMoniker = null;
            pROT.EnumRunning(out pEnumMoniker);

            pEnumMoniker.Reset();

            for (; ; )
            {
                // IMoniker
                IMoniker[] pMonikers = { null };

                IntPtr fetched = IntPtr.Zero;
                if (pEnumMoniker.Next(1, pMonikers, fetched) != 0)
                {
                    break;
                }

                // For Debug
                string strDisplayName;
                pMonikers[0].GetDisplayName(pBindCtx, null, out strDisplayName);
                Debug.WriteLine(strDisplayName);


                object obj = null;
                Excel.Workbook pBook = null;
                try
                {
                    pMonikers[0].BindToObject(pBindCtx, null, ref IID_IUnknown, out obj);

                    pBook = obj as Excel.Workbook;
                    if (pBook != null && pBook.Name == WorkbookName)
                    {
                        application = (Excel.Application)pBook.Application;
                        isSuccessed = true;
                        break;
                    }
                }
                catch (Exception)
                {
                }
                finally
                {

                    Marshal.ReleaseComObject(pMonikers[0]);
                }

            }

            Marshal.ReleaseComObject(pEnumMoniker);
            Marshal.ReleaseComObject(pROT);
            Marshal.ReleaseComObject(pBindCtx);

            if (!isSuccessed)
            {
                throw new NullReferenceException("起動中のExcelインスタンスが見つかりませんでした。");
            }
            return application;
        }


        /// <summary>
        /// [拡張]起動しているExcelの一覧を取得します。見つからない場合はnullを返します。
        /// TODO:返り値を2次元配列にして、PID返す。http://stackoverflow.com/questions/8490564/getting-excel-application-process-id
        /// </summary>
        /// <returns>ブック名の文字列配列です。</returns>
        static public string[] ListApps(this Excel.Application application)
        {
            List<String> arr = new List<String>();

            // IBindCtx
            IBindCtx pBindCtx = null;
            CreateBindCtx(0, out pBindCtx);

            // IRunningObjectTable
            IRunningObjectTable pROT = null;
            pBindCtx.GetRunningObjectTable(out pROT);

            // IEnumMoniker
            IEnumMoniker pEnumMoniker = null;
            pROT.EnumRunning(out pEnumMoniker);

            pEnumMoniker.Reset();

            for (; ; )
            {
                // IMoniker
                IMoniker[] pMonikers = { null };

                IntPtr fetched = IntPtr.Zero;
                if (pEnumMoniker.Next(1, pMonikers, fetched) != 0)
                {
                    break;
                }

                // For Debug
                string strDisplayName;
                pMonikers[0].GetDisplayName(pBindCtx, null, out strDisplayName);
                Debug.WriteLine(strDisplayName);


                object obj = null;
                Excel.Workbook pBook = null;
                try
                {
                    pMonikers[0].BindToObject(pBindCtx, null, ref IID_IUnknown, out obj);

                    pBook = obj as Excel.Workbook;
                    if (pBook != null)
                    {
                        arr.Add(pBook.Name);

                        //For Debug
                        //MessageBox.Show(pBook.Name);
                    }
                }
                catch (Exception)
                {
                }
                finally
                {

                    Marshal.ReleaseComObject(pMonikers[0]);
                }

            }

            Marshal.ReleaseComObject(pEnumMoniker);
            Marshal.ReleaseComObject(pROT);
            Marshal.ReleaseComObject(pBindCtx);

            if (arr.Count <= 0)
            {
                throw new NullReferenceException("開かれているワークブックが見つかりませんでした。");
            }
            return arr.ToArray();
        }


        /// <summary>
        /// アプリケーションを開放します。
        /// </summary>
        static public Excel.Application closeApp(this Excel.Application application)
        {
            //インスタンスの解放
            Marshal.ReleaseComObject(application);
            application = null;
            return application;
        }
    }
}

