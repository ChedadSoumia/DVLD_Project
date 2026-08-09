using DVDL.Drivers;
using DVDL.Global_Classes;
using DVDL.License;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVDL.Application.Detain_And_Release_License
{
    public partial class frmDetainLicense : Form
    {
        private int _SelectedLicenseID = -1;

        private int _DetainID = -1;
        private clsDetainAndReleaseLicense _OperationInfo;


     

        private void _LoadDesign()
        {
            Design.MainLabelTitleDesign(lblMainTitle);
            Design.DataButtonDesign(btnDetain);
            Design.ButtonCloseStyle(btnClose);
            
        }

        public frmDetainLicense()
        {
            InitializeComponent();
            _LoadDesign();
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
        }

  

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;

            lblLicenseID.Text = _SelectedLicenseID.ToString();
            lblShowLicenseHistory.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1)
                return;




            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License i already detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            txtTotalFees.Focus();
            btnDetain.Enabled = true;


        }

        private void txtTotalFees_Validating(object sender, CancelEventArgs e)
        {
            
                if (string.IsNullOrEmpty(txtTotalFees.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtTotalFees, "This field is required!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtTotalFees, "");
                }

            if (!clsValidation.IsNumber(txtTotalFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTotalFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtTotalFees, null);
            }
            ;

        }

        private void btnDetain_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            _DetainID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Detain(Convert.ToSingle(txtTotalFees.Text), clsGlobal.CurrentUser.UserID);

            if (_DetainID == -1)
            {
                MessageBox.Show("Faild to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblDetainID.Text = _DetainID.ToString();
            MessageBox.Show("License Detained Successfully with ID=" + _DetainID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnDetain.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            txtTotalFees.Enabled = false;
            lblAppInfo.Enabled = true;






        }

        private void lblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonLicenseHistory licenseHistory = new frmPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            licenseHistory.ShowDialog();
        }

        private void lblAppInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo licenseInfo = new frmDriverLicenseInfo(_SelectedLicenseID);
            licenseInfo.ShowDialog();
        }
    }
    }

