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

namespace DVDL.User
{
    public partial class frmChangePassword : Form
    {

        private int _UserID;
        private clsUser _User;

        private void _MyDesign()
        {
            
            clsDesign.MainLabelTitleDesign(lblMainTitle);
            clsDesign.labelDesign(label1);
            clsDesign.labelDesign(label2);
            clsDesign.labelDesign(label3);
            clsDesign.ButtonCloseStyle(btnClose);
            clsDesign.DataButtonDesign(btnSave);

        }

        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _MyDesign();
            _UserID = UserID;
        }

        private void _ResetDefualtValues()
        {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtCurrentPassword.Focus();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {

            _ResetDefualtValues();

            _User = clsUser.Find(_UserID);

            if (_User == null)
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Could not Find User with id = " + _UserID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return;

            }


            ctrlUserCard1.LoadUserInfo(_UserID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }
            ;

            if (!clsGlobal.CurrentUser.VerifyPassword(txtCurrentPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Current password is wrong!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            
                if (string.IsNullOrEmpty(txtNewPassword.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtNewPassword, "New Password cannot be blank");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtNewPassword, null);
                    return;
                }
            

        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match Password!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (_User.ChangePassword(txtNewPassword.Text))
            {
                MessageBox.Show("Password Changed Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Error: Password Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
