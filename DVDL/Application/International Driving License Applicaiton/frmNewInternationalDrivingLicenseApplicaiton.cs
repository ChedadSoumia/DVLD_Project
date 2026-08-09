using DVDL.Drivers;
using DVDL.Global_Classes;
using DVDL.License;
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

namespace DVDL.Application.International_Driving_License_Applicaiton
{
    public partial class frmNewInternationalDrivingLicenseApplicaiton : Form
    {

        private int _SelectedLicenseID = -1;
        private clsLicenses _SelectedLicenseInfo;

        private void _LoadDesign()
        {
            Design.MainLabelTitleDesign(lblMainTitle);
            Design.DataButtonDesign(btnSave);
            Design.ButtonCloseStyle(btnClose);
        }
        public frmNewInternationalDrivingLicenseApplicaiton()
        {
            InitializeComponent();
            _LoadDesign();
        }

        private void frmNewInternationalDrivingLicenseApplicaiton_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(1));
            lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.eNewInternationalLicense).ApplicationTypeFees.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;
            llShowLicenseHistory.Enabled = (_SelectedLicenseID != -1);
            if(_SelectedLicenseID == -1)
            {
                return;
            }
            _SelectedLicenseInfo = clsLicenses.Find(_SelectedLicenseID);

            lblLocalLicenseID.Text = _SelectedLicenseID.ToString();

            if (!_SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("this license not Active");
                btnSave.Enabled = false;
                return;
            }

            if (_SelectedLicenseInfo.ExpirationDate < DateTime.Now)
            {
                MessageBox.Show("license is died");
                btnSave.Enabled = false;
                return;
            }

            int InternationalLicenseID = clsInternationalDrivingLicenseApplicaiton.GetActiveInternationalLicenseIDByDriverID(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID);

            if (InternationalLicenseID != -1)
            {
                MessageBox.Show("this license already has an international driving license with ID:" + InternationalLicenseID);
                btnSave.Enabled = false;
                return;
            }

            btnSave.Enabled = true;

        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonLicenseHistory licenseHistory = new frmPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            licenseHistory.ShowDialog();
        }

        private void lblAppInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo licenseInfo = new frmDriverLicenseInfo(_SelectedLicenseID);
            licenseInfo.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_SelectedLicenseID == -1)
            {
                MessageBox.Show("Select a license");
                return;
            }

            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsInternationalDrivingLicenseApplicaiton internationalDrivingLicenseApplicaiton = new clsInternationalDrivingLicenseApplicaiton();

            internationalDrivingLicenseApplicaiton.ApplicantPersonID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            internationalDrivingLicenseApplicaiton.ApplicationDate = DateTime.Now;
            internationalDrivingLicenseApplicaiton.ApplicationStatus = clsApplication.enApplicationStatus.eCompleted;
            internationalDrivingLicenseApplicaiton.ApplicationTypeID = (int)clsApplication.enApplicationType.eNewInternationalLicense;
            internationalDrivingLicenseApplicaiton.PaidFees = Convert.ToSingle(lblFees.Text);
            internationalDrivingLicenseApplicaiton.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            internationalDrivingLicenseApplicaiton.DriverID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID;
            internationalDrivingLicenseApplicaiton.IssuedUsingLocalLicenseID = _SelectedLicenseID;
            internationalDrivingLicenseApplicaiton.IssueDate = DateTime.Now;
            internationalDrivingLicenseApplicaiton.ExpirationDate = internationalDrivingLicenseApplicaiton.IssueDate.AddYears(1);
            internationalDrivingLicenseApplicaiton.IsActive = true;


            if (internationalDrivingLicenseApplicaiton.Save())
            {
                lblApplicationID.Text = internationalDrivingLicenseApplicaiton.ApplicationID.ToString();
                lblInternationalLicenseID.Text = internationalDrivingLicenseApplicaiton.InternationalLicenseID.ToString();
                lblAppInfo.Enabled = true;
                btnSave.Enabled = false;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
