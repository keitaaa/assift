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
        }

        Excel.Application app;
        private void button1_Click(object sender, EventArgs e)
        {
            app.ListApps();
            app = app.setApps("Book1");
            Excel.Range test = app.Selection;

            test.ColumnDuplicateCheck();

            //foreach (String r in test.columnToString())
            //{
            //    MessageBox.Show(r);
            //}

        }


    }
}
