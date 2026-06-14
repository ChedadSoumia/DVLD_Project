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

using DVLD_Buisness;
using DVDL.Global_Classes;

namespace DVDL.Application.Local_Driving_License_Applications
{
    public partial class frmNewLocalDrivingLicenseApplications : Form
    {

        enum enMode { eAddNew = 0,eUpdate = 1}
        enMode _Mode = enMode.eAddNew;

        int _LocalDrivingLicenseApplicationID = -1;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;


        int ApplicantPersonID = -1;
        

        public frmNewLocalDrivingLicenseApplications()
        {
            InitializeComponent();
            _Mode = enMode.eAddNew;
        }

        public frmNewLocalDrivingLicenseApplications(int localDrivingLicenseApplicationId)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationId;
            _Mode = enMode.eUpdate;
        }

        void _LoadApplicationTypeComboBox()
        {
            DataTable dtLicenseClasses = clsLicenseClasses.GetAllLicenseClasses();
            foreach(DataRow row in dtLicenseClasses.Rows)
            {
                comboBox1.Items.Add(row["ClassName"]);
            }
            comboBox1.SelectedIndex = 2;

        }

        void _ResetDefaultValue()
        {
            _LoadApplicationTypeComboBox();
            clsApplicationType ApplicationType = clsApplicationType.Find(1);
            lblLocalAppID.Text = "[???]";
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblApplicationFees.Text = ApplicationType.ApplicationTypeFees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }
        void _LoadData()
        {
            MessageBox.Show("Load inUpdate will implement later");
        }

        private void frmNewLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();
            if (_Mode == enMode.eUpdate)
                _LoadData();
        }
    }
}
