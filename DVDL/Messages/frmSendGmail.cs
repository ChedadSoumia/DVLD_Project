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

namespace DVDL.Messages
{
    public partial class frmSendGmail : Form
    {
        private string _Gmail = "";

        private void _LoadDesign()
        {
            clsDesign.MainLabelTitleDesign(lblMainTitle);
            clsDesign.DataButtonDesign(btnSendEmail);
            clsDesign.ButtonCloseStyle(btnReset);
            clsDesign.ButtonCloseStyle(btnClose);
        }
        public frmSendGmail(string Gmail)
        {
            InitializeComponent();
            _LoadDesign();
            _Gmail = Gmail;
        }

        private void frmSendGmail_Load(object sender, EventArgs e)
        {
            txtTo.Text = _Gmail;
            txtTo.Enabled = (txtTo.Text == "");
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text != "" && txtMessageBody.Text != "")
            {
                if(clsSendMessages.SendEmail(_Gmail, txtTitle.Text, txtMessageBody.Text))
                {
                                    MessageBox.Show(
                    "The message was sent successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                    btnSendEmail.Enabled = false;
                }

            }
            else
            {
                MessageBox.Show("Please fill in both Title and Message fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "";
            txtMessageBody.Text = string.Empty;
            btnSendEmail.Enabled = true;
        }

        private void txtMessageBody_TextChanged(object sender, EventArgs e)
        {
            if (txtMessageBody.Text != "" && txtTitle.Text != "")
                btnSendEmail.Enabled = true;
            else 
                btnSendEmail.Enabled = false;
        }
    }
}
