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
    public partial class frmTakeTest : Form
    {
    

        private int _TestAppointmentID = -1;
        private clsTestTypes.enTestType _TestTypeID;


        private clsTest _TestInfo;


        private void _LoadDesign()
        {
            clsDesign.ButtonCloseStyle(btnClose);
            clsDesign.DataButtonDesign(btnSave);
        }
        public frmTakeTest(int testAppointmentID, clsTestTypes.enTestType TestType)
        {
            InitializeComponent();
            _LoadDesign();
            _TestAppointmentID = testAppointmentID;
            _TestTypeID = TestType;

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
            ctrlSecheduledTest1.TestTypeID = _TestTypeID;
            ctrlSecheduledTest1.LoadTestAppointmentInfo(_TestAppointmentID);

            if (ctrlSecheduledTest1.TestAppointmentID == -1)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;

            int _TestID = ctrlSecheduledTest1.TestID;
            if (_TestID != -1)
            {
                _TestInfo = clsTest.Find(_TestID);
                _LoadTestInfo();

                label3.Visible = true;
                flowLayoutPanel1.Enabled = false;
            }
            else
                _TestInfo = new clsTest();

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                     "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No
            )
            {
                return;
            }

            _TestInfo.TestAppointmentID = _TestAppointmentID;
            _TestInfo.TestResult = rbPass.Checked;
            

            _TestInfo.Notes = txtNotes.Text.Trim();
            _TestInfo.CrearedByUserID = clsGlobal.CurrentUser.UserID;

            if (_TestInfo.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        
    }
}
