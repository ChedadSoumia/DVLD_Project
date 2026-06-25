using DVDL.Global_Classes;
using DVDL_business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplicationInfo;
        int _TestAppointmentID = -1;
        clsTestAppointments testAppointmentInfo;


        private void _LoadDesign()
        {
            Design.MainLabelTitleDesign(lblMainTitle);
            Design.DataButtonDesign(btnAddNew);
            Design.DataGridViewDesign(dgvAllAppointments);
            
           
        }



        public frmTestAppointments(int localDrivingLicenseApplicationID,enTestTypes testType)
        {
            InitializeComponent();
            _LoadDesign();
            TestType = testType;
            _LocalDrivingLicenseApplicationID=localDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplication.FindlocalDrivingLicenceApplicationID(localDrivingLicenseApplicationID);
            
        }


        private void _LoadData()
        {

            dgvAllAppointments.DataSource = clsTestAppointments.GetAppointments(_LocalDrivingLicenseApplicationID, (clsTestTypes.enTestType)TestType);

            ctrlDrivingLicenseApplicationInfo1.LoadAppliactionInfo(_LocalDrivingLicenseApplicationInfo.ApplicationID);
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

        private void button1_Click(object sender, EventArgs e)
        {

            if (_LocalDrivingLicenseApplicationInfo.IsTestAppointmentActive((int)TestType))
            {
                MessageBox.Show("You Already have an Appointment for this test");
                return;
            }

            if (_LocalDrivingLicenseApplicationInfo.DoesPassTheTest((int)TestType))
            {
                MessageBox.Show("You Already Passes this test");
                return;
            }
            frmScheduleTest scheduleTest = new frmScheduleTest(_LocalDrivingLicenseApplicationID, (ctrlScheduleTest.enTestType)TestType);
            scheduleTest.ShowDialog();
            frmTestAppointments_Load(null, null);

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleTest scheduleTest = new frmScheduleTest((int)dgvAllAppointments.CurrentRow.Cells[0].Value, _LocalDrivingLicenseApplicationID, (ctrlScheduleTest.enTestType)TestType);
            scheduleTest.ShowDialog();
            frmTestAppointments_Load(null, null); ;

        }

      
    }
}
