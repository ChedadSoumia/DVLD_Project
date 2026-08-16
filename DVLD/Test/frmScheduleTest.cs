using DVDL.Application.Local_Driving_License_Applications;
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
using static DVDL.Test.frmTestAppointments;

namespace DVDL.Test
{
    public partial class frmScheduleTest : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestTypes.enTestType _TestType = clsTestTypes.enTestType.VisionTest;
        private int _TestAppointmentID = -1;


        private void _LoadDesign()
        {
            clsDesign.ButtonCloseStyle(btnClose);
        }
        public frmScheduleTest(int localDrivingLicenseApplicationID, clsTestTypes.enTestType testType, int testAppointmentID = -1)
        {
            InitializeComponent();
            _LoadDesign();
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            _TestType = testType;
            _TestAppointmentID = testAppointmentID;


        }

   


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.TestTypeID = _TestType;
            ctrlScheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID, _TestAppointmentID);
        }
    }
}
