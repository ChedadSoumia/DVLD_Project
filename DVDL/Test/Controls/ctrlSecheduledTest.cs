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
        private clsTestAppointments _TestAppointmentInfo;
        private int _TestAppointmentID = -1;
        public int TestAppointmentID
        {
            get
            {
                return _TestAppointmentID;
            }
        }



        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private int _LocalDrivingLicenseApplicationID = -1;

        

        private int _TestID = -1;
        public int TestID
        {
            get {  return _TestID; }
        }

        private clsTestTypes.enTestType _TestTypeID;
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
            clsDesign.MainLabelTitleDesign(lblMainTitle);
        }
        public ctrlSecheduledTest()
        {
            InitializeComponent();
            _LoadDesign();
        }
       

        public void LoadTestAppointmentInfo(int testAppointmentID)
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

            _TestID = _TestAppointmentInfo.TestID ;

            _LocalDrivingLicenseApplicationID = _TestAppointmentInfo.LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindlocalDrivingLicenceApplicationID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblAppLocalID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenceApplicationID.ToString();
            lblLicenseClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblFullName.Text = _LocalDrivingLicenseApplication.PersonFullName;


            lblTrial.Text = _LocalDrivingLicenseApplication.TrialsTest(_TestTypeID).ToString();



            lblTestDate.Text = clsFormat.DateToShort(_TestAppointmentInfo.AppointmentDate);
            lblFees.Text = _TestAppointmentInfo.PaidFees.ToString();

            lblTestID.Text = (_TestAppointmentInfo.TestID == -1) ? "Not Taken Yet" : _TestAppointmentInfo.TestID.ToString() ;
            
        }

    }
}
