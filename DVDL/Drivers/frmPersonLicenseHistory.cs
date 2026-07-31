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

namespace DVDL.Drivers
{
    public partial class frmPersonLicenseHistory : Form
    {
        private int _DriverID=-1;
        private clsDriver _DriverInfo;
        private void _LoadDesign()
        {
            Design.ButtonCloseStyle(btnClose);
            Design.MainLabelTitleDesign(lblMainTitle);

        }
        public frmPersonLicenseHistory(int DriverID)
        {
            InitializeComponent();
            _LoadDesign();
            _DriverID = DriverID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            _DriverInfo = clsDriver.FindByID(_DriverID);
            ctrlPersonCardWithFilter1.LoadPersonInfo(_DriverInfo.PersonID);
            ctrlPersonCardWithFilter1.FilterEnable = false;
            ctrlDriverLicenses1.LoadDriverLicensesInfoByDriverID(_DriverID);
        }
    }
}
