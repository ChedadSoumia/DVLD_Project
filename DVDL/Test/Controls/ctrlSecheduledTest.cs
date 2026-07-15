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
using static DVDL_business.clsTestTypes;

namespace DVDL.Test
{
    public partial class ctrlSecheduledTest : UserControl
    {

        private int _TestAppointmentID = -1;
        private clsTestAppointments _TestAppointmentInfo;

        private int _TestID = -1;

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
            Design.MainLabelTitleDesign(lblMainTitle);
        }
        public ctrlSecheduledTest()
        {
            InitializeComponent();
            _LoadDesign();
        }
        private void _LoadData()
        {
            lblAppLocalID.Text = _TestAppointmentInfo.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = _TestAppointmentInfo.LocalDrivingLicenseApplicationInfo.LicenseClassInfo.ClassName;
            lblFullName.Text = _TestAppointmentInfo.LocalDrivingLicenseApplicationInfo.ApplicantFullName;
            lblTrial.Text = clsTest.GetPassedTestCount(_TestAppointmentInfo.LocalDrivingLicenseApplicationID).ToString();
            lblTestDate.Text = clsFormat.DateToShort(_TestAppointmentInfo.AppointmentDate);
            lblFees.Text = _TestAppointmentInfo.PaidFees.ToString();
            if (_TestID == -1)
                lblTestID.Text = "Not Taken Yet";
            else 
                lblTestID.Text = _TestID.ToString();


        }

        public void LoadTestAppointmentInfo(int testAppointmentID,clsTestTypes.enTestType testTypeID , int TestID = -1)
        {
            _TestAppointmentID = testAppointmentID;
            _TestAppointmentInfo = clsTestAppointments.Find(testAppointmentID);

            if (_TestAppointmentInfo == null)
            {
                MessageBox.Show("Error: No  Appointment ID = " + _TestAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;
            }

            _TestID = TestID;


            _LoadData();
        }

    }
}
