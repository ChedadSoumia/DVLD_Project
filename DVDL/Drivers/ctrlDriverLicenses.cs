using DVDL.License;
using DVDL_business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL.Drivers
{
    public partial class ctrlDriverLicenses : UserControl
    {
        private DataTable _dtAllLocalLicenses;
        private DataTable _dtAllInternationalLicenses;
        private int _DriverID = -1;
        private clsDriver _DriverInfo;
      

        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        private void ctrlDriverLicenses_Load(object sender, EventArgs e)
        {
    
        }



        private void _LoadLocalLicensesInfo()
        {
            _dtAllLocalLicenses = clsDriver.GetLicenses(_DriverID);
            dgvAllLocalLicenses.DataSource = _dtAllLocalLicenses;

            lblCountLocalLicenses.Text = _dtAllLocalLicenses.Rows.Count.ToString();
        }

        public void LoadDriverLicensesInfoByDriverID(int DriverID)
        {
            _DriverID = DriverID;
            _DriverInfo = clsDriver.FindByID(DriverID);
            if (_DriverInfo == null)
            {
                MessageBox.Show("There is No driver with ID = " + _DriverID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _LoadLocalLicensesInfo();

        }

        public void LoadDriverLicensesInfoByPersonID(int PersonID)
        {
            
            _DriverInfo = clsDriver.FindByPersonID(PersonID);

            if (_DriverInfo == null)
            {
                MessageBox.Show("There is No driver with person ID = " + PersonID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _DriverID = _DriverInfo.DriverID;
            
            _LoadLocalLicensesInfo();

        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDriverLicenseInfo LicenseInfo = new frmDriverLicenseInfo((int)dgvAllLocalLicenses.CurrentRow.Cells[0].Value);
            LicenseInfo.ShowDialog();
        }
    }
}
