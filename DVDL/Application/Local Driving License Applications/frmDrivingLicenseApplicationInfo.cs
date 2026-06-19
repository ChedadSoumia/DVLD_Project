using DVDL.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL.Application.Local_Driving_License_Applications
{
    public partial class frmDrivingLicenseApplicationInfo : Form
    {


        void _LoadDesign()
        {
            Design.ButtonCloseStyle(btnClose);
        }

        public frmDrivingLicenseApplicationInfo(int LocalLicenseDrivingApplicationID)
        {
            InitializeComponent();
            _LoadDesign();
            ctrlDrivingLicenseApplicationInfo1.LoadLocalLicenseDrivingAppliactionInfo(LocalLicenseDrivingApplicationID);

        }

      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
