using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyResource
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'zTestAA09DailyResourceAppDataSet1.DailyResource' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'zTestAA09DailyResourceAppDataSet.DailyResource' table. You can move, or remove it, as needed.
            this.DailyResourceTableAdapter.Fill(this.zTestAA09DailyResourceAppDataSet.DailyResource);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


    }
}
