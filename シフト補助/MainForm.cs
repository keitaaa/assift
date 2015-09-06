using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Shiftwork.Library;

namespace Shiftwork
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "Ready.";
        }

        public static MainForm _MainFormInstance { get; set; }
        public Boolean duplicateCheckBoxValue { get; set; }
        public Boolean autoBackupBoxValue { get; set; }
        public Boolean pasteasFormulaBoxValue { get; set; }


        Excel.Application app;
        Excel.Workbook book;

        #region menuStrip1

        #region fileMenuStrip
        private void AttachProcess_Click(object sender, EventArgs e)
        {
            app = AttachForm.ShowForm(app);
            if (app != null)
            {
                AttachProcess.Enabled = false;
                DettachProcess.Enabled = true;
                toolStripStatusLabel1.Text = "Attached.  " + app.ActiveWorkbook.Name;
                tabControl1.Enabled = true;

                book = app.ActiveWorkbook;
            }
        }
        private void DettachProcess_Click(object sender, EventArgs e)
        {
            string s = app.ActiveWorkbook.Name;
            app = app.closeApp();
            if (app == null)
            {
                AttachProcess.Enabled = true;
                DettachProcess.Enabled = false;
                toolStripStatusLabel1.Text = "Dettached.  " + s;
                tabControl1.Enabled = false;

                book = null;
            }
        }
        private void Close_Click(object sender, EventArgs e)
        {
            if (app != null)
            {
                app = app.closeApp();
                book = null;
            }
            this.Close();
        }
        #endregion //fileMenuStrip

        #region TBD
        private void Function1_Click(object sender, EventArgs e)
        {
            //app.ListApps();
            //app = app.setApps("Book1");
            //Excel.Range test = app.Selection;
            //MessageBox.Show("test.");
            //app.closeApp();
        }
        #endregion //TBD
        #endregion //menuStrip1


        #region tabPage1
        private void startMonitorButton_Click(object sender, EventArgs e)
        {
            startMonitorButton.Enabled = false;
            stopMonitiorButton.Enabled = true;
            showInputBox.Enabled = true;

            book.SheetChange += new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetChangeEventHandler(Payload.SheetChange.sheetChanged);
            duplicateCheckBox.Enabled = false;
            pasteasFormulaBox.Enabled = false;
            autoBackupBox.Enabled = false;
            MainForm._MainFormInstance = this;
        }

        private void stopMonitiorButton_Click(object sender, EventArgs e)
        {

        }

        #endregion
        



        

        

        


    }
}
