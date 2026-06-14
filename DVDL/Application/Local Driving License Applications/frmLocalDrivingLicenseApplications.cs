using DVDL.Application.Local_Driving_License_Applications;
using DVDL.Global_Classes;
using DVDL_business;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL.Application
{
    public partial class frmLocalDrivingLicenseApplications : Form
    {
        private DataTable _AllLocalApplications;

        public frmLocalDrivingLicenseApplications()
        {
            InitializeComponent();
            _MyDesign();
        }

        private void _MyDesign()
        {
            Design.DataGridViewDesign(dgvAllLocalApplications);
            Design.DataButtonDesign(btnAddApplication);
            Design.labelDesign(label1);
            Design.labelDesign(label2);
            Design.labelDesign(lblRecordsCount);
            Design.DataTextBoxDesign(txtFilter);
            Design.StyleComboBox(comboBox1);
            comboBox1.SelectedText = "None";
            Design.MainLabelTitleDesign(lblMainTitle);
            comboBox1.SelectedIndex = 0;

        }

        private void frmLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _AllLocalApplications = clsApplication.GetAllApplications();

            dgvAllLocalApplications.DataSource = _AllLocalApplications;
            lblRecordsCount.Text = dgvAllLocalApplications.Rows.Count.ToString();
        }

        private void btnAddApplication_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseApplications NewLocalDrivingLicenseApplication = new frmNewLocalDrivingLicenseApplications();
            NewLocalDrivingLicenseApplication.ShowDialog();
        }
    }
}
