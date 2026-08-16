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

namespace DVDL.Application.International_Driving_License_Applicaiton
{
    public partial class frmInternationalDrivingLicenseApplicaiton : Form
    {

        private int _InternationalLicenseID = -1;


        private void _LoadDate()
        {
            clsDesign.MainLabelTitleDesign(lblMainTitle);
            clsDesign.ButtonCloseStyle(btnClose);
        }

        public frmInternationalDrivingLicenseApplicaiton(int InternationalLicenseID)
        {
            InitializeComponent();
            _LoadDate();
            _InternationalLicenseID = InternationalLicenseID;
        }

        private void frmInternationalDrivingLicenseApplicaiton_Load(object sender, EventArgs e)
        {
            if (_InternationalLicenseID == -1)
                return;
            ctrlInternationalDrivingLicenseApplicaiton1.LoadInternationalInfo(_InternationalLicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
