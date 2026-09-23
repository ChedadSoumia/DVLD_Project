using DVDL.Global_Classes;
using DVDL.People.Controls;
using DVDL_business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL.User
{
    public partial class frmAddEditUser : Form
    {
        
        private int _UserID   = -1;

        private clsUser _User;
        enum enMode { AddNew = 0, Update = 1 }
        enum enIsActive { NotActive = 0, Active = 1 }

        enMode _Mode = enMode.AddNew;

        private bool _IsUpdatingPermissions = false;

        private void _LoadDesign()
        {
            clsDesign.MainLabelTitleDesign(lblMainTitle);
            clsDesign.ButtonCloseStyle(btnClose);
            clsDesign.ButtonCloseStyle(btnNext);
            clsDesign.DataButtonDesign(btnSave);
            clsDesign.labelDesign(label1);
            clsDesign.labelDesign(label3);
            clsDesign.labelDesign(label4);
            clsDesign.labelDesign(label5);
        }

        public frmAddEditUser()
        {
            InitializeComponent();
            _LoadDesign();
            
            _Mode = enMode.AddNew;

        }
        public frmAddEditUser(int UserID)
        {
            InitializeComponent();
            _LoadDesign();
            _UserID = UserID;
            _Mode = enMode.Update;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if(_Mode == enMode.Update)
            {
                btnNext.Enabled = true;
                tpLoginInfo.Enabled = true;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                return;
            }
            if (ctrlPersonCardWithFilter1.PersonID == -1)
            {
                MessageBox.Show("Selected a person", "Select a person", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ctrlPersonCardWithFilter1.FilterFocus();
            }
            else
            {
                if (clsUser.PersonIsUser(_User.PersonID))
                {
                    MessageBox.Show("Selected person has already a user, Choose another one", "Select another person", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ctrlPersonCardWithFilter1.FilterFocus();
                }
                else
                {
                    btnSave.Enabled = true;
                    tpLoginInfo.Enabled = true;
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                }
            }
           
            

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       private void _ResetDefaultValue()
        {
            if (_Mode == enMode.AddNew)
            {
                lblMainTitle.Text = "Add New User";
                this.Text = "Add New User";
                _User = new clsUser();

                tpLoginInfo.Enabled = false;
                ctrlPersonCardWithFilter1.FilterFocus();
            }
            else
            {
                lblMainTitle.Text = "Update User";
                this.Text = "Update User";

                tpLoginInfo.Enabled = true;
                btnSave.Enabled = true;
            }

            
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPasssword.Text = "";
            chkbIsActive.Checked = false;

        }

        private void _LoadPermissionDate()
        {
            if (_User.Permissions == clsUser.enPermissions.All)
            {
                cbAll.Checked = true;
                cbAll_CheckedChanged(this, null);
                return;
            }
            
            cbAddUser.Checked = _User.Permissions.HasFlag(clsUser.enPermissions.AddUser);
            cbChangePassword.Checked = _User.Permissions.HasFlag(clsUser.enPermissions.ChangePassword);
            cbDashboard.Checked = _User.Permissions.HasFlag(clsUser.enPermissions.Dashboard);
            cbListOfLocalApplication.Checked = _User.Permissions.HasFlag(clsUser.enPermissions.LocalLicense);
            cbInternationalAppliaction.Checked = _User.Permissions.HasFlag(clsUser.enPermissions.InternationalLicense);
            cbReplacementLicense.Checked = _User.Permissions.HasFlag(clsUser.enPermissions.ReplacementLicense);
            cbReleaseDetainedLicense.Checked = _User.Permissions.HasFlag(clsUser.enPermissions.ReleaseDetainedLicense);
        }

        private void _LoadData()
        {
            _User = clsUser.Find(_UserID);
            ctrlPersonCardWithFilter1.FilterEnable = false;
            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);
           lblUserID.Text = _User.UserID.ToString();
            txtUsername.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPasssword.Text = _User.Password;
            chkbIsActive.Checked = _User.IsActive;
            _LoadPermissionDate();

        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpPersonInfo"];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _User.UserName = txtUsername.Text;
            _User.Password = txtPassword.Text;
            _User.IsActive = chkbIsActive.Checked;

            if (_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                _Mode = enMode.Update;
                lblMainTitle.Text = "Update User";
                this.Text = "Update User";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUsername, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUsername, null);
            }

            if(_Mode == enMode.AddNew)
            {
                if (clsUser.IsUserExist(txtUsername.Text.Trim()))
                {

                    e.Cancel = true;
                    errorProvider1.SetError(txtUsername, "username is used by another user");
                }
                else
                {
                    errorProvider1.SetError(txtUsername, null);
                }    
            }
            else
            {
                if (_User.UserName != txtUsername.Text.Trim())
                {
                    if (clsUser.IsUserExist(txtUsername.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUsername, "username is used by another user");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(txtUsername, null);
                    }
                    ;
                }
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void txtConfirmPasssword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text != txtConfirmPasssword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPasssword, "Password Confirmation does not match Password!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPasssword, null);
            }
        }

        private void frmAddEditUser_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();
        }

        private void cbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (_IsUpdatingPermissions)
                return;

            _IsUpdatingPermissions = true;

            _User.Permissions = cbAll.Checked
                ? clsUser.enPermissions.All
                : clsUser.enPermissions.None;

            cbAddUser.Checked = cbAll.Checked;
            cbChangePassword.Checked = cbAll.Checked;
            cbDashboard.Checked = cbAll.Checked;
            cbListOfLocalApplication.Checked = cbAll.Checked;
            cbInternationalAppliaction.Checked = cbAll.Checked;
            cbReplacementLicense.Checked = cbAll.Checked;
            cbReleaseDetainedLicense.Checked = cbAll.Checked;

            _IsUpdatingPermissions = false;

        }

     
        void AddPermission( string permissionTag)
        {
            if(Enum.IsDefined(typeof(clsUser.enPermissions), permissionTag))
            {
                Enum.TryParse(permissionTag, out clsUser.enPermissions p);
                _User.Permissions |= p;
            }
        }
        void DeletePermission(string permissionTag)
        {
            if(Enum.IsDefined(typeof(clsUser.enPermissions), permissionTag))
            {
                Enum.TryParse(permissionTag, out clsUser.enPermissions p);
                _User.Permissions &= ~p;
            }
        }
        private void CheckIfAllPermissionsChecked()
        {
            _IsUpdatingPermissions = true;

            cbAll.Checked =
                cbAddUser.Checked &&
                cbChangePassword.Checked &&
                cbDashboard.Checked &&
                cbListOfLocalApplication.Checked &&
                cbInternationalAppliaction.Checked &&
                cbReplacementLicense.Checked &&
                cbReleaseDetainedLicense.Checked;

            _IsUpdatingPermissions = false;
        }
        private void CheckedPermission(object sender, EventArgs e)
        {
            if (_IsUpdatingPermissions)
                return;

            CheckBox cb = sender as CheckBox;
            if (cb.Checked)
            {
                AddPermission(cb.Tag.ToString().Trim());
            }
            else
            {
                DeletePermission(cb.Tag.ToString().Trim());
            }
            CheckIfAllPermissionsChecked();
        }
    }
}
