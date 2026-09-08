using DVDL.Global_Classes;
using DVDL.License;
using DVDL.People;
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
    public partial class frmExpiredLicenses : Form
    {
        private DataTable _ExpiredLicensesList;
        private void _LoadDesign()
        {
            clsDesign.MainLabelTitleDesign(lblMainTitle);
        }
        public frmExpiredLicenses()
        {
            InitializeComponent();
        }

        private void frmExpiredLicenses_Load(object sender, EventArgs e)
        {
            _ExpiredLicensesList = clsDashboard.ExpiredLicensesList();
            dgvExpiredLicensesList.DataSource = _ExpiredLicensesList;
            lblRecordsCount.Text = dgvExpiredLicensesList.Rows.Count.ToString();
        }

        private void reToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo personInfo = new frmShowPersonInfo((int)dgvExpiredLicensesList.CurrentRow.Cells[0].Value);
            personInfo.ShowDialog();
        }

        private void renewLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalDrivingLicense RenewLocalDrivingLicense = new frmRenewLocalDrivingLicense();
            RenewLocalDrivingLicense.ShowDialog();
        }
    }
}
