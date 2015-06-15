using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shiftwork
{
    public partial class AttachForm : Form
    {
        public AttachForm()
        {
            InitializeComponent();
        }

        private void ProcesscomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AttachButton_Click(object sender, EventArgs e)
        {
            string[] process = app.ListApps();

            foreach (string s in process)
            {
                ProcesscomboBox.Items.Add(s);
                ProcesscomboBox.SelectedIndex = 0;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
