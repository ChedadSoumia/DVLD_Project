using DVDL.Global_Classes;
using DVDL_business;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVDL_business.clsApplication;

namespace DVDL.Application.Local_Driving_License_Applications
{
    public partial class frmNewLocalDrivingLicenseApplications : Form
    {

        enum enMode { eAddNew = 0,eUpdate = 1}
        enMode _Mode = enMode.eAddNew;

        int _LocalDrivingLicenseApplicationID = -1;
        int _SelectedPersonID = -1;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;


        int ApplicantPersonID = -1;
        

        public frmNewLocalDrivingLicenseApplications()
        {
            InitializeComponent();
            _Mode = enMode.eAddNew;
        }

        public frmNewLocalDrivingLicenseApplications(int localDrivingLicenseApplicationId)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationId;
            _Mode = enMode.eUpdate;
        }

        void _FillLicenseClassesInComoboBox()
        {
            DataTable dtLicenseClasses = clsLicenseClasses.GetAllLicenseClasses();
            foreach(DataRow row in dtLicenseClasses.Rows)
            {
                comboBox1.Items.Add(row["ClassName"]);
            }
            

        }

        void _ResetDefaultValue()
        {
            _FillLicenseClassesInComoboBox();
            if( _Mode == enMode.eAddNew)
            {
                lblMainTitle.Text = "Add New Local Driving Application.";
                this.Text = "Add New Local Driving Application";
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                tpApplicationInfo.Enabled = false;

                comboBox1.SelectedIndex = 2;
                ctrlPersonCardWithFilter1.FilterFocus();
                lblLocalAppID.Text = "[???]";
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.eNewDrivingLicense).ApplicationTypeFees.ToString();
                lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;

            }
            else
            {
                tpApplicationInfo.Enabled = true;
                lblMainTitle.Text = "Update Local Driving Application.";
                this.Text = "Update Local Driving Application";

            }
        }
        void _LoadData()
        {
            ctrlPersonCardWithFilter1.FilterEnable = false;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindlocalDrivingLicenceApplicationID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            ctrlPersonCardWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);
            lblLocalAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenceApplicationID.ToString();
            lblApplicationDate.Text = clsFormat.DateToShort(_LocalDrivingLicenseApplication.ApplicationDate);
            comboBox1.SelectedIndex = comboBox1.FindString(clsLicenseClasses.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName);
            _LocalDrivingLicenseApplication.CreatedByUserInfo = clsUser.Find(_LocalDrivingLicenseApplication.CreatedByUserID);
            lblCreatedBy.Text = _LocalDrivingLicenseApplication.CreatedByUserInfo.UserName;


        }

        private void DataBackEvent(object sender, int PersonID)
        {
            // Handle the data received
            _SelectedPersonID = PersonID;
            ctrlPersonCardWithFilter1.LoadPersonInfo(PersonID);


        }

        private void frmNewLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();
            if (_Mode == enMode.eUpdate)
                _LoadData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.eUpdate)
            {
                tpApplicationInfo.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tpApplicationInfo"];
                return;
            }

            if (ctrlPersonCardWithFilter1.PersonID == -1) {
                MessageBox.Show("Selected a person", "Select a person", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ctrlPersonCardWithFilter1.FilterFocus();
            }
            else
            {
                tpApplicationInfo.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tpApplicationInfo"];
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            
            int licenseClassesID = clsLicenseClasses.Find(comboBox1.Text).LicenseClassID;

            int ActiveApplicationID = clsApplication.PersonHasALicenseClassApplication(_SelectedPersonID, 
                                                        clsApplication.enApplicationType.eNewDrivingLicense,
                                                        _LocalDrivingLicenseApplication.LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
                return;
            }


            //---------------------------------------------------------------------------------------------------------------------------
            //---------------------------------------------------------------------------------------------------------------------------
            //---------------------------------------------------------------------------------------------------------------------------

            // there is another function here 
            // check if user already have issued license of the same driving  class.

            if (clsLicenses.IsLicenseExistByPersonID(ctrlPersonCardWithFilter1.PersonID,licenseClassesID))
            {
                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //---------------------------------------------------------------------------------------------------------------------------
            //---------------------------------------------------------------------------------------------------------------------------

            _LocalDrivingLicenseApplication.ApplicantPersonID = ctrlPersonCardWithFilter1.PersonID;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            

            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.eNew;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            
            _LocalDrivingLicenseApplication.ApplicationTypeID = 1;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblApplicationFees.Text);
            _LocalDrivingLicenseApplication.LicenseClassID = licenseClassesID;

            if (_LocalDrivingLicenseApplication.Save())
            {
                lblLocalAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenceApplicationID.ToString();
                _Mode = enMode.eUpdate;
                lblMainTitle.Text = "Update Local Driving Application.";
                this.Text = "Update Local Driving Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }

        private void frmNewLocalDrivingLicenseApplications_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();
        }
    }
}
