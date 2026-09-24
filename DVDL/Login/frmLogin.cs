using DVDL.Global_Classes;
using DVDL_business;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using DVDL.Properties;

namespace DVDL.Login
{
    public partial class frmLogin : Form
    {
        private bool _showPassword = false;


        public frmLogin()
        {
            InitializeComponent();
            _MyDesign();
        }
        private void _MyDesign()
        {
            clsDesign.labelDesign(label1);
            clsDesign.labelDesign(label2);
            clsDesign.DataTextBoxDesign(txtUsername);
            clsDesign.DataTextBoxDesign(txtPassword);
            txtPassword.UseSystemPasswordChar = true;
            clsDesign.lblLoginStyle(lblMainTitle);
            clsDesign.DataButtonDesign(btnLogin);

        }

      
        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser User = clsUser.Find(txtUsername.Text.Trim());

            if (User != null) {
                if (User.VerifyPassword(txtPassword.Text))
                {
                    if (ckbRememberMe.Checked)
                    {
                        //clsGlobal.valueUserame = "username";
                        //clsGlobal.valuePassword = "password";
                        //clsGlobal.WriteRegistryValue(txtUsername.Text.Trim());
                        //clsGlobal.WriteRegistryValue(txtPassword.Text.Trim());
                        User.LoginHistoryID = clsSettings.AddLoginHistory(User.UserID, true);
                    }
                    else
                    {
                        clsGlobal.RememberUsernameAndPassword("", "");
                    }

                    if (!User.IsActive)
                    {
                        txtUsername.Focus();
                        MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    clsGlobal.CurrentUser = User;
                    clsSettings.AddLoginHistory(clsGlobal.CurrentUser.UserID, false);
                    this.Hide();
                    frmMain frm = new frmMain(this);
                    frm.ShowDialog();
                }
                else
                {
                    txtPassword.Focus();
                    MessageBox.Show("Invalid Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

            }
            else
            {
                txtUsername.Focus();
                MessageBox.Show("Invalid Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string Username = "", Password = "";
            if (clsGlobal.ReadRegistryValue(ref Username,ref Password))
            {
                txtUsername.Text = Username;
                txtPassword.Text = Password;
                ckbRememberMe.Checked = true;
            }
            else
            {
                ckbRememberMe.Checked = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            _showPassword = !_showPassword;

            txtPassword.UseSystemPasswordChar = !_showPassword;

            pictureBox1.Image = _showPassword
                ? Resources.visibilityoff
                : Resources.visibility;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
