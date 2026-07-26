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

namespace DVDL.License
{
    public partial class frmDriverLicenseInfo : Form
    {
        private int _LocalDrivingLicenseApplicationID;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;


        private void _LoadDesign()
        {
            Design.MainLabelTitleDesign(lblMainTitle);
            Design.ButtonCloseStyle(btnClose);

        }
        public frmDriverLicenseInfo(int localDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LoadDesign();
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
        }

        private void frmDriverLicenseInfo_Load(object sender, EventArgs e)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindlocalDrivingLicenceApplicationID(_LocalDrivingLicenseApplicationID);
            int LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();
            if (LicenseID != -1)
            {
                ctrlDriverLicenseInfo1.LoadLicenseInfo(LicenseID);
            }
            else
            {
                MessageBox.Show("No License with ID=" + LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }
    }
}
