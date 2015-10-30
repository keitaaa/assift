using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Shiftwork.Library;
using Shiftwork.Payload;
//hal
namespace Shiftwork
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "Ready.";
        }

        #region 他インスタンスからの参照用

        /// <summary>
        /// メインフォームインスタンスの複製
        /// </summary>
        public static MainForm _MainFormInstance { get; set; }
        public bool duplicateCheckBoxValue
        {
            get
            {
                return duplicateCheckBox.Checked;
            }
        }
        public bool autoBackupBoxValue
        {
            get
            {
                return autoBackupBox.Checked;
            }
        }
        public bool pasteasFormulaBoxValue
        {
            get
            {
                return pasteasFormulaBox.Checked;
            }
        }
        public int jobtype { get; } = 500;
        public int startaddr_col { get; } = 3;
        public int startaddr_row { get; } = 24;


        #endregion 

        public bool inProrgamUse { get; set; }

        Excel.Application app;
        Excel.Workbook book;
        Excel.Sheets sheets;

        string[,] namelist;

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
                sheets = book.Worksheets;
                namelist = getNamelist();
            }
        }
        private string[,] getNamelist()
        {
            // TODO:例外追加
            Excel.Worksheet namesheet;
            namesheet = (Excel.Worksheet)sheets.get_Item(sheets.getSheetIndex("構成員名簿"));
            Excel.Range namerange;
            namerange = namesheet.get_Range("A2", "Q204");
            return namerange.DeepToString();
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
                sheets = null;
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

        private void allPaste_Click(object sender, EventArgs e)
        {
            MainForm._MainFormInstance = this;
            AllPasteFormula.Run(app);
        }
        #endregion //TBD
        #endregion //menuStrip1


        #region tabPage1
        private void startMonitorButton_Click(object sender, EventArgs e)
        {
            startMonitorButton.Enabled = false;
            stopMonitiorButton.Enabled = true;
            showInputBox.Enabled = true;

            book.SheetChange += new Excel.WorkbookEvents_SheetChangeEventHandler(Payload.SheetChange.sheetChanged);
            duplicateCheckBox.Enabled = false;
            pasteasFormulaBox.Enabled = false;
            autoBackupBox.Enabled     = false;
            MainForm._MainFormInstance = this;
        }

        private void stopMonitiorButton_Click(object sender, EventArgs e)
        {
            startMonitorButton.Enabled = true;
            stopMonitiorButton.Enabled = false;
            showInputBox.Enabled = false;

            book.SheetChange -= new Excel.WorkbookEvents_SheetChangeEventHandler(Payload.SheetChange.sheetChanged);
            duplicateCheckBox.Enabled = true;
            pasteasFormulaBox.Enabled = true;
            autoBackupBox.Enabled     = true;
            MainForm._MainFormInstance = this;
        }

        private void showInputBox_Click(object sender, EventArgs e)
        {
            EnterName f2 = new EnterName(namelist, app);
            _MainFormInstance = this;
            f2.ShowDialog();
        }


        #endregion


    }
}
