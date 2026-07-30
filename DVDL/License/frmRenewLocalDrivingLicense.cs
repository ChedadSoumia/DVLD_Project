using DVDL.Global_Classes;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVDL.License
{
    public partial class frmRenewLocalDrivingLicense : Form
    {

        private int _LicenseID = -1;
        private clsLicenses _LicenseInfo ;

        private void _MyDesign()
        {
            Design.MainLabelTitleDesign(lblMainTitle);
            Design.ButtonCloseStyle(btnClose);
            Design.DataButtonDesign(btnRenew);
        }

        public frmRenewLocalDrivingLicense()
        {
            InitializeComponent();
            _MyDesign();
        }

        private void frmRenewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
        }

        private void _LoadOldLicenseData()
        {
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblNewIssueDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblApplicationFees.Text = clsApplicationType.Find(2).ApplicationTypeFees.ToString();
            lblLicenseFees.Text = _LicenseInfo.LicenseClassesInfo.ClassFees.ToString();
            lblOldLicenseID.Text = _LicenseInfo.LicenseID.ToString();
            lblCreatedBY.Text = clsGlobal.CurrentUser.UserName;
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(_LicenseInfo.LicenseClassesInfo.DefaultValidityLength));
            lblTotal.Text = (Convert.ToSingle(lblLicenseFees.Text) + Convert.ToSingle(lblApplicationFees.Text)).ToString();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _LicenseID = obj;
            _LicenseInfo = clsLicenses.Find(_LicenseID);
            if(DateTime.Now < _LicenseInfo.ExpirationDate)
            {
                MessageBox.Show("Selected License is not Expired, ON: " + clsFormat.DateToShort(_LicenseInfo.ExpirationDate));
                btnRenew.Enabled = false;
                    
            }
            else
            {
                btnRenew.Enabled = true;
                _LoadOldLicenseData();


            }

        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew this License?", "Confirm Renew", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            


                if (_LicenseInfo.RenewLicence(txtNotes.Text.Trim(), Convert.ToSingle(lblTotal.Text), clsGlobal.CurrentUser.UserID))
            {
                
                MessageBox.Show("the license was Renew " + _LicenseInfo.LicenseID.ToString(), "Renew", MessageBoxButtons.OK, MessageBoxIcon.Question);
                lblNewApplicationID.Text = _LicenseInfo.ApplicationID.ToString();
                lblNewAppInfo.Enabled= true;
                lblNewLicenseID.Text = _LicenseInfo.LicenseID.ToString();
            }
            else
            {
                MessageBox.Show("Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblNewAppInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo RenewLicenseInfo = new frmDriverLicenseInfo(_LicenseInfo.LicenseID);
            RenewLicenseInfo.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
