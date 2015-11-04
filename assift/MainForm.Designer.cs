namespace Shiftwork
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.startMonitorButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AttachProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.DettachProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Close = new System.Windows.Forms.ToolStripMenuItem();
            this.TBDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Function1 = new System.Windows.Forms.ToolStripMenuItem();
            this.allPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.allCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプの表示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.assiftのバージョン情報ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.showInputBox = new System.Windows.Forms.Button();
            this.duplicateCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backupDuration = new System.Windows.Forms.NumericUpDown();
            this.pasteasFormulaBox = new System.Windows.Forms.CheckBox();
            this.autoBackupBox = new System.Windows.Forms.CheckBox();
            this.stopMonitiorButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backupDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // startMonitorButton
            // 
            this.startMonitorButton.Location = new System.Drawing.Point(63, 162);
            this.startMonitorButton.Margin = new System.Windows.Forms.Padding(4);
            this.startMonitorButton.Name = "startMonitorButton";
            this.startMonitorButton.Size = new System.Drawing.Size(132, 49);
            this.startMonitorButton.TabIndex = 0;
            this.startMonitorButton.Text = "監視の開始";
            this.startMonitorButton.UseVisualStyleBackColor = true;
            this.startMonitorButton.Click += new System.EventHandler(this.startMonitorButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.TBDToolStripMenuItem,
            this.ヘルプHToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(487, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AttachProcess,
            this.DettachProcess,
            this.toolStripSeparator1,
            this.Close});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.ファイルToolStripMenuItem.Text = "ファイル(F)";
            // 
            // AttachProcess
            // 
            this.AttachProcess.Name = "AttachProcess";
            this.AttachProcess.Size = new System.Drawing.Size(204, 26);
            this.AttachProcess.Text = "プロセスにアタッチ(A)";
            this.AttachProcess.Click += new System.EventHandler(this.AttachProcess_Click);
            // 
            // DettachProcess
            // 
            this.DettachProcess.Enabled = false;
            this.DettachProcess.Name = "DettachProcess";
            this.DettachProcess.Size = new System.Drawing.Size(204, 26);
            this.DettachProcess.Text = "アタッチを解除";
            this.DettachProcess.Click += new System.EventHandler(this.DettachProcess_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(201, 6);
            // 
            // Close
            // 
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(204, 26);
            this.Close.Text = "終了";
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // TBDToolStripMenuItem
            // 
            this.TBDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Function1,
            this.allPaste,
            this.allCheck});
            this.TBDToolStripMenuItem.Name = "TBDToolStripMenuItem";
            this.TBDToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.TBDToolStripMenuItem.Text = "開発中";
            // 
            // Function1
            // 
            this.Function1.Name = "Function1";
            this.Function1.Size = new System.Drawing.Size(241, 26);
            this.Function1.Text = "機能1";
            this.Function1.Click += new System.EventHandler(this.Function1_Click);
            // 
            // allPaste
            // 
            this.allPaste.Name = "allPaste";
            this.allPaste.Size = new System.Drawing.Size(241, 26);
            this.allPaste.Text = "すべてを数式として貼り付け";
            this.allPaste.Click += new System.EventHandler(this.allPaste_Click);
            // 
            // allCheck
            // 
            this.allCheck.Name = "allCheck";
            this.allCheck.Size = new System.Drawing.Size(241, 26);
            this.allCheck.Text = "すべての重複チェック";
            this.allCheck.Click += new System.EventHandler(this.allCheck_Click);
            // 
            // ヘルプHToolStripMenuItem
            // 
            this.ヘルプHToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ヘルプの表示ToolStripMenuItem,
            this.toolStripSeparator2,
            this.assiftのバージョン情報ToolStripMenuItem});
            this.ヘルプHToolStripMenuItem.Name = "ヘルプHToolStripMenuItem";
            this.ヘルプHToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.ヘルプHToolStripMenuItem.Text = "ヘルプ(H)";
            // 
            // ヘルプの表示ToolStripMenuItem
            // 
            this.ヘルプの表示ToolStripMenuItem.Name = "ヘルプの表示ToolStripMenuItem";
            this.ヘルプの表示ToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.ヘルプの表示ToolStripMenuItem.Text = "ヘルプの表示";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(215, 6);
            // 
            // assiftのバージョン情報ToolStripMenuItem
            // 
            this.assiftのバージョン情報ToolStripMenuItem.Name = "assiftのバージョン情報ToolStripMenuItem";
            this.assiftのバージョン情報ToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.assiftのバージョン情報ToolStripMenuItem.Text = "assift のバージョン情報";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 305);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(487, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(240, 21);
            this.toolStripStatusLabel1.Text = "Initializing...";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(133, 20);
            this.toolStripProgressBar1.Value = 78;
            this.toolStripProgressBar1.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(16, 34);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(455, 266);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.showInputBox);
            this.tabPage1.Controls.Add(this.duplicateCheckBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.backupDuration);
            this.tabPage1.Controls.Add(this.pasteasFormulaBox);
            this.tabPage1.Controls.Add(this.autoBackupBox);
            this.tabPage1.Controls.Add(this.stopMonitiorButton);
            this.tabPage1.Controls.Add(this.startMonitorButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(447, 237);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "監視";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // showInputBox
            // 
            this.showInputBox.Enabled = false;
            this.showInputBox.Location = new System.Drawing.Point(156, 22);
            this.showInputBox.Margin = new System.Windows.Forms.Padding(4);
            this.showInputBox.Name = "showInputBox";
            this.showInputBox.Size = new System.Drawing.Size(132, 49);
            this.showInputBox.TabIndex = 18;
            this.showInputBox.Text = "名前入れの開始";
            this.showInputBox.UseVisualStyleBackColor = true;
            this.showInputBox.Click += new System.EventHandler(this.showInputBox_Click);
            // 
            // duplicateCheckBox
            // 
            this.duplicateCheckBox.AutoSize = true;
            this.duplicateCheckBox.Checked = true;
            this.duplicateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.duplicateCheckBox.Location = new System.Drawing.Point(53, 79);
            this.duplicateCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.duplicateCheckBox.Name = "duplicateCheckBox";
            this.duplicateCheckBox.Size = new System.Drawing.Size(134, 19);
            this.duplicateCheckBox.TabIndex = 17;
            this.duplicateCheckBox.Text = "重複チェックを行う";
            this.duplicateCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(335, 135);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "分間隔";
            // 
            // backupDuration
            // 
            this.backupDuration.Location = new System.Drawing.Point(261, 130);
            this.backupDuration.Margin = new System.Windows.Forms.Padding(4);
            this.backupDuration.Name = "backupDuration";
            this.backupDuration.Size = new System.Drawing.Size(65, 22);
            this.backupDuration.TabIndex = 15;
            this.backupDuration.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // pasteasFormulaBox
            // 
            this.pasteasFormulaBox.AutoSize = true;
            this.pasteasFormulaBox.Checked = true;
            this.pasteasFormulaBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pasteasFormulaBox.Location = new System.Drawing.Point(53, 106);
            this.pasteasFormulaBox.Margin = new System.Windows.Forms.Padding(4);
            this.pasteasFormulaBox.Name = "pasteasFormulaBox";
            this.pasteasFormulaBox.Size = new System.Drawing.Size(151, 19);
            this.pasteasFormulaBox.TabIndex = 14;
            this.pasteasFormulaBox.Text = "数式として貼り付け...";
            this.pasteasFormulaBox.UseVisualStyleBackColor = true;
            // 
            // autoBackupBox
            // 
            this.autoBackupBox.AutoSize = true;
            this.autoBackupBox.Checked = true;
            this.autoBackupBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoBackupBox.Location = new System.Drawing.Point(53, 134);
            this.autoBackupBox.Margin = new System.Windows.Forms.Padding(4);
            this.autoBackupBox.Name = "autoBackupBox";
            this.autoBackupBox.Size = new System.Drawing.Size(187, 19);
            this.autoBackupBox.TabIndex = 13;
            this.autoBackupBox.Text = "自動バックアップを使用する";
            this.autoBackupBox.UseVisualStyleBackColor = true;
            // 
            // stopMonitiorButton
            // 
            this.stopMonitiorButton.Enabled = false;
            this.stopMonitiorButton.Location = new System.Drawing.Point(243, 162);
            this.stopMonitiorButton.Margin = new System.Windows.Forms.Padding(4);
            this.stopMonitiorButton.Name = "stopMonitiorButton";
            this.stopMonitiorButton.Size = new System.Drawing.Size(128, 49);
            this.stopMonitiorButton.TabIndex = 1;
            this.stopMonitiorButton.Text = "監視の停止";
            this.stopMonitiorButton.UseVisualStyleBackColor = true;
            this.stopMonitiorButton.Click += new System.EventHandler(this.stopMonitiorButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(447, 237);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "変換";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 331);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "assift";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backupDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startMonitorButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AttachProcess;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem DettachProcess;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem Close;
        private System.Windows.Forms.ToolStripMenuItem TBDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Function1;
        private System.Windows.Forms.ToolStripMenuItem ヘルプHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ヘルプの表示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem assiftのバージョン情報ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button stopMonitiorButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button showInputBox;
        private System.Windows.Forms.CheckBox duplicateCheckBox;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown backupDuration;
        private System.Windows.Forms.CheckBox pasteasFormulaBox;
        private System.Windows.Forms.CheckBox autoBackupBox;
        private System.Windows.Forms.ToolStripMenuItem allPaste;
        private System.Windows.Forms.ToolStripMenuItem allCheck;
    }
}

