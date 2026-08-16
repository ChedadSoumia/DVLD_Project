using DVDL.Application.Replacement_for_Lost_or_Damaged_License;
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

namespace DVDL.Application.Detain_And_Release_License
{
    public partial class frmDetainedLicensesList : Form
    {
        private DataTable _dtAllDetainLicensesList;

        private void _LoadDesign()
        {
            clsDesign.MainLabelTitleDesign(lblMainTitle);
            clsDesign.DataButtonDesign(btnAddDetainLicense);
            clsDesign.DataButtonDesign(btnReleaseLicense);

        }

        public frmDetainedLicensesList()
        {
            InitializeComponent();
            _LoadDesign();
        }

        private void btnAddDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense DetainLicense = new frmDetainLicense();
            DetainLicense.ShowDialog();
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense ReleaseDetainedLicense = new frmDetainLicense();
            ReleaseDetainedLicense.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            if(comboBox1.Text == "Is Released")
            {
                txtFilter.Text = "";
                txtFilter.Visible = false;
                comboBox2.Visible = true;
                tlpDateFilter.Visible = false;
                comboBox2.SelectedIndex = 0;
                comboBox2.Focus();

            }else if (comboBox1.Text == "Detain Date")
            {
                txtFilter.Text = "";
                dtpToDate.Enabled = false;
                tlpDateFilter.Visible = true;
                tlpDateFilter.Focus();
                txtFilter.Visible = false;
                comboBox2.Visible = true;
                comboBox2.SelectedIndex = 0;
            }
            else
            {
                txtFilter.Visible = (comboBox1.Text != "None");
                comboBox2.Visible = false;
                tlpDateFilter.Visible = false;
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

        private void frmDetainedLicensesList_Load(object sender, EventArgs e)
        {

            comboBox1.SelectedText = "None";
            txtFilter.Visible = false;
            comboBox2.Visible = false;
            dtpToDate.Enabled = false;
            tlpDateFilter.Visible = false;

            _dtAllDetainLicensesList = clsDetainAndReleaseLicense.GetAllDetainedLicenses();
            dgvAllDetainedLicenses.DataSource = _dtAllDetainLicensesList;



            lblRecordsCount.Text = dgvAllDetainedLicenses.Rows.Count.ToString();




                if (dgvAllDetainedLicenses.Rows.Count > 0)
            {
                dgvAllDetainedLicenses.Columns[0].HeaderText = "D.ID";
                dgvAllDetainedLicenses.Columns[0].Width = 90;

                dgvAllDetainedLicenses.Columns[1].HeaderText = "L.ID";
                dgvAllDetainedLicenses.Columns[1].Width = 90;

                dgvAllDetainedLicenses.Columns[2].HeaderText = "D.Date";
                dgvAllDetainedLicenses.Columns[2].Width = 160;

                dgvAllDetainedLicenses.Columns[3].HeaderText = "Is Released";
                dgvAllDetainedLicenses.Columns[3].Width = 110;

                dgvAllDetainedLicenses.Columns[4].HeaderText = "Fine Fees";
                dgvAllDetainedLicenses.Columns[4].Width = 110;

                dgvAllDetainedLicenses.Columns[5].HeaderText = "Release Date";
                dgvAllDetainedLicenses.Columns[5].Width = 160;

                dgvAllDetainedLicenses.Columns[6].HeaderText = "N.No.";
                dgvAllDetainedLicenses.Columns[6].Width = 90;

                dgvAllDetainedLicenses.Columns[7].HeaderText = "Full Name";
                dgvAllDetainedLicenses.Columns[7].Width = 330;

                dgvAllDetainedLicenses.Columns[8].HeaderText = "Rlease App.ID";
                dgvAllDetainedLicenses.Columns[8].Width = 150;

            }
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmٌReleaseDetainedLicense ReleaseDetainedLicense = new frmٌReleaseDetainedLicense((int)dgvAllDetainedLicenses.CurrentRow.Cells[1].Value);
            ReleaseDetainedLicense.ShowDialog();
            frmDetainedLicensesList_Load(null, null);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            releaseDetainedLicenseToolStripMenuItem.Enabled = !(bool)dgvAllDetainedLicenses.CurrentRow.Cells[3].Value;
        }

   

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text == "Detain ID" || comboBox1.Text == "Release Application ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsReleased";
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
                _dtAllDetainLicensesList.DefaultView.RowFilter = "";
            }
            else
            {
                _dtAllDetainLicensesList.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
            }
            lblRecordsCount.Text = dgvAllDetainedLicenses.Rows.Count.ToString();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (comboBox1.Text)
            {
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;
                case "National No.":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilter.Text == "" || FilterColumn == "None")
            {
                _dtAllDetainLicensesList.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvAllDetainedLicenses.Rows.Count.ToString();
                return;

            }

            if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
            {
                _dtAllDetainLicensesList.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            }
            else
            {
                _dtAllDetainLicensesList.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtFilter.Text.Trim());
            }

            lblRecordsCount.Text = dgvAllDetainedLicenses.Rows.Count.ToString();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo PersonInfo = new frmShowPersonInfo(clsLicenses.Find((int)dgvAllDetainedLicenses.CurrentRow.Cells[1].Value).DriverInfo.PersonID);
            PersonInfo.ShowDialog();
            frmDetainedLicensesList_Load(null, null);
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDriverLicenseInfo ShowLicenseInfo = new frmDriverLicenseInfo((int)dgvAllDetainedLicenses.CurrentRow.Cells[1].Value);
            ShowLicenseInfo.ShowDialog();
            frmDetainedLicensesList_Load(null, null);
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonLicenseHistory PersonLicenseHistory = new frmPersonLicenseHistory(clsLicenses.Find((int)dgvAllDetainedLicenses.CurrentRow.Cells[1].Value).DriverInfo.PersonID);
            PersonLicenseHistory.ShowDialog();
            frmDetainedLicensesList_Load(null, null);
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            dtpToDate.Enabled = true;
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            string FilterColumn = "DetainDate";
            if (dtpToDate.Checked)
            {
                _dtAllDetainLicensesList.DefaultView.RowFilter = string.Format("[{0}] >= #{1:yyyy-MM-dd 00:00:00}# AND [{0}] <= #{2:yyyy-MM-dd 23:59:59}#", FilterColumn, dtpFromDate.Value, dtpToDate.Value);
            }
            else
            {
                _dtAllDetainLicensesList.DefaultView.RowFilter = "";
            }
            
        }
    }
}
