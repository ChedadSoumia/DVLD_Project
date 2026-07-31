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
        private int _PersonID=-1;
        private void _LoadDesign()
        {
            Design.ButtonCloseStyle(btnClose);
            Design.MainLabelTitleDesign(lblMainTitle);

        }

        public frmPersonLicenseHistory()
        {
            InitializeComponent();
            _LoadDesign();
        }
        public frmPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _LoadDesign();
            _PersonID = PersonID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPersonLicenseHistory_Load(object sender, EventArgs e)
        {

            if(_PersonID != -1)
            {
                ctrlPersonCardWithFilter1.LoadPersonInfo(_PersonID);
                ctrlPersonCardWithFilter1.FilterEnable = false;
                ctrlDriverLicenses1.LoadDriverLicensesInfoByDriverID(_PersonID);
            }
            else
            {
                ctrlPersonCardWithFilter1.Enabled = true;
                ctrlPersonCardWithFilter1.Focus();
            }
            
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _PersonID = obj;
            if (_PersonID == -1)
            {
                ctrlDriverLicenses1.Clear();
            }
            else
                ctrlDriverLicenses1.LoadDriverLicensesInfoByPersonID(_PersonID);
        }
    }
}
