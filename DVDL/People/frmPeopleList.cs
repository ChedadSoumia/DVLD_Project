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

namespace DVDL.People
{
    public partial class frmPeopleList : Form
    {
        private static DataTable _dtAllPeople = clsPerson.GetAllPeople();

        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");
        public frmPeopleList()
        {

            InitializeComponent();
            _Load();

        }
        private void _MyDesign()
        {
            clsDesign.DataGridViewDesign(dgvAllPeople);
            clsDesign.DataButtonDesign(btnAddPerson);
            clsDesign.labelDesign(label1);
            clsDesign.labelDesign(label2);
            clsDesign.labelDesign(lblRecordsCount);
            clsDesign.DataTextBoxDesign(txtFilter);
            clsDesign.StyleComboBox(comboBox1);
            comboBox1.SelectedText = "None";
            clsDesign.MainLabelTitleDesign(lblMainTitle);
            comboBox1.SelectedIndex = 0;

        }
        private void _RefreshPeopleList()
        {
            _dtAllPeople = clsPerson.GetAllPeople();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");

            dgvAllPeople.DataSource = _dtPeople;
            lblRecordsCount.Text = _dtPeople.Rows.Count.ToString();
        }
        private void _Load()
        {
            _MyDesign();
            _RefreshPeopleList();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson AddUpdatePerson = new frmAddUpdatePerson();
            AddUpdatePerson.ShowDialog();
            _RefreshPeopleList();
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Gendor")
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


        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson AddUpdatePerson = new frmAddUpdatePerson();
            AddUpdatePerson.ShowDialog();
            _RefreshPeopleList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson AddUpdatePerson = new frmAddUpdatePerson(((int)dgvAllPeople.CurrentRow.Cells[0].Value));
            AddUpdatePerson.ShowDialog();
            _RefreshPeopleList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvAllPeople.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsPerson.DeletePerson((int)dgvAllPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeopleList();
                }

                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ShowPersonDetails = new frmShowPersonInfo((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            ShowPersonDetails.ShowDialog();
            _RefreshPeopleList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmFindPerson findAPerson = new frmFindPerson();
            findAPerson.ShowDialog();
        }

        private void twtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
           

            if (comboBox1.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void frmPeopleList_Load(object sender, EventArgs e)
        {
            comboBox2.Visible = false;
            txtFilter.Visible = false;

            _RefreshPeopleList();

            if (dgvAllPeople.Rows.Count > 0)
            {

                dgvAllPeople.Columns[0].HeaderText = "Person ID";
                dgvAllPeople.Columns[0].Width = 100;

                dgvAllPeople.Columns[1].HeaderText = "National No.";
                dgvAllPeople.Columns[1].Width = 90;


                dgvAllPeople.Columns[2].HeaderText = "Firstname";
                dgvAllPeople.Columns[2].Width = 90;

                dgvAllPeople.Columns[3].HeaderText = "Secondname";
                dgvAllPeople.Columns[3].Width = 90;


                dgvAllPeople.Columns[4].HeaderText = "Thirdname";
                dgvAllPeople.Columns[4].Width = 90;

                dgvAllPeople.Columns[5].HeaderText = "Lastname";
                dgvAllPeople.Columns[5].Width = 90;

                dgvAllPeople.Columns[6].HeaderText = "Gendor";
                dgvAllPeople.Columns[6].Width = 80;

                dgvAllPeople.Columns[7].HeaderText = "Date Of Birth";
                dgvAllPeople.Columns[7].Width = 110;

                dgvAllPeople.Columns[8].HeaderText = "Nationality";
                dgvAllPeople.Columns[8].Width = 100;


                dgvAllPeople.Columns[9].HeaderText = "Phone";
                dgvAllPeople.Columns[9].Width = 100;


                dgvAllPeople.Columns[10].HeaderText = "Email";
                dgvAllPeople.Columns[10].Width = 150;
            }
        }

        private void dgvAllPeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Form ShowPersonDetails = new frmShowPersonInfo((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            ShowPersonDetails.ShowDialog();
            _RefreshPeopleList();
        }

        private void twtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (comboBox1.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "National No.":
                    FilterColumn = "NationalNo";
                    break;
                case "First Name":
                    FilterColumn = "FirstName";
                    break;
                case "Second Name":
                    FilterColumn = "Second Name";
                    break;
                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;
                case "Last Name":
                    FilterColumn = "LastName";
                    break;
                case "Nationality":
                    FilterColumn = "Nationality";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break;
                case "Email":
                    FilterColumn = "Email";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilter.Text == "" || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvAllPeople.Rows.Count.ToString();
                return;

            }


            if (FilterColumn == "PersonID")
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            }
            else
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtFilter.Text.Trim());
            }


            lblRecordsCount.Text = dgvAllPeople.Rows.Count.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "GendorCaption";
            string FilterValue = comboBox2.Text;
            
            if (FilterValue == "All")
            {
                _dtPeople.DefaultView.RowFilter = "";
            }
            else
            {
                _dtPeople.DefaultView.RowFilter = string.Format("{0} = '{1}'", FilterColumn, FilterValue);
            }
            lblRecordsCount.Text = dgvAllPeople.Rows.Count.ToString();
        }
    }
}

