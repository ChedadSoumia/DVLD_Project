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
    public partial class frmNewInternationalDrivingLicenseApplicaiton : Form
    {


        private void _LoadDesign()
        {
            Design.MainLabelTitleDesign(lblMainTitle);
            Design.DataButtonDesign(btnSave);
            Design.ButtonCloseStyle(btnClose);
        }
        public frmNewInternationalDrivingLicenseApplicaiton()
        {
            InitializeComponent();
            _LoadDesign();
        }

        
    }
}
