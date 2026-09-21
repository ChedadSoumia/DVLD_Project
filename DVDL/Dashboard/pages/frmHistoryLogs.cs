using DVDL.Global_Classes;
using DVDL.User;
using DVDL_business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL.Dashboard.pages
{
    public partial class frmHistoryLogs : Form
    {
        public frmHistoryLogs()
        {
            InitializeComponent();
            clsDesign.DataGridViewDesign(dgvHistoryLogs);
            clsDesign.MainLabelTitleDesign(lblMainTitle);
        }

        private void frmHistoryLogs_Load(object sender, EventArgs e)
        {
            dgvHistoryLogs.DataSource = clsSettings.LoginUsersHistory();
            lblRecordsCount.Text = dgvHistoryLogs.Rows.Count.ToString();

        }

        private void renewLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo userInfo = new frmUserInfo((int)dgvHistoryLogs.CurrentRow.Cells[2].Value);
            userInfo.ShowDialog();
        }
    }
}
