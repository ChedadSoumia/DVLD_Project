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
        private int _LicenseID;
       


        private void _LoadDesign()
        {
            clsDesign.MainLabelTitleDesign(lblMainTitle);
            clsDesign.ButtonCloseStyle(btnClose);

        }
        public frmDriverLicenseInfo(int LicenseInfo)
        {
            InitializeComponent();
            _LoadDesign();
            _LicenseID=LicenseInfo;
        }

        private void frmDriverLicenseInfo_Load(object sender, EventArgs e)
        {
            
            ctrlDriverLicenseInfo1.LoadLicenseInfo(_LicenseID);
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
