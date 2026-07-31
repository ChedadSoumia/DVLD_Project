using DVDL.Global_Classes;
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

namespace DVDL.Drivers
{
    public partial class frmListDrivers : Form
    {

        private DataTable _AllDriversList;

        private void _MyDesign()
        {
            Design.DataGridViewDesign(dgvAllDrivers);
            Design.labelDesign(lblRecordsCount);
            Design.DataTextBoxDesign(txtFilter);
            Design.StyleComboBox(comboBox1);
            comboBox1.SelectedText = "None";
            Design.MainLabelTitleDesign(lblMainTitle);
            comboBox1.SelectedIndex = 0;

        }
        public frmListDrivers()
        {
            InitializeComponent();
            _MyDesign();
        }

        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            _AllDriversList = clsDriver.GetAlltDrivers();
            dgvAllDrivers.DataSource = _AllDriversList;

            lblRecordsCount.Text = dgvAllDrivers.Rows.Count.ToString();

            if (dgvAllDrivers.Rows.Count > 0)
            {
                dgvAllDrivers.Columns[0].HeaderText = "Driver ID";
                dgvAllDrivers.Columns[0].Width = 120;

                dgvAllDrivers.Columns[1].HeaderText = "Person ID";
                dgvAllDrivers.Columns[1].Width = 120;

                dgvAllDrivers.Columns[2].HeaderText = "National No.";
                dgvAllDrivers.Columns[2].Width = 140;

                dgvAllDrivers.Columns[3].HeaderText = "Full Name";
                dgvAllDrivers.Columns[3].Width = 320;

                dgvAllDrivers.Columns[4].HeaderText = "Date";
                dgvAllDrivers.Columns[4].Width = 170;

                dgvAllDrivers.Columns[5].HeaderText = "Active Licenses";
                dgvAllDrivers.Columns[5].Width = 150;
            }
        }



        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo personInfo = new frmShowPersonInfo((int)dgvAllDrivers.CurrentRow.Cells[1].Value);
            personInfo.ShowDialog();
            frmListDrivers_Load(null, null);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = (comboBox1.Text != "None");

            if (txtFilter.Visible)
            {
                txtFilter.Text = "";
                txtFilter.Focus();
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            
            switch (comboBox1.Text)
            {
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }



            if (txtFilter.Text == "" || FilterColumn == "None")
            {
                _AllDriversList.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvAllDrivers.Rows.Count.ToString();
                return;

            }

            if (FilterColumn == "PersonID" || comboBox1.Text == "Driver ID")
            {
                _AllDriversList.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            }
            else
            {
                _AllDriversList.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtFilter.Text.Trim());
            }

            lblRecordsCount.Text = _AllDriversList.Rows.Count.ToString();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text == "Person ID" || comboBox1.Text == "Driver ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonLicenseHistory LicensesHistory = new frmPersonLicenseHistory((int)dgvAllDrivers.CurrentRow.Cells[0].Value);
            LicensesHistory.ShowDialog();
            frmListDrivers_Load(null, null);
        }
    }
}
