//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace shiftwork.payload
//{
//     /// <summary>
//    /// バックアップを行う動作が含まれているクラスです。
//    /// </summary>
//    public class BackupTimer
//    {
//        /// <summary>
//        /// 一定間隔でイベントを発生させるタイマオブジェクトです。
//        /// </summary>
//        public Timer timer;
//        /// <summary>
//        /// バックアップ動作を行う間隔です。単位は分です。
//        /// </summary>
//        public int backupInterval { get; set; }
//        /// <summary>
//        /// バックアップを行うファイル名です。
//        /// </summary>
//        public string FileName { get; set; }
//        /// <summary>
//        /// バックアップの世代の上限数です。
//        /// </summary>
//        public int maxBackup { get; set; }

//        /// <summary>
//        /// バックアップのWindowsタイマハンドラを登録します。
//        /// </summary>
//        public void Run()
//        {
//            Backup(null, null);
//            timer = new Timer();
//            timer.Tick += new EventHandler(Backup);
//            timer.Interval = backupInterval * 00;
//            timer.Enabled = true;
//        }

//        /// <summary>
//        /// バックアップを停止します。
//        /// </summary>
//        public void Stop()
//        {
//            timer.Enabled = false;
//        }

//        /// <summary>
//        /// バックアップ動作を行うメソッドです。
//        /// </summary>
//        /// <param name="sender">イベントの発生元のSystem.Objectクラスのオブジェクトです。</param>
//        /// <param name="e">System.EventArgsクラスのイベントの補足情報を表します。</param>
//        private void Backup(object sender, EventArgs e)
//        {
//            // 今アタッチしているファイルが存在しない場合終了（例外処理）
//            if (!File.Exists(Path.GetFullPath(FileName))) { return; }


//            // 世代番号を一つずつずらします。
//            for (int num = 10; num > 0; num--)
//            {
//                string tmp = "*_" + num.ToString() + ".*";
//                string[] files = Directory.GetFiles(Path.GetDirectoryName(FileName), tmp);
//                if (files.Length == 0)
//                    continue;
//                string backupSrc = files[0];
//                string backupDst = files[0];
//                backupDst = backupDst.Remove(backupDst.LastIndexOf("_"));
//                backupDst += "_" + (num + 1).ToString() + Path.GetExtension(files[0]);
//                File.Move(backupSrc, backupDst);
//            }
//            // 今実行しているファイルを世代番号1にしてコピー
//            string backup = GetBackupName(1);
//            File.Copy(FileName, backup);

//            // 世代番号11番が存在したら削除します
//            string[] overMax = Directory.GetFiles(Path.GetDirectoryName(FileName), "*_11.*");
//            if (overMax.Length > 0) { File.Delete(overMax[0]); }
//        }

//        /// <summary>
//        /// ファイル名にバックアップ時の日時と引数として渡された番号を付加して、バックアップのフルパスの文字列を返します。
//        /// 例：
//        /// ファイル名が"test.xlsx",世代番号が1,2014年6月27日,0時22分10秒,C:\Users\hoge\配下にあるなら、
//        /// "C:\Users\hoge\test20140627-002210_1.xlsx"という文字列を返します。
//        /// </summary>
//        /// <param name="num">文字列に付加する世代番号です。</param>
//        /// <returns>バックアップのフルパスの文字列を返します。</returns>
//        private string GetBackupName(int num)
//        {
//            string ret = Path.GetDirectoryName(shift.Form1.pathname) + "\\" + Path.GetFileNameWithoutExtension(shift.Form1.pathname);
//            ret += DateTime.Now.ToString("yyyyMMdd-HHmmss") + "_" + num + Path.GetExtension(shift.Form1.pathname);
//            return ret;
//        }

//    }

//}
