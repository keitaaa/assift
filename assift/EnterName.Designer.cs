namespace Shiftwork
{
    partial class EnterName
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bulGroup = new System.Windows.Forms.GroupBox();
            this.bulShisetu = new System.Windows.Forms.Button();
            this.bulJimu = new System.Windows.Forms.Button();
            this.bulSoushoku = new System.Windows.Forms.Button();
            this.bulKoho = new System.Windows.Forms.Button();
            this.bulKikaku = new System.Windows.Forms.Button();
            this.bulShikko = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bulAll = new System.Windows.Forms.Button();
            this.graGroup = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gra4 = new System.Windows.Forms.Button();
            this.gra3 = new System.Windows.Forms.Button();
            this.gra2 = new System.Windows.Forms.Button();
            this.gra1 = new System.Windows.Forms.Button();
            this.graAll = new System.Windows.Forms.Button();
            this.jobGroup = new System.Windows.Forms.GroupBox();
            this.jobBox = new System.Windows.Forms.ComboBox();
            this.nameView = new System.Windows.Forms.DataGridView();
            this.bureauTextBox = new System.Windows.Forms.TextBox();
            this.gradeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.bulColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.posColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.graColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emptyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bulGroup.SuspendLayout();
            this.graGroup.SuspendLayout();
            this.jobGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nameView)).BeginInit();
            this.SuspendLayout();
            // 
            // bulGroup
            // 
            this.bulGroup.Controls.Add(this.bulShisetu);
            this.bulGroup.Controls.Add(this.bulJimu);
            this.bulGroup.Controls.Add(this.bulSoushoku);
            this.bulGroup.Controls.Add(this.bulKoho);
            this.bulGroup.Controls.Add(this.bulKikaku);
            this.bulGroup.Controls.Add(this.bulShikko);
            this.bulGroup.Controls.Add(this.groupBox2);
            this.bulGroup.Controls.Add(this.bulAll);
            this.bulGroup.Location = new System.Drawing.Point(16, 25);
            this.bulGroup.Name = "bulGroup";
            this.bulGroup.Size = new System.Drawing.Size(314, 52);
            this.bulGroup.TabIndex = 0;
            this.bulGroup.TabStop = false;
            this.bulGroup.Text = "局";
            // 
            // bulShisetu
            // 
            this.bulShisetu.Location = new System.Drawing.Point(226, 12);
            this.bulShisetu.Name = "bulShisetu";
            this.bulShisetu.Size = new System.Drawing.Size(38, 34);
            this.bulShisetu.TabIndex = 18;
            this.bulShisetu.Text = "施設";
            this.bulShisetu.UseVisualStyleBackColor = true;
            this.bulShisetu.Click += new System.EventHandler(this.bulShisetu_Click);
            // 
            // bulJimu
            // 
            this.bulJimu.Location = new System.Drawing.Point(270, 12);
            this.bulJimu.Name = "bulJimu";
            this.bulJimu.Size = new System.Drawing.Size(38, 34);
            this.bulJimu.TabIndex = 19;
            this.bulJimu.Text = "事務";
            this.bulJimu.UseVisualStyleBackColor = true;
            this.bulJimu.Click += new System.EventHandler(this.bulJimu_Click);
            // 
            // bulSoushoku
            // 
            this.bulSoushoku.Location = new System.Drawing.Point(178, 12);
            this.bulSoushoku.Name = "bulSoushoku";
            this.bulSoushoku.Size = new System.Drawing.Size(38, 34);
            this.bulSoushoku.TabIndex = 16;
            this.bulSoushoku.Text = "装飾";
            this.bulSoushoku.UseVisualStyleBackColor = true;
            this.bulSoushoku.Click += new System.EventHandler(this.bulSoushoku_Click);
            // 
            // bulKoho
            // 
            this.bulKoho.Location = new System.Drawing.Point(88, 12);
            this.bulKoho.Name = "bulKoho";
            this.bulKoho.Size = new System.Drawing.Size(38, 34);
            this.bulKoho.TabIndex = 15;
            this.bulKoho.Text = "広報";
            this.bulKoho.UseVisualStyleBackColor = true;
            this.bulKoho.Click += new System.EventHandler(this.bulKoho_Click);
            // 
            // bulKikaku
            // 
            this.bulKikaku.Location = new System.Drawing.Point(132, 12);
            this.bulKikaku.Name = "bulKikaku";
            this.bulKikaku.Size = new System.Drawing.Size(38, 34);
            this.bulKikaku.TabIndex = 17;
            this.bulKikaku.Text = "企画";
            this.bulKikaku.UseVisualStyleBackColor = true;
            this.bulKikaku.Click += new System.EventHandler(this.bulKikaku_Click);
            // 
            // bulShikko
            // 
            this.bulShikko.Location = new System.Drawing.Point(41, 12);
            this.bulShikko.Name = "bulShikko";
            this.bulShikko.Size = new System.Drawing.Size(38, 34);
            this.bulShikko.TabIndex = 14;
            this.bulShikko.Text = "執行";
            this.bulShikko.UseVisualStyleBackColor = true;
            this.bulShikko.Click += new System.EventHandler(this.bulShikko_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(27, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // bulAll
            // 
            this.bulAll.Location = new System.Drawing.Point(6, 24);
            this.bulAll.Name = "bulAll";
            this.bulAll.Size = new System.Drawing.Size(29, 22);
            this.bulAll.TabIndex = 3;
            this.bulAll.Text = "全";
            this.bulAll.UseVisualStyleBackColor = true;
            this.bulAll.Click += new System.EventHandler(this.bulAll_Click);
            // 
            // graGroup
            // 
            this.graGroup.Controls.Add(this.groupBox4);
            this.graGroup.Controls.Add(this.gra4);
            this.graGroup.Controls.Add(this.gra3);
            this.graGroup.Controls.Add(this.gra2);
            this.graGroup.Controls.Add(this.gra1);
            this.graGroup.Controls.Add(this.graAll);
            this.graGroup.Location = new System.Drawing.Point(16, 83);
            this.graGroup.Name = "graGroup";
            this.graGroup.Size = new System.Drawing.Size(314, 52);
            this.graGroup.TabIndex = 2;
            this.graGroup.TabStop = false;
            this.graGroup.Text = "学年";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(27, 106);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 100);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // gra4
            // 
            this.gra4.Location = new System.Drawing.Point(247, 12);
            this.gra4.Name = "gra4";
            this.gra4.Size = new System.Drawing.Size(59, 34);
            this.gra4.TabIndex = 9;
            this.gra4.Text = "4年";
            this.gra4.UseVisualStyleBackColor = true;
            this.gra4.Click += new System.EventHandler(this.gra4_Click);
            // 
            // gra3
            // 
            this.gra3.Location = new System.Drawing.Point(180, 12);
            this.gra3.Name = "gra3";
            this.gra3.Size = new System.Drawing.Size(59, 34);
            this.gra3.TabIndex = 10;
            this.gra3.Text = "3年";
            this.gra3.UseVisualStyleBackColor = true;
            this.gra3.Click += new System.EventHandler(this.gra3_Click);
            // 
            // gra2
            // 
            this.gra2.Location = new System.Drawing.Point(113, 12);
            this.gra2.Name = "gra2";
            this.gra2.Size = new System.Drawing.Size(59, 34);
            this.gra2.TabIndex = 11;
            this.gra2.Text = "2年";
            this.gra2.UseVisualStyleBackColor = true;
            this.gra2.Click += new System.EventHandler(this.gra2_Click);
            // 
            // gra1
            // 
            this.gra1.Location = new System.Drawing.Point(46, 12);
            this.gra1.Name = "gra1";
            this.gra1.Size = new System.Drawing.Size(59, 34);
            this.gra1.TabIndex = 12;
            this.gra1.Text = "1年";
            this.gra1.UseVisualStyleBackColor = true;
            this.gra1.Click += new System.EventHandler(this.gra1_Click);
            // 
            // graAll
            // 
            this.graAll.Location = new System.Drawing.Point(6, 24);
            this.graAll.Name = "graAll";
            this.graAll.Size = new System.Drawing.Size(29, 22);
            this.graAll.TabIndex = 13;
            this.graAll.Text = "全";
            this.graAll.UseVisualStyleBackColor = true;
            this.graAll.Click += new System.EventHandler(this.graAll_Click);
            // 
            // jobGroup
            // 
            this.jobGroup.Controls.Add(this.jobBox);
            this.jobGroup.Location = new System.Drawing.Point(16, 141);
            this.jobGroup.Name = "jobGroup";
            this.jobGroup.Size = new System.Drawing.Size(314, 52);
            this.jobGroup.TabIndex = 14;
            this.jobGroup.TabStop = false;
            this.jobGroup.Text = "仕事";
            // 
            // jobBox
            // 
            this.jobBox.FormattingEnabled = true;
            this.jobBox.Location = new System.Drawing.Point(41, 18);
            this.jobBox.Name = "jobBox";
            this.jobBox.Size = new System.Drawing.Size(265, 20);
            this.jobBox.TabIndex = 0;
            // 
            // nameView
            // 
            this.nameView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.nameView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bulColumn,
            this.posColumn,
            this.graColumn,
            this.nameColumn,
            this.emptyColumn});
            this.nameView.Location = new System.Drawing.Point(9, 224);
            this.nameView.MultiSelect = false;
            this.nameView.Name = "nameView";
            this.nameView.ReadOnly = true;
            this.nameView.RowTemplate.Height = 21;
            this.nameView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.nameView.Size = new System.Drawing.Size(314, 263);
            this.nameView.TabIndex = 15;
            // 
            // bureauTextBox
            // 
            this.bureauTextBox.Enabled = false;
            this.bureauTextBox.Location = new System.Drawing.Point(16, 199);
            this.bureauTextBox.Name = "bureauTextBox";
            this.bureauTextBox.Size = new System.Drawing.Size(62, 19);
            this.bureauTextBox.TabIndex = 16;
            // 
            // gradeTextBox
            // 
            this.gradeTextBox.Enabled = false;
            this.gradeTextBox.Location = new System.Drawing.Point(107, 199);
            this.gradeTextBox.Name = "gradeTextBox";
            this.gradeTextBox.Size = new System.Drawing.Size(62, 19);
            this.gradeTextBox.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "局";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "年 の結果を表示しています。";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(144, 493);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(59, 19);
            this.sendButton.TabIndex = 14;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // bulColumn
            // 
            this.bulColumn.DataPropertyName = "bulColumn";
            this.bulColumn.HeaderText = "局";
            this.bulColumn.Name = "bulColumn";
            this.bulColumn.Width = 55;
            // 
            // posColumn
            // 
            this.posColumn.DataPropertyName = "posColumn";
            this.posColumn.HeaderText = "役職";
            this.posColumn.Name = "posColumn";
            this.posColumn.Width = 55;
            // 
            // graColumn
            // 
            this.graColumn.DataPropertyName = "graColumn";
            this.graColumn.HeaderText = "年";
            this.graColumn.Name = "graColumn";
            this.graColumn.Width = 20;
            // 
            // nameColumn
            // 
            this.nameColumn.DataPropertyName = "nameColumn";
            this.nameColumn.HeaderText = "名前";
            this.nameColumn.Name = "nameColumn";
            // 
            // emptyColumn
            // 
            this.emptyColumn.DataPropertyName = "emptyColumn";
            this.emptyColumn.HeaderText = "空";
            this.emptyColumn.Name = "emptyColumn";
            this.emptyColumn.Width = 20;
            // 
            // EnterName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 524);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gradeTextBox);
            this.Controls.Add(this.bureauTextBox);
            this.Controls.Add(this.nameView);
            this.Controls.Add(this.jobGroup);
            this.Controls.Add(this.graGroup);
            this.Controls.Add(this.bulGroup);
            this.Name = "EnterName";
            this.Text = "名前入れ";
            this.Load += new System.EventHandler(this.EnterName_Load);
            this.bulGroup.ResumeLayout(false);
            this.graGroup.ResumeLayout(false);
            this.jobGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nameView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox bulGroup;
        private System.Windows.Forms.Button bulShisetu;
        private System.Windows.Forms.Button bulSoushoku;
        private System.Windows.Forms.Button bulKoho;
        private System.Windows.Forms.Button bulKikaku;
        private System.Windows.Forms.Button bulShikko;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bulAll;
        private System.Windows.Forms.GroupBox graGroup;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button gra4;
        private System.Windows.Forms.Button gra3;
        private System.Windows.Forms.Button gra2;
        private System.Windows.Forms.Button gra1;
        private System.Windows.Forms.Button graAll;
        private System.Windows.Forms.Button bulJimu;
        private System.Windows.Forms.GroupBox jobGroup;
        private System.Windows.Forms.ComboBox jobBox;
        private System.Windows.Forms.DataGridView nameView;
        private System.Windows.Forms.TextBox bureauTextBox;
        private System.Windows.Forms.TextBox gradeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn bulColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn posColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn graColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emptyColumn;
    }
}