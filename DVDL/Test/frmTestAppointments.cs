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

namespace DVDL.Test
{
    public partial class frmTestAppointments : Form
    {
        public enum enTestTypes { eVisionType = 1, eWrittenType = 2, eStreetType = 3 };
        public enTestTypes TestType = enTestTypes.eVisionType;

        int _LocalDrivingLicenseApplicationID = -1;
        int _TestAppointmentID = -1;
        clsTestAppointments testAppointmentInfo;






        public frmTestAppointments(int localDrivingLicenseApplicationID,enTestTypes testType)
        {
            InitializeComponent();
            TestType = testType;
            _LocalDrivingLicenseApplicationID=localDrivingLicenseApplicationID;
            dataGridView1.DataSource = clsTestAppointments.GetAppointments(localDrivingLicenseApplicationID, (clsTestAppointments.enTestTypes)testType);
        }


        private void _LoadData()
        {
            switch (TestType)
            {
                case enTestTypes.eVisionType:
                    this.Text = "Vision Test appointments";
                    lblMainTitle.Text = "Vision Test appointments";
                    break;
                case enTestTypes.eWrittenType:
                    this.Text = "Written Test appointments";
                    lblMainTitle.Text = "Written Test appointments";
                    break;
                case enTestTypes.eStreetType:
                    this.Text = "Street Test appointments";
                    lblMainTitle.Text = "Street Test appointments";
                    break;

            }
        }

        private void frmTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
    }
}
