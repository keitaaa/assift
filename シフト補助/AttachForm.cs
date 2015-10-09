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
    public partial class AttachForm : Form
    {
        static public Excel.Application app_a;
        static private bool isOpen;

        public AttachForm(Excel.Application app)
        {
            InitializeComponent();
            Shiftwork.AttachForm.app_a = app;
            isOpen = UpdateList();
        }

        private bool UpdateList()
        {
            try
            {
                string[] process_t = app_a.ListApps();
            }
            catch (NullReferenceException ne)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, ne.Message);
                errorMessage = String.Concat(errorMessage, "\nLine: ");
                errorMessage = String.Concat(errorMessage, ne.Source);
                errorMessage = String.Concat(errorMessage, "\n");
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK,
    MessageBoxIcon.Error);
                return false;
            }
            string[] process = app_a.ListApps();
            
            foreach (string s in process)
            {
                ProcesscomboBox.Items.Add(s);
                ProcesscomboBox.SelectedIndex = 0;
            }
            return true;
        }
        private void AttachButton_Click(object sender, EventArgs e)
        {
            try
            {
                app_a = app_a.setApps(ProcesscomboBox.SelectedItem.ToString());
            }
            catch (NullReferenceException ne)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, ne.Message);
                errorMessage = String.Concat(errorMessage, "\nLine: ");
                errorMessage = String.Concat(errorMessage, ne.Source);
                errorMessage = String.Concat(errorMessage, "\n");
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK,
    MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static Excel.Application ShowForm(Excel.Application app)
        {
            AttachForm f = new AttachForm(app);
            if(!isOpen)
            {
                f.Dispose();
                return null;
            }
            f.ShowDialog();
            f.Dispose();
            return app_a;
        }
    }
}
