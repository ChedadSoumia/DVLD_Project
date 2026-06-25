using DVDL.Application.Local_Driving_License_Applications;
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
using static DVDL.Test.frmTestAppointments;

namespace DVDL.Test
{
    public partial class frmScheduleTest : Form
    {
        int _LocalDrivingLicenseApplicationID = -1;
        ctrlScheduleTest.enTestType _TestType = ctrlScheduleTest.enTestType.eVisionTest;

        private enum enMode { AddNew = 1, Update = 2 }
        private enMode _Mode = enMode.AddNew;

        string TypeString
        {
            get
            {
                switch (_TestType)
                {
                    case ctrlScheduleTest.enTestType.eVisionTest:
                        return "Vision Test appointments";
                    case ctrlScheduleTest.enTestType.eWrittenTest:
                        return "Written Test appointments";
                    case ctrlScheduleTest.enTestType.eStreetTest:
                        return "Street Test appointments";
                    default:
                        return "Unknown";
                }
            }
        }

        int _TestAppointmentID = -1;


        private void _LoadDesign()
        {
            Design.ButtonCloseStyle(btnClose);
        }
        public frmScheduleTest(int localDrivingLicenseApplicationID, ctrlScheduleTest.enTestType testType)
        {
            InitializeComponent();
            _LoadDesign();
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            _TestType = testType;
            _Mode = enMode.AddNew;


        }
        public frmScheduleTest(int testAppointmentID,int localDrivingLicenseApplicationID, ctrlScheduleTest.enTestType testType)
        {
            InitializeComponent();
            _LoadDesign();
            _TestAppointmentID = testAppointmentID;
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            _TestType = testType;
            _Mode = enMode.Update;
        }

        private void _LoadData()
        {
          
        }


        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            if(_Mode == enMode.AddNew) { 
            ctrlScheduleTest1.LoadDrivingLicenseApplicationInfo(_LocalDrivingLicenseApplicationID,_TestType);
            this.Text = TypeString;
            } else
            {
                ctrlScheduleTest1.LoadAppointmentInfo(_TestAppointmentID);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
