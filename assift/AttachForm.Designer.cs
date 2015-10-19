namespace Shiftwork
{
    partial class AttachForm
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
            this.AttachButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ProcesscomboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // AttachButton
            // 
            this.AttachButton.Location = new System.Drawing.Point(62, 45);
            this.AttachButton.Name = "AttachButton";
            this.AttachButton.Size = new System.Drawing.Size(77, 28);
            this.AttachButton.TabIndex = 0;
            this.AttachButton.Text = "アタッチ";
            this.AttachButton.UseVisualStyleBackColor = true;
            this.AttachButton.Click += new System.EventHandler(this.AttachButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(146, 45);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(77, 28);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "キャンセル";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ProcesscomboBox
            // 
            this.ProcesscomboBox.FormattingEnabled = true;
            this.ProcesscomboBox.Location = new System.Drawing.Point(15, 12);
            this.ProcesscomboBox.Name = "ProcesscomboBox";
            this.ProcesscomboBox.Size = new System.Drawing.Size(257, 20);
            this.ProcesscomboBox.TabIndex = 2;
            // 
            // AttachForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 85);
            this.ControlBox = false;
            this.Controls.Add(this.ProcesscomboBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AttachButton);
            this.Name = "AttachForm";
            this.Text = "Select Process...";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AttachButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.ComboBox ProcesscomboBox;
    }
}