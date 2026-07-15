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
        private clsTestTypes.enTestType _TestType = clsTestTypes.enTestType.VisionTest;
        private DataTable _dtLicenseTestAppointments;
        int _LocalDrivingLicenseApplicationID = -1;
        


        private void _LoadDesign()
        {
            Design.MainLabelTitleDesign(lblMainTitle);
            Design.DataButtonDesign(btnAddNew);
            Design.DataGridViewDesign(dgvAllAppointments);
            
           
        }



        public frmTestAppointments(int localDrivingLicenseApplicationID, clsTestTypes.enTestType testType)
        {
            InitializeComponent();
            _LoadDesign();
            _TestType = testType;
            _LocalDrivingLicenseApplicationID=localDrivingLicenseApplicationID;
            
        }


        private void _LoadTestTypeTitle()
        {
            switch (_TestType)
            {
                case clsTestTypes.enTestType.VisionTest:
                    this.Text = "Vision Test appointments";
                    lblMainTitle.Text = "Vision Test appointments";
                    break;
                case clsTestTypes.enTestType.WrittenTest:
                    this.Text = "Written Test appointments";
                    lblMainTitle.Text = "Written Test appointments";
                    break;
                case clsTestTypes.enTestType.StreetTest:
                    this.Text = "Street Test appointments";
                    lblMainTitle.Text = "Street Test appointments";
                    break;
            }
            }

        private void _LoadData()
        {

            _LoadTestTypeTitle();

            ctrlDrivingLicenseApplicationInfo1.LoadLocalLicenseDrivingAppliactionInfo(_LocalDrivingLicenseApplicationID);
            _dtLicenseTestAppointments = clsTestAppointments.GetAppointments(_LocalDrivingLicenseApplicationID, (clsTestTypes.enTestType)_TestType);
            dgvAllAppointments.DataSource = _dtLicenseTestAppointments;

            lblRecordsCount.Text = dgvAllAppointments.Rows.Count.ToString();

            if (dgvAllAppointments.Rows.Count > 0)
            {
                dgvAllAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvAllAppointments.Columns[0].Width = 150;

                dgvAllAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvAllAppointments.Columns[1].Width = 200;

                dgvAllAppointments.Columns[2].HeaderText = "Paid Fees";
                dgvAllAppointments.Columns[2].Width = 150;

                dgvAllAppointments.Columns[3].HeaderText = "Is Locked";
                dgvAllAppointments.Columns[3].Width = 100;
            }


        }

        private void frmTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplicationInfo = new clsLocalDrivingLicenseApplication();
            if (clsLocalDrivingLicenseApplication.IsTestAppointmentActive(_LocalDrivingLicenseApplicationID,_TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test");
                return;
            }

            if (localDrivingLicenseApplicationInfo.DoesPassTheTest(_TestType))
            {
                MessageBox.Show("Person Already Passes this test");
                return;
            }
            frmScheduleTest scheduleTest = new frmScheduleTest(_LocalDrivingLicenseApplicationID, (clsTestTypes.enTestType)_TestType);
            scheduleTest.ShowDialog();
            frmTestAppointments_Load(null, null);

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleTest scheduleTest = new frmScheduleTest(_LocalDrivingLicenseApplicationID, (clsTestTypes.enTestType)_TestType,(int)dgvAllAppointments.CurrentRow.Cells[0].Value);
            scheduleTest.ShowDialog();
            frmTestAppointments_Load(null, null); 

        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTakeTest takeTest = new frmTakeTest((int)dgvAllAppointments.CurrentRow.Cells[0].Value);
            takeTest.ShowDialog();
            frmTestAppointments_Load(null, null);
        }
    }
}
