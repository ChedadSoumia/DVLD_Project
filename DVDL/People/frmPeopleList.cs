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

        private static DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
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
            Design.DataGridViewDesign(dgvAllPeople);
            Design.DataButtonDesign(btnAddPerson);
            Design.labelDesign(label1);
            Design.labelDesign(label2);
            Design.labelDesign(lblRecordsCount);
            Design.DataTextBoxDesign(twtFilter);
            Design.StyleComboBox( comboBox1);
            comboBox1.SelectedText = "None";
            Design.MainLabelTitleDesign(lblMainTitle);
            comboBox1.SelectedIndex = 0;

        }
        private void _RefreshPeopleList()
        {
            _dtAllPeople = clsPerson.GetAllPeople();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");

            dgvAllPeople.DataSource= _dtPeople;
            lblRecordsCount.Text = _dtPeople.Rows.Count.ToString();
        }
        private void _Load() {
            _MyDesign();
            _RefreshPeopleList();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson AddUpdatePerson = new frmAddUpdatePerson();
            AddUpdatePerson.ShowDialog();
            _RefreshPeopleList();
        }

        private void twtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
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
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gendor":
                    FilterColumn = "GendorCaption";
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



            if(twtFilter.Text == "" || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = ""; 
                lblRecordsCount.Text = dgvAllPeople.Rows.Count.ToString();
                return;

            }

            if(FilterColumn == "PersonID")
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, twtFilter.Text.Trim());
            }
            else
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, twtFilter.Text.Trim());
            }

                lblRecordsCount.Text = dgvAllPeople.Rows.Count.ToString();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            twtFilter.Visible = (comboBox1.Text != "None");

            if (twtFilter.Visible)
            {
                twtFilter.Text = "";
                twtFilter.Focus();
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
    }
}
