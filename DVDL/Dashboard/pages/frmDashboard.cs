using DVDL.Global_Classes;
using DVDL_business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL.Dashboard.pages
{
    public partial class frmDashboard : Form
    {

        public void _LoadDesign()
        {
            clsDesign.DataGridViewDesign(dataGridView1);
            clsDesign.MainLabelTitleDesign(lblMainTitle);
        }
        public frmDashboard()
        {
            InitializeComponent();
            _LoadDesign();
        }
        private void _LoadAnalyseeAppliactionTable()
        {
            dataGridView1.DataSource = clsDashboard.AnalyseeAppliactionTable();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "AppType.ID";
                dataGridView1.Columns[0].Width = 50;

                dataGridView1.Columns[1].HeaderText = "App.Title";
                dataGridView1.Columns[1].Width = 190;



                dataGridView1.Columns[2].HeaderText = "All App";
                dataGridView1.Columns[2].Width = 70;

                dataGridView1.Columns[3].HeaderText = "New App";
                dataGridView1.Columns[3].Width = 70;

                dataGridView1.Columns[4].HeaderText = "Cancelled App";
                dataGridView1.Columns[4].Width = 80;

                dataGridView1.Columns[5].HeaderText = "Completed App";
                dataGridView1.Columns[5].Width = 80;



                }
            }
        private void frmDashboard_Load(object sender, EventArgs e)
        {

            _LoadAnalyseeAppliactionTable();
            lblCountPeople.Text = clsDashboard.CountPerson().ToString();
            lblCountUsers.Text = clsDashboard.CountUsers().ToString();
            lblDrivers.Text = clsDashboard.CountDrivers().ToString();
            lblCountActiveLicense.Text = clsDashboard.CountActiveLicenses().ToString();
            lblCountNewApplication.Text = clsDashboard.CountNewApplication().ToString();
            lblCencelledApplication.Text = clsDashboard.CancelledApplication().ToString();
            lblCountCompleteApplication.Text = clsDashboard.CompletedApplication().ToString();
            lblCountApplications.Text = clsDashboard.CountApplication().ToString();
            lblExpiredLicenses.Text = clsDashboard.CountExpiredLicenses().ToString();
        }

        private void tableLayoutPanel9_Click(object sender, EventArgs e)
        {
            frmExpiredLicenses expiredLicensesList = new frmExpiredLicenses();
            expiredLicensesList.ShowDialog();
        }
    }
}
