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
        public int jobtype { get; } = 600;
        public int startaddr_col { get; } = 3;
        public int startaddr_row { get; } = 24;


        #endregion 

        public bool inProrgamUse { get; set; }

        Excel.Workbook book;
        Excel.Sheets sheets;

        string[,] namelist;

        #region menuStrip1

        #region fileMenuStrip
        private void AttachProcess_Click(object sender, EventArgs e)
        {
            book = AttachForm.ShowForm(book);
            if (book != null)
            {
                AttachProcess.Enabled = false;
                DettachProcess.Enabled = true;
                toolStripStatusLabel1.Text = "Attached.  " + book.Name;
                tabControl1.Enabled = true;

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
            string bookName = book.Name;
            book = book.closeBook();
            if (book == null)
            {
                AttachProcess.Enabled = true;
                DettachProcess.Enabled = false;
                toolStripStatusLabel1.Text = "Dettached.  " + bookName;
                tabControl1.Enabled = false;

                sheets = null;
            }
        }
        private void Close_Click(object sender, EventArgs e)
        {
            if (book != null)
            {
                book = book.closeBook();
            }
            this.Close();
        }
        #endregion //fileMenuStrip

        #region TBD
        private void Function1_Click(object sender, EventArgs e)
        {
            book.SheetDeactivate += new Excel.WorkbookEvents_SheetDeactivateEventHandler(Book_SheetDeactivate);
        }

        private void Book_SheetDeactivate(object Sh)
        {
            MessageBox.Show(book.Application.ActiveCell.get_Address());
        }

        private void allPaste_Click(object sender, EventArgs e)
        {
            MainForm._MainFormInstance = this;
            AllPasteFormula.Run(book);
        }
        
        private void allCheck_Click(object sender, EventArgs e)
        {
            MainForm._MainFormInstance = this;
            AllCheck.Run(book);
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
            EnterName f2 = new EnterName(namelist, book);
            _MainFormInstance = this;
            f2.ShowDialog();
        }



        #endregion

        private void jobToShift_Click(object sender, EventArgs e)
        {
            MainForm._MainFormInstance = this;
            JobToShift.Run(book);
        }

        private void allCheckNew_Click(object sender, EventArgs e)
        {
            MainForm._MainFormInstance = this;
            AllCheck.Run(book);
        }

        private void allPasteFormula_Click(object sender, EventArgs e)
        {
            MainForm._MainFormInstance = this;
            AllPasteFormula.Run(book);
        }

        private void UnmergeShift_Click(object sender, EventArgs e)
        {
            MainForm._MainFormInstance = this;
            Shiftwork.Payload.UnmergeShift.Run(book);
        }
    }
}
