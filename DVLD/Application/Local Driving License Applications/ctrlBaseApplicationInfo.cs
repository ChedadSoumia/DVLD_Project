using DVDL.Global_Classes;
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
using static System.Net.Mime.MediaTypeNames;

namespace DVDL.Application.Local_Driving_License_Applications
{
    public partial class ctrlBaseApplicationInfo : UserControl
    {
        int _ApplicationID = -1;
        clsApplication _ApplicationInfo;

        public ctrlBaseApplicationInfo()
        {
            InitializeComponent();
        }
        public void ResetApplicationInfo() {
            _ApplicationID = -1;

            lblAppliactionID.Text = "[????]";
            lblAppliactionStatus.Text = "[????]";
            lblApplicationType.Text = "[????]";
            lblApplicationFees.Text = "[????]";
            lblApplicant.Text = "[????]";
            lblAppliactionDate.Text = "[????]";
            lblStatusDate.Text = "[????]";
            lblCreatedByUser.Text = "[????]";
        }
        void _FillApplicationInfo() {
            _ApplicationID = _ApplicationInfo.ApplicationID;
            lblAppliactionID.Text = _ApplicationInfo.ApplicationID.ToString();
            lblAppliactionStatus.Text = _ApplicationInfo.StatusText;
            lblApplicationType.Text = _ApplicationInfo.ApplicationTypeInfo.ApplicationTypeTitle;
            lblApplicationFees.Text = _ApplicationInfo.PaidFees.ToString();
            lblApplicant.Text = _ApplicationInfo.ApplicantFullName;
            lblAppliactionDate.Text = clsFormat.DateToShort(_ApplicationInfo.ApplicationDate);
            lblStatusDate.Text = clsFormat.DateToShort(_ApplicationInfo.LastStatusDate);
            lblCreatedByUser.Text = _ApplicationInfo.CreatedByUserInfo.UserName;
        }

        public void LoadBaseApplicationInfo(int ApplicationID)
        {
            _ApplicationInfo = clsApplication.FindBaseApplication(ApplicationID);
            if (_ApplicationInfo == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                _FillApplicationInfo();

        }

        private void lblViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo ApplicantInfo = new frmShowPersonInfo(_ApplicationInfo.ApplicantPersonID);
            ApplicantInfo.ShowDialog();
            LoadBaseApplicationInfo(_ApplicationID);
        }
    }
}
