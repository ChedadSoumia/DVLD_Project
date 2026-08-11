using DVDL.Drivers;
using DVDL.Global_Classes;
using DVDL.License;
using DVDL.People;
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

namespace DVDL.Application.International_Driving_License_Applicaiton
{
    public partial class frmInternationalDrivingLicenseApplicaitonList : Form
    {

        private DataTable _dtAllInternationalLicensesList;


        private void _LoadDate()
        {
            Design.MainLabelTitleDesign(lblMainTitle);
            Design.DataButtonDesign(btnAddNewInternationalLicense);
        }

        public frmInternationalDrivingLicenseApplicaitonList()
        {
            InitializeComponent(); 
            _LoadDate();
        }

        private void frmInternationalDrivingLicenseApplicaitonList_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedText = "None";
            txtFilter.Visible = false;
            comboBox2.Visible = false;


            _dtAllInternationalLicensesList = clsInternationalDrivingLicenseApplicaiton.GetInternationalDrivingLicenseApplicationsList();
            dgvAllInternationalLicensesList.DataSource = _dtAllInternationalLicensesList;

            lblRecordsCount.Text = dgvAllInternationalLicensesList.Rows.Count.ToString();

            if (dgvAllInternationalLicensesList.Rows.Count > 0)
            {
                dgvAllInternationalLicensesList.Columns[0].HeaderText = "Int.License ID";
                dgvAllInternationalLicensesList.Columns[0].Width = 160;

                dgvAllInternationalLicensesList.Columns[1].HeaderText = "Application ID";
                dgvAllInternationalLicensesList.Columns[1].Width = 150;

                dgvAllInternationalLicensesList.Columns[2].HeaderText = "Driver ID";
                dgvAllInternationalLicensesList.Columns[2].Width = 130;

                dgvAllInternationalLicensesList.Columns[3].HeaderText = "L.License ID";
                dgvAllInternationalLicensesList.Columns[3].Width = 130;

                dgvAllInternationalLicensesList.Columns[4].HeaderText = "Issue Date";
                dgvAllInternationalLicensesList.Columns[4].Width = 180;

                dgvAllInternationalLicensesList.Columns[5].HeaderText = "Expiration Date";
                dgvAllInternationalLicensesList.Columns[5].Width = 180;

                dgvAllInternationalLicensesList.Columns[6].HeaderText = "Is Active";
                dgvAllInternationalLicensesList.Columns[6].Width = 120;

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Is Active")
            {
                txtFilter.Text = "";
                txtFilter.Visible = false;
                comboBox2.Visible = true;
                comboBox2.SelectedIndex = 0;
                comboBox2.Focus();
            }
            else
            {
                txtFilter.Visible = (comboBox1.Text != "None");
                comboBox2.Visible = false;
                if (comboBox1.Text == "None")
                {
                    txtFilter.Enabled = false;
                }
                else
                {
                    txtFilter.Enabled = true;
                }

                txtFilter.Text = "";
                txtFilter.Focus();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = comboBox2.Text;
            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }
            if (FilterValue == "All")
            {
                _dtAllInternationalLicensesList.DefaultView.RowFilter = "";
            }
            else
            {
                _dtAllInternationalLicensesList.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
            }
            lblRecordsCount.Text = dgvAllInternationalLicensesList.Rows.Count.ToString();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (comboBox1.Text)
            {
                case "International License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;
                case "Application ID":
                    FilterColumn = "ApplicationID";
                    break;
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;
                case "Local License ID":
                    FilterColumn = "IssuedUsingLocalLicenseID";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilter.Text == "" || FilterColumn == "None")
            {
                _dtAllInternationalLicensesList.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvAllInternationalLicensesList.Rows.Count.ToString();
                return;

            }

            
             _dtAllInternationalLicensesList.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
          

            lblRecordsCount.Text = dgvAllInternationalLicensesList.Rows.Count.ToString();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private void showPersonDetailsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmShowPersonInfo PersonInfo = new frmShowPersonInfo(clsDriver.FindByID((int)dgvAllInternationalLicensesList.CurrentRow.Cells[2].Value).PersonID);
            PersonInfo.ShowDialog();
            frmInternationalDrivingLicenseApplicaitonList_Load(null, null);
        }

        private void showLicenseDetailsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmInternationalDrivingLicenseApplicaiton ShowLicenseInfo = new frmInternationalDrivingLicenseApplicaiton((int)dgvAllInternationalLicensesList.CurrentRow.Cells[0].Value);
            ShowLicenseInfo.ShowDialog();
            frmInternationalDrivingLicenseApplicaitonList_Load(null, null);
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmPersonLicenseHistory PersonLicenseHistory = new frmPersonLicenseHistory(clsDriver.FindByID((int)dgvAllInternationalLicensesList.CurrentRow.Cells[2].Value).PersonID);
            PersonLicenseHistory.ShowDialog();
        }

        private void btnAddNewInternationalLicense_Click(object sender, EventArgs e)
        {
            frmNewInternationalDrivingLicenseApplicaiton newInternationalDrivingLicenseApplicaiton = new frmNewInternationalDrivingLicenseApplicaiton();
            newInternationalDrivingLicenseApplicaiton.ShowDialog();
            frmInternationalDrivingLicenseApplicaitonList_Load(null, null);
        }
    }
}
