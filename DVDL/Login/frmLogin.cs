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

namespace DVDL.Login
{
    public partial class frmLogin : Form
    {
    
        public frmLogin()
        {
            InitializeComponent();
            _MyDesign();
        }
        private void _MyDesign()
        {
            Design.labelDesign(label1);
            Design.labelDesign(label2);
            Design.DataTextBoxDesign(txtUsername);
            Design.DataTextBoxDesign(txtPassword);
            Design.lblLoginStyle(lblMainTitle);
            Design.DataButtonDesign(btnLogin);

        }

      
        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser User = clsUser.FindByUsernameAndPassword(txtUsername.Text.Trim(), txtPassword.Text.Trim());

            if (User != null) {

                if (ckbRememberMe.Checked)
                {
                    clsGlobal.RememberUsernameAndPassword(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                }
                else
                {
                    clsGlobal.RememberUsernameAndPassword("","");
                }

                if (!User.IsActive)
                {
                    txtUsername.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                clsGlobal.CurrentUser = User;
                this.Hide();
                frmMain frm = new frmMain(this);
                frm.ShowDialog();

            }
            else
            {
                txtUsername.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string Username = "", Password = "";
            if (clsGlobal.GetStoredCredential(ref Username,ref Password))
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
    }
}
