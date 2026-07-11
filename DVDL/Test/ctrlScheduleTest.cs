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

        public enum enMode {eAddNew= 0,eUpdate=1 }
        private enMode _Mode = enMode.eAddNew;

        public enum enCreationMode { eFirstTimeSchedule = 0,eRetakeTimeSchedule = 1}
        private enCreationMode _CreationMode = enCreationMode.eFirstTimeSchedule;

        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        int _TestAppointmentID = -1;
        clsTestAppointments _TestAppointmentInfo;

        private clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.VisionTest;
        public clsTestTypes.enTestType TestTypeID
        {
            get { return _TestTypeID; }

            set
            {
                _TestTypeID = value;
                switch (_TestTypeID)
                {
                    case clsTestTypes.enTestType.VisionTest:
                        groupBox1.Text = "Vision Test";
                        break;
                    case clsTestTypes.enTestType.WrittenTest:
                        groupBox1.Text = "Written Test";
                        break;
                    case clsTestTypes.enTestType.StreetTest:
                        groupBox1.Text = "Street Test";
                        break;
                }
            }

        }

        private void _LoadDesign()
        {
            Design.DataButtonDesign(btnSave);
            Design.MainLabelTitleDesign(lblMainTitle);
        }

        public ctrlScheduleTest()
        {
            InitializeComponent();
            _LoadDesign();
           
        }

        private bool _LoadTestAppointmentData()
        {
            _TestAppointmentInfo = clsTestAppointments.Find(_TestAppointmentID);

            if (_TestAppointmentInfo == null)
            {
                MessageBox.Show("Error: No Appointment with ID = " + _TestAppointmentID.ToString(),
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }

            lblFeesVisionTest.Text = _TestAppointmentInfo.PaidFees.ToString();

            if(DateTime.Compare(_TestAppointmentInfo.AppointmentDate, DateTime.Now) < 0)
            {
                dtpDate.MinDate  = DateTime.Now;
            }
            else
            {
                dtpDate.MinDate = _TestAppointmentInfo.AppointmentDate ;
            }

            dtpDate.Value = _TestAppointmentInfo.AppointmentDate;


            if(_TestAppointmentInfo.RetakeTestApplicationID == -1)
            {
                lblRetakeAppID.Text = "N/A";
                lblRetakeAppFees.Text = "0";
            }
            else
            {
                lblRetakeAppFees.Text = _TestAppointmentInfo.RetakeTestAppInfo.PaidFees.ToString();
                groupBox2.Enabled = true;
                lblMainTitle.Text = "Schedule Retake Test";
                lblRetakeAppID.Text = _TestAppointmentInfo.RetakeTestApplicationID.ToString();
            }
            return true;

        }

        private bool _HandleActiveTestAppointmentConstraint()
        {
            if (_Mode == enMode.eAddNew && clsLocalDrivingLicenseApplication.IsTestAppointmentActive(_LocalDrivingLicenseApplicationID,_TestTypeID))
            {
                lblAppointmentLock.Text = "Person Already have an active appointment for this test";
                lblAppointmentLock.Visible = true;
                btnSave.Enabled = false;
                dtpDate.Enabled = false;
                return false;
            }
            return true;
        }

        private bool _HandlePrviousTestConstraint()
        {
            switch (TestTypeID)
            {
                case clsTestTypes.enTestType.VisionTest:
                    lblAppointmentLock.Visible = false;
                    return true;
                case clsTestTypes.enTestType.WrittenTest:
                    if (!_LocalDrivingLicenseApplication.DoesPassTheTest(clsTestTypes.enTestType.VisionTest))
                    {
                        lblAppointmentLock.Text = "Cannot Sechule, Vision Test should be passed first";
                        lblAppointmentLock.Visible= true;
                        btnSave.Enabled= false;
                        dtpDate.Enabled= false;
                        return false;
                    }
                    else
                    {
                        lblAppointmentLock.Visible = false;
                        btnSave.Enabled = true;
                        dtpDate.Enabled = true;
                    }
                    return true;
                case clsTestTypes.enTestType.StreetTest:
                    if (!_LocalDrivingLicenseApplication.DoesPassTheTest(clsTestTypes.enTestType.WrittenTest))
                    {
                        lblAppointmentLock.Text = "Cannot Sechule, Written Test should be passed first";
                        lblAppointmentLock.Visible = true;
                        btnSave.Enabled = false;
                        dtpDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblAppointmentLock.Visible = false;
                        btnSave.Enabled = true;
                        dtpDate.Enabled = true;
                    }

                    return true;

            }
            return true;
        }

        private bool _HandleAppointmentLockedConstraint()
        {
            if (_TestAppointmentInfo.IsLocked)
            {
                lblAppointmentLock.Visible = true;
                lblAppointmentLock.Text = "Person already sat for the test, appointment loacked.";
                dtpDate.Enabled = false;
                btnSave.Enabled = false;
                return false;
            }
            else
                lblAppointmentLock.Visible =false;
            return true;
        }



        public void LoadInfo(int LocalDrivingLicenseApplicationID,int TestAppointmentID=-1)
        {
            

            if (TestAppointmentID == -1)
                _Mode = enMode.eAddNew;
            else
                _Mode = enMode.eUpdate;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindlocalDrivingLicenceApplicationID(LocalDrivingLicenseApplicationID);
            _TestAppointmentID = TestAppointmentID;

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }


            if (_LocalDrivingLicenseApplication.DoesAttendTestType(_TestTypeID))
                _CreationMode = enCreationMode.eRetakeTimeSchedule;
            else
                _CreationMode = enCreationMode.eFirstTimeSchedule;


            if(_CreationMode == enCreationMode.eRetakeTimeSchedule)
            {
                lblMainTitle.Text = "Schedule Retake test";
                groupBox2.Enabled = true;
                lblRetakeAppFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.eRetakeTest).ApplicationTypeFees.ToString();
                lblRetakeAppID.Text = "N/A";

            }
            else
            {
                lblMainTitle.Text = "Schedule Test";
                groupBox2.Enabled = false;
                lblRetakeAppID.Text = "0";
                lblRetakeAppFees.Text = "0";

            }

            lblAppLocalID.Text = _LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblFullName.Text = _LocalDrivingLicenseApplication.ApplicantFullName;
            lblTrial.Text = _LocalDrivingLicenseApplication.TrialsTest((int)_TestTypeID).ToString();
            

            if(_Mode == enMode.eAddNew)
            {
                lblFeesVisionTest.Text = clsTestTypes.Find(_TestTypeID).TestTypeFees.ToString();
                lblRetakeAppID.Text = "N/A";
                dtpDate.MinDate = DateTime.Now;

                _TestAppointmentInfo = new clsTestAppointments(); 
            }
            else
            {
                if (!_LoadTestAppointmentData())
                    return;
            }

            lblTotalFees.Text = (Convert.ToSingle(lblFeesVisionTest.Text) + Convert.ToSingle(lblRetakeAppFees.Text)).ToString();

            if (!_HandleActiveTestAppointmentConstraint())
                return;

            if (!_HandleAppointmentLockedConstraint())
                return;

            if (!_HandlePrviousTestConstraint())
                return;




        }

        private bool _HandleRetakeApplication()
        {
            if(_Mode == enMode.eAddNew && _CreationMode == enCreationMode.eRetakeTimeSchedule)
            {
                clsApplication Application = new clsApplication();


                Application.ApplicantPersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
                Application.ApplicationDate = DateTime.Now;
                Application.ApplicationTypeID = (int)clsApplication.enApplicationType.eRetakeTest;
                Application.ApplicationStatus = clsApplication.enApplicationStatus.eNew;
                Application.LastStatusDate = DateTime.Now;
                Application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.eRetakeTest).ApplicationTypeFees;
                Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;



                if (!Application.Save())
                {
                    _TestAppointmentInfo.RetakeTestApplicationID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointmentInfo.RetakeTestApplicationID = Application.ApplicationID;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeApplication())
                return;

            _TestAppointmentInfo.TestTypeID = _TestTypeID;
            _TestAppointmentInfo.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenceApplicationID;
            _TestAppointmentInfo.AppointmentDate = dtpDate.Value;
            _TestAppointmentInfo.PaidFees = Convert.ToSingle(lblFeesVisionTest);
            _TestAppointmentInfo.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_TestAppointmentInfo.Save())
            {
                _Mode = enMode.eUpdate;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
    }
}
