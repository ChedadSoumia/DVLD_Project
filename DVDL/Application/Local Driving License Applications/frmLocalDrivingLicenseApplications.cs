using DVDL.Application.Local_Driving_License_Applications;
using DVDL.Global_Classes;
using DVDL.License;
using DVDL.Test;
using DVDL_business;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL.Application
{
    public partial class frmLocalDrivingLicenseApplications : Form
    {
        private DataTable _AllLocalApplications;

        public frmLocalDrivingLicenseApplications()
        {
            InitializeComponent();
            _MyDesign();
        }

        private void _MyDesign()
        {
            Design.DataGridViewDesign(dgvAllLocalApplications);
            Design.DataButtonDesign(btnAddApplication);
            Design.labelDesign(label1);
            Design.labelDesign(label2);
            Design.labelDesign(lblRecordsCount);
            Design.DataTextBoxDesign(txtFilter);
            Design.StyleComboBox(comboBox1);
            comboBox1.SelectedText = "None";
            Design.MainLabelTitleDesign(lblMainTitle);
            comboBox1.SelectedIndex = 0;

        }

        private void frmLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _AllLocalApplications = clsApplication.GetAllApplications();

            dgvAllLocalApplications.DataSource = _AllLocalApplications;
            lblRecordsCount.Text = dgvAllLocalApplications.Rows.Count.ToString();
        }

        private void btnAddApplication_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseApplications NewLocalDrivingLicenseApplication = new frmNewLocalDrivingLicenseApplications();
            NewLocalDrivingLicenseApplication.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplications_Load(null, null);
            txtFilter.Visible = (comboBox1.Text != "None");
            txtFilter.Text = "";
            txtFilter.Focus();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(comboBox1.Text == "L.D.L. AppID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (comboBox1.Text)
            {
                case "L.D.L. AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;
                case "National No.":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Status":
                    FilterColumn = "Status";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if(txtFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _AllLocalApplications.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvAllLocalApplications.Rows.Count.ToString();
                return;
            }

            if(FilterColumn == "LocalDrivingLicenseApplicationID")
            {
                _AllLocalApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            }
            else
            {
                _AllLocalApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtFilter.Text.Trim());
            }
            lblRecordsCount.Text = dgvAllLocalApplications.Rows.Count.ToString();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseApplications UpdateLocalApplication = new frmNewLocalDrivingLicenseApplications((int)dgvAllLocalApplications.CurrentRow.Cells[0].Value);
            UpdateLocalApplication.ShowDialog();
            frmLocalDrivingLicenseApplications_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LocalDrivingLicenseApplicationID = (int)dgvAllLocalApplications.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindlocalDrivingLicenceApplicationID(LocalDrivingLicenseApplicationID);

            if (localDrivingLicenseApplication != null)
            {
                if (localDrivingLicenseApplication.Delete())
                {
                    MessageBox.Show("Application  Delete Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //refresh the form again.
                    frmLocalDrivingLicenseApplications_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not delete applicatoin, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to Cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            int LocalDrivingLicenseApplicationID = (int)dgvAllLocalApplications.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindlocalDrivingLicenceApplicationID(LocalDrivingLicenseApplicationID);

            if (localDrivingLicenseApplication != null)
            {
                if (localDrivingLicenseApplication.Cancel())
                {
                    MessageBox.Show("Application Canceled Successfully.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //refresh the form again.
                    frmLocalDrivingLicenseApplications_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not Cancel applicatoin, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

            int LocalDrivingLicenseApplicationID = (int)dgvAllLocalApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                    clsLocalDrivingLicenseApplication.FindlocalDrivingLicenceApplicationID
                                                    (LocalDrivingLicenseApplicationID);
            int TotalPassedTests = (int)dgvAllLocalApplications.CurrentRow.Cells[5].Value;
            bool LicenseExists = LocalDrivingLicenseApplication.IsLicenseIssued();

            deleteToolStripMenuItem.Enabled = (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.eNew);
            editToolStripMenuItem.Enabled = !LicenseExists && (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.eNew);
            cancelApplicationToolStripMenuItem.Enabled = (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.eNew);

            sechduleTestsToolStripMenuItem.Enabled = !LicenseExists;
            
            bool PassVisionTest = LocalDrivingLicenseApplication.DoesPassTheTest(clsTestTypes.enTestType.VisionTest);
            bool PassWrittenTest = LocalDrivingLicenseApplication.DoesPassTheTest(clsTestTypes.enTestType.WrittenTest);
            bool PassStreetTest = LocalDrivingLicenseApplication.DoesPassTheTest(clsTestTypes.enTestType.StreetTest);

            sechduleTestsToolStripMenuItem.Enabled = (!PassVisionTest || !PassWrittenTest || !PassStreetTest) && (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.eNew);

            if (sechduleTestsToolStripMenuItem.Enabled)
            {
                sechduleVisionTestToolStripMenuItem.Enabled = !PassVisionTest;
                sechduleWrittenTestToolStripMenuItem.Enabled = PassVisionTest && !PassWrittenTest;
                sechduleStreetTestToolStripMenuItem.Enabled = PassVisionTest && PassWrittenTest && !PassStreetTest;
            }

            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = (TotalPassedTests == 3) && !LicenseExists ;

            showLicenseToolStripMenuItem.Enabled = LicenseExists;
        }

        private void showApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDrivingLicenseApplicationInfo drivingLicenseApplicationInfo =new frmDrivingLicenseApplicationInfo((int)dgvAllLocalApplications.CurrentRow.Cells[0].Value);
            drivingLicenseApplicationInfo.ShowDialog();
            frmLocalDrivingLicenseApplications_Load(null, null);
        }

        private void sechduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestAppointments TestLists = new frmTestAppointments((int)dgvAllLocalApplications.CurrentRow.Cells[0].Value,clsTestTypes.enTestType.VisionTest);
            TestLists.ShowDialog();
            frmLocalDrivingLicenseApplications_Load(null, null);
        }

        private void sechduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestAppointments TestLists = new frmTestAppointments((int)dgvAllLocalApplications.CurrentRow.Cells[0].Value, clsTestTypes.enTestType.WrittenTest);
            TestLists.ShowDialog();
            frmLocalDrivingLicenseApplications_Load(null, null);
        }

        private void sechduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestAppointments TestLists = new frmTestAppointments((int)dgvAllLocalApplications.CurrentRow.Cells[0].Value, clsTestTypes.enTestType.StreetTest);
            TestLists.ShowDialog();
            frmLocalDrivingLicenseApplications_Load(null, null);
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueDriverLicenseForTheFirstTime IssueDriverLicenseForTheFirstTime = new frmIssueDriverLicenseForTheFirstTime((int)dgvAllLocalApplications.CurrentRow.Cells[0].Value);
            IssueDriverLicenseForTheFirstTime.ShowDialog();
            frmLocalDrivingLicenseApplications_Load(null, null);

        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDriverLicenseInfo driverLicenseInfo = new frmDriverLicenseInfo((int)dgvAllLocalApplications.CurrentRow.Cells[0].Value);
            driverLicenseInfo.ShowDialog();
            frmLocalDrivingLicenseApplications_Load(null, null);
        }
    }
}
