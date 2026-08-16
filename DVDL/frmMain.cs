using DVDL.Application;
using DVDL.Application.Detain_And_Release_License;
using DVDL.Application.International_Driving_License_Applicaiton;
using DVDL.Application.Local_Driving_License_Applications;
using DVDL.Application.Replacement_for_Lost_or_Damaged_License;
using DVDL.Dashboard;
using DVDL.Drivers;
using DVDL.Global_Classes;
using DVDL.License;
using DVDL.Login;
using DVDL.People;
using DVDL.Test;
using DVDL.User;
using DVDL_business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL
{
    public partial class frmMain : Form
    {
        frmLogin _frmLogin;
        public frmMain(frmLogin frm)
        {
            InitializeComponent();
            clsDesign.DataButtonDesign(btnDashboard);
            clsDesign.MenuStripDesign(menuStrip1);
            _frmLogin = frm;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPeopleList PeopleList = new frmPeopleList();
            PeopleList.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserList UsersList = new frmUserList();
            UsersList.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            changePassword.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to signout? ", "Confirm signOut", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            {
                clsGlobal.CurrentUser = null;
                _frmLogin.Show();
                this.Close();
               
            }
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo CurrentUserInfo = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            CurrentUserInfo.ShowDialog();
        }

        private void applicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApplicationTypeList ApplicationTypeList = new frmApplicationTypeList();
            ApplicationTypeList.ShowDialog();
        }

        private void manageTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestTypesList testTypesList = new frmTestTypesList();
            testTypesList.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplications localDrivingLicenseApplications = new frmLocalDrivingLicenseApplications();
            localDrivingLicenseApplications.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseApplications NewLocalDrivingLicenseApplication = new frmNewLocalDrivingLicenseApplications();
            NewLocalDrivingLicenseApplication.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDrivers DriversList = new frmListDrivers();
            DriversList.ShowDialog();

        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalDrivingLicense RenewLocalLicense = new frmRenewLocalDrivingLicense();
            RenewLocalLicense.ShowDialog();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplacementforLostorDamagedLicense ReplaceLostDamagedLicense = new frmReplacementforLostorDamagedLicense();
            ReplaceLostDamagedLicense.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense DetainLicense = new frmDetainLicense();
            DetainLicense.ShowDialog();
        }

        private void releaseDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmٌReleaseDetainedLicense ReleaseDetainedLicense = new frmٌReleaseDetainedLicense();
            ReleaseDetainedLicense.ShowDialog();
        }

        private void manageDetainLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainedLicensesList detainedLicensesList = new frmDetainedLicensesList();
            detainedLicensesList.ShowDialog();
        }

        private void internationalLiccenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInternationalDrivingLicenseApplicaiton newInternationalDrivingLicenseApplicaiton = new frmNewInternationalDrivingLicenseApplicaiton();
            newInternationalDrivingLicenseApplicaiton.ShowDialog();
        }

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalDrivingLicenseApplicaitonList internationalDrivingLicenseApplicaitonList = new frmInternationalDrivingLicenseApplicaitonList();
            internationalDrivingLicenseApplicaitonList.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            frmDashboard Dashboard = new frmDashboard();
            Dashboard.ShowDialog();
        }
    }
}
