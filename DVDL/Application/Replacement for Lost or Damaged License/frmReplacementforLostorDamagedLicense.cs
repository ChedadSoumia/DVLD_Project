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
    public partial class frmReplacementforLostorDamagedLicense : Form
    {

        private int _ReplacedLicenseID = -1;

        private clsApplication.enApplicationType _ReplacementCause = clsApplication.enApplicationType.eReplaceDamagedDrivingLicense;
        public clsApplication.enApplicationType ReplacementCause
        {
            get { return _ReplacementCause; }
            set
            {
                _ReplacementCause = value;
                switch (_ReplacementCause) 
                {
                    case clsApplication.enApplicationType.eReplaceDamagedDrivingLicense:
                        lblMainTitle.Text = "Replacement For Damaged License";
                        this.Text = "Replacement For Damaged License";
                        lblApplicationFees.Text = clsApplicationType.Find((int)_ReplacementCause).ApplicationTypeFees.ToString();
                        break;
                    case clsApplication.enApplicationType.eReplaceLostDrivingLicense:
                        lblMainTitle.Text = "Replacement For Lost License";
                        this.Text = "Replacement For Lost License";
                        lblApplicationFees.Text = clsApplicationType.Find((int)_ReplacementCause).ApplicationTypeFees.ToString();
                        break;
                }
            }
        }


        private void _MyDesign()
        {
            Design.MainLabelTitleDesign(lblMainTitle);
            Design.ButtonCloseStyle(btnClose);
            Design.DataButtonDesign(btnIssueReplacment);
        }
        public frmReplacementforLostorDamagedLicense()
        {
            InitializeComponent();
            _MyDesign();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            llShowLicenseHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
                return;



            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacment.Enabled = false;
                return;
            }

            btnIssueReplacment.Enabled = true;
        }

        private void frmReplacementforLostorDamagedLicense_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
            if (rbDamagedLicense.Checked)
            {
                ReplacementCause = clsApplication.enApplicationType.eReplaceDamagedDrivingLicense;
            }
            else
            {
                ReplacementCause = clsApplication.enApplicationType.eReplaceLostDrivingLicense;
            }

            lblCreatedBY.Text = clsGlobal.CurrentUser.UserName;
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            ReplacementCause = clsApplication.enApplicationType.eReplaceDamagedDrivingLicense;
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            ReplacementCause = clsApplication.enApplicationType.eReplaceLostDrivingLicense;
        }

        private void frmReplacementforLostorDamagedLicense_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
        }

        private void btnIssueReplacment_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to replace the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicenses ReplacementLicense =
                ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ReplacmentLicence(ReplacementCause, clsGlobal.CurrentUser.UserID);


            if (ReplacementLicense == null)
            {
                MessageBox.Show("Faild to replace the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }


            lblNewApplicationID.Text = ReplacementLicense.ApplicationID.ToString();
            _ReplacedLicenseID = ReplacementLicense.LicenseID;
            lblReplacedLicenseID.Text = _ReplacedLicenseID.ToString();
            MessageBox.Show("Licensed replaced Successfully with ID=" + _ReplacedLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);


            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            btnIssueReplacment.Enabled = false;
            lblNewAppInfo.Enabled = true;

        }

        private void lblNewAppInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo RenewLicenseInfo = new frmDriverLicenseInfo(_ReplacedLicenseID);
            RenewLicenseInfo.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
