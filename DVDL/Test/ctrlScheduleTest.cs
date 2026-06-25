using DVDL.Global_Classes;
using DVDL_business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL.Test
{
    public partial class ctrlScheduleTest : UserControl
    {

        public enum enTestType { eVisionTest = 1, eWrittenTest =  2 ,eStreetTest= 3 }
        public enTestType TestType = enTestType.eVisionTest;

        private enum enMode {AddNew= 1,Update=2 }
        private enMode _Mode = enMode.AddNew;

        float FeesVisionTest = 0;
        float FeesRetakeApp = 0;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        int _TestAppointmentID = -1;
        clsTestAppointments _TestAppointmentInfo;

        private void _LoadDesign()
        {
            Design.DataButtonDesign(btnSave);
            Design.MainLabelTitleDesign(lblMainTitle);
        }

        public ctrlScheduleTest()
        {
            InitializeComponent();
            _LoadDesign();
            dtpDate.MinDate = DateTime.Now;
            dtpDate.Value = DateTime.Now;
        }
       
        public void ResetLocalDrivingLicenseApplicationInfo()
        {
            lblAppLocalID.Text = "[???]";
            lblApplicationType.Text = "[???]";
            lblFullName.Text = "[???]";
            lblTrial.Text = "[???]";
            dtpDate.MinDate = DateTime.Now;
            dtpDate.Value = DateTime.Now;
            lblFeesVisionTest.Text = "[???]";
            lblRetakeAppFees.Text = "[???]";
            lblRetakeAppID.Text = "[???]";
            lblTotalFees.Text = "[???]";
            groupBox2.Enabled = false;
        }


        private void _FillInfo(string TestTypeTitle)
        {
            groupBox1.Text = TestTypeTitle;

            lblAppLocalID.Text = _TestAppointmentInfo.LocalDrivingLicenseApplicationID.ToString();
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindlocalDrivingLicenceApplicationID(_TestAppointmentInfo.LocalDrivingLicenseApplicationID);
            lblApplicationType.Text = _LocalDrivingLicenseApplication.ApplicationTypeID.ToString();
            lblFullName.Text = _LocalDrivingLicenseApplication.ApplicantFullName;
            lblTrial.Text = _LocalDrivingLicenseApplication.TrialsTest((int)TestType).ToString();
            FeesVisionTest = clsTestTypes.Find((clsTestTypes.enTestType)TestType).TestTypeFees;
            lblFeesVisionTest.Text = FeesVisionTest.ToString();
            lblRetakeAppFees.Text = "[???]";
            lblRetakeAppID.Text = "[???]";
            lblTotalFees.Text = lblFeesVisionTest.Text;
            groupBox2.Enabled = false;
        }
        private void _FillLocalDrivingLicenseApplicationInfo()
        {
            switch (TestType)
            {
                case enTestType.eVisionTest:
                    _FillInfo("Vision Test");
                    break;
                case enTestType.eWrittenTest:
                    _FillInfo("Written Test");
                    break;
                case enTestType.eStreetTest:
                    _FillInfo("Street Test");
                    break;
            }
        }

        

        public void LoadDrivingLicenseApplicationInfo(int localDrivingLicenseApplicationID, enTestType testType )
        {
            _TestAppointmentInfo = new clsTestAppointments();
            _TestAppointmentInfo.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindlocalDrivingLicenceApplicationID(localDrivingLicenseApplicationID);
            TestType = testType;
            
            if (_LocalDrivingLicenseApplication == null)
            {
                ResetLocalDrivingLicenseApplicationInfo();
                MessageBox.Show("No Local Driving License application with ID. = " + localDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLocalDrivingLicenseApplicationInfo();

            if (!_LocalDrivingLicenseApplication.DoesPassTheTest((int)testType) && clsTestAppointments.GetLastTestAppointment(localDrivingLicenseApplicationID, (clsTestTypes.enTestType)testType) != null )
            {
                lblMainTitle.Text = "Retake Text";
                groupBox2.Enabled = true;
                clsLocalDrivingLicenseApplication RetakeApplication = new clsLocalDrivingLicenseApplication();
                RetakeApplication = _LocalDrivingLicenseApplication;

                RetakeApplication.Save();



                _TestAppointmentInfo.RetakeTestApplicationID = RetakeApplication.ApplicationID;
                lblRetakeAppID.Text = RetakeApplication.ApplicationID.ToString();
                FeesRetakeApp = clsApplicationType.Find(7).ApplicationTypeFees;
                lblRetakeAppFees.Text = FeesRetakeApp.ToString();
                lblTotalFees.Text =$"{FeesVisionTest + FeesRetakeApp}";
                





            }
            
        }
        public void LoadAppointmentInfo(int testAppointmentID)
        {
            
            _TestAppointmentID = testAppointmentID;
            _TestAppointmentInfo = clsTestAppointments.Find(testAppointmentID);
            if (_TestAppointmentInfo.IsLocked == true)
            {
                lblAppointmentLock.Visible = true;
                btnSave.Enabled = false;
                dtpDate.Enabled = false;
            }
            TestType = (enTestType)_TestAppointmentInfo.TestTypeID;
           
            if (_TestAppointmentInfo == null)
            {
                ResetLocalDrivingLicenseApplicationInfo();
                MessageBox.Show("No Appointment with ID. = " + testAppointmentID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillLocalDrivingLicenseApplicationInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            


            _TestAppointmentInfo.TestTypeID =(clsTestTypes.enTestType)TestType;
            _TestAppointmentInfo.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenceApplicationID;
            _TestAppointmentInfo.AppointmentDate = dtpDate.Value;
            _TestAppointmentInfo.PaidFees = Convert.ToSingle(lblTotalFees.Text);
            _TestAppointmentInfo.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _TestAppointmentInfo.RetakeTestApplicationID = -1;

            if (_TestAppointmentInfo.Save())
            {
                //change form mode to update.
                _Mode = enMode.Update;

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
