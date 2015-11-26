using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Shiftwork.Library;
using Shiftwork.Payload;
using System.Diagnostics;

namespace Shiftwork
{
    public partial class EnterName : Form
    {
        private string[,] nameData;      // 構成員名簿データ
        private string[,] jobShiftData;          // 仕事シフトの初期データ
        private string[,] privateShiftData;        // 名前シフトのデータ
        private string[] names;

        Excel.Workbook book;             // 操作中のワークブック(Workbook -> Sheets)
        Excel.Sheets sheets;             // 操作中のワークシートの集合(Sheets -> get_Itemでシート)
        Excel.Worksheet jobsheet;        // 仕事シフトのワークシート

        private long processingTime = 0;
        private int count = 0;

        /// <summary>
        /// アクティブなセル（結合セルの場合は単一セル）
        /// </summary>
        Excel.Range activerange;
        /// <summary>
        /// 選択中のセル（結合セルの場合はすべて）
        /// </summary>
        Excel.Range selectrange;
        Hashtable ht;

        /// <summary>
        /// EnterNameフォームのコンストラクタです。
        /// 引数として渡された、構成員名簿データと操作中のアプリケーションを自身のメンバに複製します。
        /// </summary>
        /// <param name="nameData">構成員名簿データ</param>
        /// <param name="app">操作中のExcelアプリケーション</param>
        public EnterName(string[,] nameData, Excel.Workbook book)
        {
            InitializeComponent();
            this.nameData = nameData;
            this.book = book;

            // ワークブックからワークシートを接続します
            sheets = book.Worksheets;
            jobsheet = (Excel.Worksheet)sheets.get_Item(sheets.getSheetIndex("仕事シフト"));
            ht = new Hashtable();
            getData();
        }

        private void getData()
        {
            // TODO:例外追加
            Excel.Worksheet privateShiftSheet;
            privateShiftSheet = (Excel.Worksheet)sheets.get_Item(sheets.getSheetIndex("個人シフト"));
            Excel.Range privateShiftRange;
            privateShiftRange = privateShiftSheet.get_Range("D4", "CP206");
            privateShiftData =  privateShiftRange.DeepToString();
            names = privateShiftRange.ColumnToString();

            Excel.Range jobShiftRange;
            jobShiftRange = jobsheet.get_Range("B24", "CN523");
            jobShiftData = jobShiftRange.DeepToString();
            privateShiftData = ConvertPrivate.ConvertP(jobShiftData, names);

            for (int i = 0; i < names.Length; i++)
            {
                ht.Add(names[i], i.ToString());
            }
        }
        /// <summary>
        /// フォームがロードされた時のメソッドです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterName_Load(object sender, EventArgs e)
        {


            // フォームの初期化
            jobBox.Items.Clear();
            jobBox.Items.Add("全");
            this.jobBox.SelectedIndex = 0;
            jobBox2.Items.Clear();
            jobBox2.Items.Add("全");
            this.jobBox2.SelectedIndex = 0;
            bureauTextBox.Text = "全";
            gradeTextBox.Text = "全";

            // 仕事選択とフォームがアクティブになった時のイベントハンドラの追加
            this.jobBox.SelectedIndexChanged += new EventHandler(jobBox_SelectedIndexChanged);
            this.jobBox2.SelectedIndexChanged += new EventHandler(jobBox2_SelectedIndexChanged);
            this.Activated += new EventHandler(EnterName_Activated);

            activeCellUpdate();
        }

        #region method using EventHandler

        /// <summary>
        /// フォームがアクティブになった時に実行されるメソッドです。
        /// 名前の一覧とアクティブなセルを更新します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void EnterName_Activated(object sender, EventArgs e)
        {
            nameViewUpdate2(bureauTextBox.Text, gradeTextBox.Text, jobBox.SelectedItem.ToString(), jobBox2.SelectedItem.ToString());
            activeCellUpdate();
            ActiveControl = sendButton;
        }

        /// <summary>
        /// 仕事一覧のインデックスが変化した時に実行されるメソッドです。
        /// 名前の一覧とアクティブなセルを更新します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void jobBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            nameViewUpdate2(bureauTextBox.Text, gradeTextBox.Text, jobBox.SelectedItem.ToString(), jobBox2.SelectedItem.ToString());
            activeCellUpdate();
        }
        void jobBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            nameViewUpdate2(bureauTextBox.Text, gradeTextBox.Text,jobBox.SelectedItem.ToString() ,jobBox2.SelectedItem.ToString());
            activeCellUpdate();
        }
        #endregion

        #region method using update
        /// <summary>
        /// 選択しているセルをメンバ変数にコピーします。
        /// </summary>
        private void activeCellUpdate()
        {
            // TODO:選択中のアプリケーション
            book.Application.ScreenUpdating = false;
            jobsheet.Activate();
            activerange = book.Application.ActiveCell;
            selectrange = book.Application.Selection;
            Focus();
            book.Application.ScreenUpdating = true;
            
        }

        /// <summary>
        /// 名簿リストを更新します。
        /// TODO:名前シフトに変換したらすごい早いんじゃないかな…？
        /// </summary>
        /// <param name="bureau">抽出する局</param>
        /// <param name="grade">抽出する学年</param>
        /// <param name="job">抽出する仕事</param>
        private void nameViewUpdate(string bureau, string grade, string job)
        {
            // 引数がnullの時の例外処理
            if (bureau == null || grade == null || job == null)
            {
                throw new ArgumentNullException();
            }

            // 追加するデータの検索
            List<DataGridViewRow> row_list = new List<DataGridViewRow>();
            for (int i = 0; i <= nameData.GetUpperBound(0); i++)
            {
                if ((bureau == "全" || bureau == nameData[i, 1]) && (grade == "全" || grade == nameData[i, 3]) && (job == "全" || isJobContained(job, i)))
                {
                    object[] row_value = new object[] { nameData[i, 1], nameData[i, 2], nameData[i, 3], nameData[i, 4], isFilled(nameData[i, 4]) ? "×" : "○" };
                    DataGridViewRow row = new DataGridViewRow();

                    // セルを作成してから、値を設定(この順番が重要)
                    row.CreateCells(nameView);
                    row.SetValues(row_value);
                    row_list.Add(row);
                }
            }
        }

        private void nameViewUpdate2(string bureau, string grade, string job,string job2)
        {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            // 引数がnullの時の例外処理
            if (bureau == null || grade == null || job == null || job2 ==null)
            {
                throw new ArgumentNullException();
            }

            // 追加するデータの検索
            List<DataGridViewRow> row_list = new List<DataGridViewRow>();
            for (int i = 0; i <= nameData.GetUpperBound(0); i++)
            {
                if ((bureau == "全" || bureau == nameData[i, 1]) && (grade == "全" || grade == nameData[i, 3]) && ((job == "全" || isJobContained(job, i) && job2 == "全") || isJobContained(job, i) || isJobContained(job2, i)))
                {
                    object[] row_value = new object[] { nameData[i, 1], nameData[i, 2], nameData[i, 3], nameData[i, 4], isFilled(nameData[i, 4]) ? "×" : "○" };
                    DataGridViewRow row = new DataGridViewRow();

                    // セルを作成してから、値を設定(この順番が重要)
                    row.CreateCells(nameView);
                    row.SetValues(row_value);
                    row_list.Add(row);
                }
            }
            // 既存のデータを消去してから、一度に追加する
            nameView.Rows.Clear();
            nameView.Rows.AddRange(row_list.ToArray<DataGridViewRow>());
            //sw.Stop();
            //long pgTime = sw.ElapsedMilliseconds;
            //string prt = string.Format("処理時間は {0} ミリ秒です。", pgTime);
            //MessageBox.Show(prt);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        //private bool isFilled(string name)
        //{
        //    if(name == null)
        //    {
        //        throw new ArgumentNullException();
        //    }
        //    // selectなのかactiveなのか要調査
        //    Excel.Range tmprange = jobsheet.Cells[24, selectrange.Column];
        //    tmprange = tmprange.get_Resize(MainForm._MainFormInstance.jobtype, selectrange.Columns.Count);
        //    string[,] tmp = tmprange.DeepToString();

        //    return (isdeepContained(tmp, name));
        //}
        private bool isFilled(string name)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int k = int.Parse((string)ht[name]);
            for (int i = (activerange.Column -3); (activerange.Column + selectrange.Columns.Count -4) >= i; i++)
            {
                if(privateShiftData[k,i] != null && privateShiftData[k,i] != "")
                {
                    sw.Stop();
                    processingTime += sw.ElapsedMilliseconds;
                    ++count;
                    Debug.WriteLine("finished " + count + "times. elapsed " + processingTime + " ms.");
                    if(sw.ElapsedMilliseconds >= 100)
                    {
                        MessageBox.Show(name);
                    }
                    return true;
                }
            }
            sw.Stop();
            processingTime += sw.ElapsedMilliseconds;
            ++count;
            Debug.WriteLine("finished " + count + "times. elapsed " + processingTime + " ms.");
            if (sw.ElapsedMilliseconds >= 100)
            {
                MessageBox.Show(name);
            }

            return false;

        }
        private bool isdeepContained (string[,] array, string data)
        {
            for(int i = 0; i <= array.GetUpperBound(1); i++)
            {
                for(int j = 0; j <= array.GetUpperBound(0); j++)
                {
                    if (array[j, i] == data) return true;
                }
            }
            return false;
        }

        private bool isJobContained(string job, int index)
        {
            for (int i = 7; i <= 16; i++)
            {
                if (nameData[index,i] == job)
                {
                    return true;
                }
            }
            return false;
        }

        private void jobBoxUpdate(string bureau, string grade)
        {
            this.jobBox.SelectedIndexChanged -= new EventHandler(jobBox_SelectedIndexChanged);
            this.jobBox2.SelectedIndexChanged -= new EventHandler(jobBox2_SelectedIndexChanged);

            jobBox.Items.Clear();
            jobBox.Items.Add("全");
            jobBox2.Items.Clear();
            jobBox2.Items.Add("全");

            jobBox.Items.AddRange(Util.jobSearch(nameData, bureau, grade));
            jobBox2.Items.AddRange(Util.jobSearch(nameData, bureau, grade));

            this.jobBox.SelectedIndex = 0;
            this.jobBox.SelectedIndexChanged += new EventHandler(jobBox_SelectedIndexChanged);
            this.jobBox2.SelectedIndex = 0;
            this.jobBox2.SelectedIndexChanged += new EventHandler(jobBox2_SelectedIndexChanged);

        }
        #endregion


        #region button clicked


        private void bulAll_Click(object sender, EventArgs e)
        {
            bureauTextBox.Text = "全";
            sendButton.Enabled = false;
            jobBoxUpdate(bureauTextBox.Text, gradeTextBox.Text);
            nameViewUpdate2(bureauTextBox.Text, gradeTextBox.Text, jobBox.SelectedItem.ToString(), jobBox2.SelectedItem.ToString());
            activeCellUpdate();
            sendButton.Enabled = true;
        }

        private void bulShikko_Click(object sender, EventArgs e)
        {
            bureauTextBox.Text = "執行";
            sendButton.Enabled = false;
            jobBoxUpdate(bureauTextBox.Text, gradeTextBox.Text);
            nameViewUpdate2(bureauTextBox.Text, gradeTextBox.Text, jobBox.SelectedItem.ToString(), jobBox2.SelectedItem.ToString());
            activeCellUpdate();
            sendButton.Enabled = true;
        }

        private void bulKoho_Click(object sender, EventArgs e)
        {
            bureauTextBox.Text = "広報";
            sendButton.Enabled = false;
            jobBoxUpdate(bureauTextBox.Text, gradeTextBox.Text);
            nameViewUpdate2(bureauTextBox.Text, gradeTextBox.Text, jobBox.SelectedItem.ToString(), jobBox2.SelectedItem.ToString());
            activeCellUpdate();
            sendButton.Enabled = true;
        }

        private void bulKikaku_Click(object sender, EventArgs e)
        {
            bureauTextBox.Text = "企画";
            sendButton.Enabled = false;
            jobBoxUpdate(bureauTextBox.Text, gradeTextBox.Text);
            nameViewUpdate2(bureauTextBox.Text, gradeTextBox.Text, jobBox.SelectedItem.ToString(), jobBox2.SelectedItem.ToString());
            activeCellUpdate();
            sendButton.Enabled = true;
        }

        private void bulSoushoku_Click(object sender, EventArgs e)
        {
            bureauTextBox.Text = "装飾";
            sendButton.Enabled = false;
            jobBoxUpdate(bureauTextBox.Text, gradeTextBox.Text);
            nameViewUpdate2(bureauTextBox.Text, gradeTextBox.Text, jobBox.SelectedItem.ToString(), jobBox2.SelectedItem.ToString());
            activeCellUpdate();
            sendButton.Enabled = true;
        }

        private void bulShisetu_Click(object sender, EventArgs e)
        {
            bureauTextBox.Text = "施設";
            sendButton.Enabled = false;
            jobBoxUpdate(bureauTextBox.Text, gradeTextBox.Text);
            nameViewUpdate2(bureauTextBox.Text, gradeTextBox.Text, jobBox.SelectedItem.ToString(), jobBox2.SelectedItem.ToString());
            activeCellUpdate();
            sendButton.Enabled = true;
        }

        private void bulJimu_Click(object sender, EventArgs e)
        {
            bureauTextBox.Text = "事務";
            sendButton.Enabled = false;
            jobBoxUpdate(bureauTextBox.Text, gradeTextBox.Text);
            nameViewUpdate2(bureauTextBox.Text, gradeTextBox.Text, jobBox.SelectedItem.ToString(),jobBox2.SelectedItem.ToString());
            activeCellUpdate();
            sendButton.Enabled = true;
        }

        private void graAll_Click(object sender, EventArgs e)
        {
            gradeTextBox.Text = "全";
            sendButton.Enabled = false;
            jobBoxUpdate(bureauTextBox.Text, gradeTextBox.Text);
            nameViewUpdate2(bureauTextBox.Text, gradeTextBox.Text, jobBox.SelectedItem.ToString(), jobBox2.SelectedItem.ToString());
            activeCellUpdate();
            sendButton.Enabled = true;
        }

        private void gra1_Click(object sender, EventArgs e)
        {
            gradeTextBox.Text = "1";
            sendButton.Enabled = false;
            jobBoxUpdate(bureauTextBox.Text, gradeTextBox.Text);
            nameViewUpdate2(bureauTextBox.Text, gradeTextBox.Text, jobBox.SelectedItem.ToString(),jobBox2.SelectedItem.ToString());
            activeCellUpdate();
            sendButton.Enabled = true;
        }

        private void gra2_Click(object sender, EventArgs e)
        {
            gradeTextBox.Text = "2";
            sendButton.Enabled = false;
            jobBoxUpdate(bureauTextBox.Text, gradeTextBox.Text);
            nameViewUpdate2(bureauTextBox.Text, gradeTextBox.Text, jobBox.SelectedItem.ToString(), jobBox2.SelectedItem.ToString());
            activeCellUpdate();
            sendButton.Enabled = true;
        }

        private void gra3_Click(object sender, EventArgs e)
        {
            gradeTextBox.Text = "3";
            sendButton.Enabled = false;
            jobBoxUpdate(bureauTextBox.Text, gradeTextBox.Text);
            nameViewUpdate2(bureauTextBox.Text, gradeTextBox.Text, jobBox.SelectedItem.ToString(), jobBox2.SelectedItem.ToString());
            activeCellUpdate();
            sendButton.Enabled = true;
        }

        private void gra4_Click(object sender, EventArgs e)
        {
            gradeTextBox.Text = "4";
            sendButton.Enabled = false;
            jobBoxUpdate(bureauTextBox.Text, gradeTextBox.Text);
            nameViewUpdate2(bureauTextBox.Text, gradeTextBox.Text, jobBox.SelectedItem.ToString(), jobBox2.SelectedItem.ToString());
            activeCellUpdate();
            sendButton.Enabled = true;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string buf = (string)nameView.CurrentRow.Cells[4].Value;
            if (buf == "×")
            {
                this.Activated -= new EventHandler(EnterName_Activated);
                DialogResult result = MessageBox.Show((string)nameView.CurrentRow.Cells[3].Value + "さんは存在します。\r\n続行しますか？",
            "確認",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.OK)
                        {
                            activerange.Value2 = nameView.CurrentRow.Cells[3].Value;
                            this.Activated += new EventHandler(EnterName_Activated);
                        }
                        else if (result == DialogResult.Cancel)
                        {
                    this.Activated += new EventHandler(EnterName_Activated);
                    return;
                        }
                    }

            activerange.Value2 = nameView.CurrentRow.Cells[3].Value;
        }

        private void cellRight_Click(object sender, EventArgs e)
        {
            
            activerange =book.Application.ActiveCell;
            activerange.Interior.ColorIndex = 0;
            int Row = activerange.MergeArea.Row;
            int Column = activerange.MergeArea.Column;

            Column+= activerange.MergeArea.Columns.Count;
            Excel.Range tmp = jobsheet.Cells[Row, Column];
            tmp.Activate();
            tmp.MergeArea.Select();
            tmp.MergeArea.Interior.ColorIndex = 38;

        }
        private void cellLeft_Click(object sender, EventArgs e)
        {

            activerange = book.Application.ActiveCell;
            activerange.Interior.ColorIndex = 0;
            int Row = activerange.MergeArea.Row;
            int Column = activerange.MergeArea.Column;
            Column--;
            Excel.Range tmp = jobsheet.Cells[Row, Column];
            Column = tmp.MergeArea.Column;
            tmp = jobsheet.Cells[Row, Column];
            tmp.Activate();
            tmp.MergeArea.Select();
            tmp.MergeArea.Interior.ColorIndex = 38;
        }
        private void cellUp_Click(object sender, EventArgs e)
        {
            activerange = book.Application.ActiveCell;
            activerange.Interior.ColorIndex = 0;
            int Row = activerange.MergeArea.Row;
            int Column = activerange.MergeArea.Column;
            Row--;
            Excel.Range tmp = jobsheet.Cells[Row, Column];
            Column = tmp.MergeArea.Column;
            tmp = jobsheet.Cells[Row, Column];
            tmp.Activate();
            tmp.MergeArea.Select();
            tmp.MergeArea.Interior.ColorIndex = 38;
        }
        private void cellDown_Click(object sender, EventArgs e)
        {

            activerange = book.Application.ActiveCell;
            activerange.Interior.ColorIndex = 0;
            int Row = activerange.MergeArea.Row;
            int Column = activerange.MergeArea.Column;
            Row++;
            Excel.Range tmp = jobsheet.Cells[Row, Column];
            Column = tmp.MergeArea.Column;
            tmp = jobsheet.Cells[Row, Column];
            tmp.Activate();
            tmp.MergeArea.Select();
            tmp.MergeArea.Interior.ColorIndex = 38;
        }
        private void viewUpdate_Click(object sender, EventArgs e)
        {
            nameViewUpdate2(bureauTextBox.Text, gradeTextBox.Text, jobBox.SelectedItem.ToString(), jobBox2.SelectedItem.ToString());
            activeCellUpdate();
        }
        #endregion

    }
}
