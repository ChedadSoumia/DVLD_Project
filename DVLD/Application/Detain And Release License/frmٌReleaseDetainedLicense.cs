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

namespace DVDL.Application.Replacement_for_Lost_or_Damaged_License
{
    public partial class frmٌReleaseDetainedLicense : Form
    {

        private int _SelectedLicenseID = -1;

        private void _LoadDesign()
        {
            clsDesign.MainLabelTitleDesign(lblMainTitle);
            clsDesign.DataButtonDesign(btnRelease);
            clsDesign.ButtonCloseStyle(btnClose);

        }

        public frmٌReleaseDetainedLicense()
        {
            InitializeComponent();
            _LoadDesign();
        }

        public frmٌReleaseDetainedLicense(int DetainLicenseID)
        {
            InitializeComponent();
            _LoadDesign();
            _SelectedLicenseID = DetainLicenseID;
            ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfoWithFilter(_SelectedLicenseID);
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;
            llShowLicenseHistory.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1) 
            {
                return;
            }

            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License i is not detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.eReleaseDetainedDrivingLicense).ApplicationTypeFees.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            
            lblDetainID.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainInfo.DetainID.ToString();
            lblLicenseID.Text = _SelectedLicenseID.ToString();

            lblDetainDate.Text = clsFormat.DateToShort(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainInfo.DetainDate);
            lblFineFees.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainInfo.FineFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblFineFees.Text)).ToString();

            btnRelease.Enabled = true;



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

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this detained  license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            int ApplicationID = -1;

            bool IsReleased = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ReleaseDetainedLicense(clsGlobal.CurrentUser.UserID, ref ApplicationID);

            if (!IsReleased)
            {
                MessageBox.Show("Faild to to release the Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Detained License released Successfully ", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            lblApplicationID.Text = ApplicationID.ToString();

            btnRelease.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            lblAppInfo.Enabled = true;
        }
    }
}
