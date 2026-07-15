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

namespace DVDL.Test
{
    public partial class frmTakeTest : Form
    {
        private enum enMode { eAddNew = 0, eUpdate = 1 }
        private enMode _Mode = enMode.eAddNew;

        private int _TestAppointmentID = -1;
        private clsTestAppointments _TestAppointmentInfo;

        private int _TestID = -1;
        private clsTest _TestInfo;


        private void _LoadDesign()
        {
            Design.ButtonCloseStyle(btnClose);
            Design.DataButtonDesign(btnSave);
        }
        public frmTakeTest(int testAppointmentID)
        {
            InitializeComponent();
            _LoadDesign();
            _TestAppointmentID = testAppointmentID;
            _TestAppointmentInfo = clsTestAppointments.Find(_TestAppointmentID);


        }



        private void _LoadTestInfo()
        {
            if (_TestInfo.TestResult == false)
                rbFail.Checked = true;
            else
                rbPass.Checked = true;
            txtNotes.Text = _TestInfo.Notes;
        }
        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            
            

            _TestInfo = clsTest.HasTestAppointmentATestResult(_TestAppointmentID);
            if(_TestInfo == null)
            {
                _Mode = enMode.eAddNew;
                ctrlSecheduledTest1.LoadTestAppointmentInfo(_TestAppointmentID, _TestAppointmentInfo.TestTypeID);
                _TestInfo = new clsTest();


            }
            else
            {
                _Mode = enMode.eUpdate;
                ctrlSecheduledTest1.LoadTestAppointmentInfo(_TestAppointmentID, _TestAppointmentInfo.TestTypeID, _TestInfo.TestID);
                flowLayoutPanel1.Enabled = false;

                _LoadTestInfo();
                
            }
            


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            _TestInfo.TestAppointmentID = _TestAppointmentID;
            if (rbPass.Checked)
                _TestInfo.TestResult = true;
            else
                _TestInfo.TestResult = false;

            _TestInfo.Notes = txtNotes.Text;
            _TestInfo.CrearedByUserID = clsGlobal.CurrentUser.UserID;

            if (_TestInfo.Save())
            {
                _Mode = enMode.eUpdate;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        
    }
}
