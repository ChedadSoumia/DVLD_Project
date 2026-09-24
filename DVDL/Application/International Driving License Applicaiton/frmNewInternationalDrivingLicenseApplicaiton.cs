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

        private int _SelectedInternationalLicenseID = -1;

        private void _LoadDesign()
        {
            clsDesign.MainLabelTitleDesign(lblMainTitle);
            clsDesign.DataButtonDesign(btnSave);
            clsDesign.ButtonCloseStyle(btnClose);
        }
        public frmNewInternationalDrivingLicenseApplicaiton()
        {
            InitializeComponent();
            _LoadDesign();
        }

        private void frmNewInternationalDrivingLicenseApplicaiton_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblApplicationDate.Text;
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(clsSettings.GetInternationalLicenseValidityLength()));
            lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.eNewInternationalLicense).ApplicationTypeFees.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedInternationalLicenseID = obj;
            llShowLicenseHistory.Enabled = (_SelectedInternationalLicenseID != -1);
            if(_SelectedInternationalLicenseID == -1)
            {
                return;
            }

            lblLocalLicenseID.Text = _SelectedInternationalLicenseID.ToString();

            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClass != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("this license not Active");
                btnSave.Enabled = false;
                return;
            }


            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ExpirationDate < DateTime.Now)
            {
                MessageBox.Show("license is died");
                btnSave.Enabled = false;
                return;
            }

            int ActiveInternationalLicenseID = clsInternationalDrivingLicenseApplicaiton.GetActiveInternationalLicenseIDByDriverID(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID);

            if (ActiveInternationalLicenseID != -1)
            {
                MessageBox.Show("Person already have an active international license with ID = " + ActiveInternationalLicenseID.ToString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _SelectedInternationalLicenseID = ActiveInternationalLicenseID;
                llShowLicenseHistory.Enabled = true;
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
            frmDriverLicenseInfo licenseInfo = new frmDriverLicenseInfo(_SelectedInternationalLicenseID);
            licenseInfo.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_SelectedInternationalLicenseID == -1)
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
            internationalDrivingLicenseApplicaiton.IssuedUsingLocalLicenseID = _SelectedInternationalLicenseID;
            internationalDrivingLicenseApplicaiton.IssueDate = DateTime.Now;
            internationalDrivingLicenseApplicaiton.ExpirationDate = internationalDrivingLicenseApplicaiton.IssueDate.AddYears(clsSettings.GetInternationalLicenseValidityLength());
            internationalDrivingLicenseApplicaiton.IsActive = true;



            if (!internationalDrivingLicenseApplicaiton.Save())
            {
                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            
                lblApplicationID.Text = internationalDrivingLicenseApplicaiton.ApplicationID.ToString();
                lblInternationalLicenseID.Text = internationalDrivingLicenseApplicaiton.InternationalLicenseID.ToString();
                _SelectedInternationalLicenseID = internationalDrivingLicenseApplicaiton.InternationalLicenseID;

                lblAppInfo.Enabled = true;
                btnSave.Enabled = false;
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
                MessageBox.Show("International License Issued Successfully with ID=" + internationalDrivingLicenseApplicaiton.InternationalLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
    }
}
