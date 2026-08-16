using DVDL.Global_Classes;
using DVDL.People;
using DVDL.People.Controls;
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

namespace DVDL.Application.Local_Driving_License_Applications
{
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {

        int _LocalLicenseDrivingApplicationID = -1;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplicationInfo;

        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
            
        }


        private void _ResetLocalDrivingLicenseApplicationInfo()
        {
            _LocalLicenseDrivingApplicationID = -1;
            ctrlBaseApplicationInfo1.ResetApplicationInfo();
            lblLocalAppID.Text = "[????]";
            lblLicenseClassName.Text = "[????]";


        }

        public void LoadLocalLicenseDrivingAppliactionInfo(int localLicenseDrivingApplicationID)
        {
            _LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplication.FindlocalDrivingLicenceApplicationID(localLicenseDrivingApplicationID);

            if (_LocalDrivingLicenseApplicationInfo == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();
                MessageBox.Show("No Application with ID = " + _LocalLicenseDrivingApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _LoadLocalDrivingLicenseApplicationGroupBox();
        }

        public void LoadAppliactionInfo(int ApplicationID)
        {
            _LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplication.FindByApplicationID(ApplicationID);

            if (_LocalDrivingLicenseApplicationInfo == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();
                MessageBox.Show("No Application with ID = " + _LocalLicenseDrivingApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _LoadLocalDrivingLicenseApplicationGroupBox();
        }




        private void _LoadLocalDrivingLicenseApplicationGroupBox() {

            lblLocalAppID.Text = _LocalDrivingLicenseApplicationInfo.LocalDrivingLicenceApplicationID.ToString();
            lblLicenseClassName.Text = clsLicenseClasses.Find(_LocalDrivingLicenseApplicationInfo.LicenseClassID).ClassName;
            ctrlBaseApplicationInfo1.LoadBaseApplicationInfo(_LocalDrivingLicenseApplicationInfo.ApplicationID);
            
        }

        private void lblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDrivingLicenseApplicationInfo LicenseInfo = new frmDrivingLicenseApplicationInfo(_LocalLicenseDrivingApplicationID);

        }
    }
}
