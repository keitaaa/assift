using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Shiftwork.Library;

namespace Shiftwork
{
    public partial class AttachForm : Form
    {
        static private Excel.Workbook book;
        static private bool isOpen;

        public AttachForm(Excel.Workbook book)
        {
            InitializeComponent();
            AttachForm.book = book;
            isOpen = UpdateList();
        }

        private bool UpdateList()
        {
            string[] process = null;
            try
            {
                process = book.ListBook();
            }
            catch (NullReferenceException ne)
            {
                string errorMessage;
                errorMessage = "Error: ";
                errorMessage = string.Concat(errorMessage, ne.Message);
                errorMessage = string.Concat(errorMessage, "\nLine: ");
                errorMessage = string.Concat(errorMessage, ne.Source);
                errorMessage = string.Concat(errorMessage, "\n");
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            ProcesscomboBox.Items.AddRange(process);
            ProcesscomboBox.SelectedIndex = 0;

            return true;
        }
        private void AttachButton_Click(object sender, EventArgs e)
        {
            try
            {
                book = book.setBook(ProcesscomboBox.SelectedItem.ToString());
            }
            catch (NullReferenceException ne)
            {
                string errorMessage;
                errorMessage = "Error: ";
                errorMessage = string.Concat(errorMessage, ne.Message);
                errorMessage = string.Concat(errorMessage, "\nLine: ");
                errorMessage = string.Concat(errorMessage, ne.Source);
                errorMessage = string.Concat(errorMessage, "\n");
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static Excel.Workbook ShowForm(Excel.Workbook book)
        {
            AttachForm f = new AttachForm(book);
            if(!isOpen)
            {
                f.Dispose();
                return null;
            }
            f.ShowDialog();
            f.Dispose();
            return AttachForm.book;
        }
    }
}
