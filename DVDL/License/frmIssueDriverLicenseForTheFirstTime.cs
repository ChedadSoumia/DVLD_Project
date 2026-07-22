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
    public partial class frmIssueDriverLicenseForTheFirstTime : Form
    {

        private clsLicenses _LicenseInfo;
        private int _LocalDrivingLicenseApplicationID = -1;

        private void _LoadDesign()
        {
            Design.ButtonCloseStyle(btnClose);
            Design.DataButtonDesign(btnIssue);
        }
        public frmIssueDriverLicenseForTheFirstTime(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LoadDesign();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIssueDriverLicenseForTheFirstTime_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseApplicationInfo1.LoadLocalLicenseDrivingAppliactionInfo(_LocalDrivingLicenseApplicationID);
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindlocalDrivingLicenceApplicationID(_LocalDrivingLicenseApplicationID);
            _LicenseInfo = new clsLicenses();
            _LicenseInfo.ApplicationID = localDrivingLicenseApplication.ApplicationID;

            if (!clsDriver.IsPersonADriver(localDrivingLicenseApplication.ApplicantPersonID))
            {
                clsDriver _Driver = new clsDriver();
                _Driver.PersonID = localDrivingLicenseApplication.ApplicantPersonID;
                _Driver.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                _Driver.CreatedDate = DateTime.Now;


                if (!_Driver.Save()){
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
            }

            _LicenseInfo.DriverID = clsDriver.FindByPersonID(localDrivingLicenseApplication.ApplicantPersonID).DriverID;
            _LicenseInfo.LicenseClass = localDrivingLicenseApplication.LicenseClassID;
            _LicenseInfo.IssueDate = DateTime.Now;
            _LicenseInfo.ExpirationDate = _LicenseInfo.IssueDate.AddYears(localDrivingLicenseApplication.LicenseClassInfo.DefaultValidityLength);
            _LicenseInfo.Notes = txtNotes.Text.Trim();
            _LicenseInfo.PaidFees = localDrivingLicenseApplication.LicenseClassInfo.ClassFees;
            _LicenseInfo.IsActive = true;
            _LicenseInfo.IssueReason = clsLicenses.enIssueReason.eFirstTime;
            _LicenseInfo.CreatedByUserID = clsGlobal.CurrentUser.UserID;



            if (_LicenseInfo.Save())
            {

                localDrivingLicenseApplication.SetComplete();
                MessageBox.Show("License issued Successfully with License ID = " + _LicenseInfo.LicenseID, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
    }
}
