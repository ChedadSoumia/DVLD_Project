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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVDL.User
{
    public partial class frmUserList : Form
    {

             

        private static DataTable _AllUsersList = clsUser.GetAllUsers();

        public frmUserList()
        {
            InitializeComponent();
            _Load();
        }
        private void _MyDesign()
        {
            clsDesign.DataGridViewDesign(dgvAllUsers);
            clsDesign.DataButtonDesign(btnAddUser);
            clsDesign.labelDesign(label1);
            clsDesign.labelDesign(label2);
            clsDesign.labelDesign(lblCountUsers);
            clsDesign.DataTextBoxDesign(txtFilter);
            clsDesign.StyleComboBox(cbFilters);
            cbFilters.SelectedText = "None";
            clsDesign.MainLabelTitleDesign(lblMainTitle);
            cbFilters.SelectedIndex = 0;

        }
        private void _RefreshUserList()
        {
            _AllUsersList = clsUser.GetAllUsers();

            dgvAllUsers.DataSource = _AllUsersList;
            lblCountUsers.Text = _AllUsersList.Rows.Count.ToString();
        }

        private void _Load()
        {
            _MyDesign();
            _RefreshUserList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtFilter.Text = "";
            _RefreshUserList();
            if (cbFilters.Text == "Is Active") {

                txtFilter.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
            }
            else {

                txtFilter.Visible = (cbFilters.Text != "None");
                cbIsActive.Visible = false;

                txtFilter.Text = "";
                txtFilter.Focus();
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilters.Text == "Person ID" || cbFilters.Text == "User ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilters.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "Fullname":
                    FilterColumn = "FullName";
                    break;
                case "Username":
                    FilterColumn = "UserName";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilter.Text == "" || FilterColumn == "None")
            {
                _AllUsersList.DefaultView.RowFilter = "";
                lblCountUsers.Text = dgvAllUsers.Rows.Count.ToString();
                return;

            }

            if (FilterColumn == "PersonID" || FilterColumn == "UserID")
            {
                _AllUsersList.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            }
            else
            {
                _AllUsersList.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtFilter.Text.Trim());
            }

            lblCountUsers.Text = dgvAllUsers.Rows.Count.ToString();

        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsActive.Text;
            switch (FilterValue)
            {
                case "All":
                    break;
                case "Active":
                    FilterValue = "0";
                    break;
                case "Not Active":
                    FilterValue = "1";
                    break;
            }
            if (FilterValue == "All")
            {
                _AllUsersList.DefaultView.RowFilter = "";
            }
            else
            {
                _AllUsersList.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
            }
            lblCountUsers.Text = dgvAllUsers.Rows.Count.ToString();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete User [" + dgvAllUsers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsUser.DeleteUser((int)dgvAllUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshUserList();
                }

                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo UserInfo = new frmUserInfo((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            UserInfo.ShowDialog();

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser NewUser = new frmAddEditUser();
            NewUser.ShowDialog();
            _RefreshUserList();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser NewUser = new frmAddEditUser();
            NewUser.ShowDialog();
            _RefreshUserList();
        }

        private void dgvAllUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frmUserInfo UserInfo = new frmUserInfo((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            UserInfo.ShowDialog();
            _RefreshUserList();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser UpdateUser = new frmAddEditUser((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            UpdateUser.ShowDialog();
            frmUserList_Load(null, null);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            changePassword.ShowDialog();
        }

        private void frmUserList_Load(object sender, EventArgs e)
        {
            _RefreshUserList();
            cbFilters.SelectedIndex = 0;

            if (dgvAllUsers.Rows.Count > 0)
            {
                dgvAllUsers.Columns[0].HeaderText = "User ID";
                dgvAllUsers.Columns[0].Width = 110;

                dgvAllUsers.Columns[1].HeaderText = "Person ID";
                dgvAllUsers.Columns[1].Width = 120;

                dgvAllUsers.Columns[2].HeaderText = "Full Name";
                dgvAllUsers.Columns[2].Width = 350;

                dgvAllUsers.Columns[3].HeaderText = "UserName";
                dgvAllUsers.Columns[3].Width = 120;

                dgvAllUsers.Columns[4].HeaderText = "Is Active";
                dgvAllUsers.Columns[4].Width = 120;
            }
        }
    }
}
