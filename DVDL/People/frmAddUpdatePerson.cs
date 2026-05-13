using DVDL.Global_Classes;
using DVDL.Properties;
using DVDL_business;
using DVLD_Buisness;
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

namespace DVDL.People
{
    public partial class frmAddUpdatePerson : Form
    {

        enum enMode { AddNew = 0,Update=1}
        enum enGendor { Male = 0, Female = 1}

        enMode _Mode = enMode.AddNew;
        clsPerson _Person;
        int _PersonID= -1;

        public frmAddUpdatePerson()
        {
            InitializeComponent();
            _LoadDesign();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            _LoadDesign();
            _Mode = enMode.Update;
            _PersonID = PersonID;
        }
        private void _LoadDesign()
        {
            Design.MainLabelTitleDesign(lblMainTitle);
            Design.DataButtonDesign(btnSave);
            Design.ButtonCloseStyle(btnClose);
            Design.labelDesign(label1);
            Design.labelDesign(label2);
            Design.labelDesign(label7);
            Design.labelDesign(label8);
            Design.labelDesign(label9);
            Design.labelDesign(label10);
            Design.labelDesign(label11);
            Design.labelDesign(label12);
            Design.labelDesign(label14);
            Design.NormallabelDesign(lblPersonID);
            Design.NormallabelDesign(label3);
            Design.NormallabelDesign(label4);
            Design.NormallabelDesign(label5);
            Design.NormallabelDesign(label6);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;

            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Man;
            else
                pbPersonImage.Image = Resources.Woman;

                pbPersonImage.Visible = false;
        }

        private void lblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pbPersonImage.Load(selectedFilePath);
                lblRemove.Visible = true;
                // ...
            }
        }

        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
            cbCountry.SelectedText = "Algeria";
        }

        private void _ResetDefaultValue()
        {
            _FillCountriesInComoboBox();

            if(_Mode == enMode.AddNew)
            {
                lblMainTitle.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
            {
                lblMainTitle.Text = "Update person";
            }

            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Man;
            else
                pbPersonImage.Image = Resources.Woman;

            lblRemove.Visible = (pbPersonImage.Image != null);

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            cbCountry.SelectedIndex = cbCountry.FindString("Algeria");

            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationaleNo.Text = "";
            rbMale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";

        }

        private void _LoadData()
        {

            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            //the following code will not be executed if the person was not found
            lblPersonID.Text = _PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationaleNo.Text = _Person.NationalNo;
            dtpDateOfBirth.Value = _Person.DateOfBirth;

            if (_Person.Gendor == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            txtAddress.Text = _Person.Address;
            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;
            cbCountry.SelectedIndex = cbCountry.FindString(_Person.CountryInfo.CountryName);


            //load person image incase it was set.
            if (_Person.ImagePath != "")
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;

            }

            //hide/show the remove linke incase there is no image for the person.
            lblRemove.Visible = (_Person.ImagePath != "");


        }
        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();
            if(_Mode == enMode.Update)
                _LoadData();
        }

        private bool _HandlePersonImage()
        {
            if(_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {     }

                    if(pbPersonImage.ImageLocation != null)
                    {
                        string SourceImageFile = pbPersonImage.ImageLocation.ToString();

                        if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                        {
                            pbPersonImage.ImageLocation = SourceImageFile;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Man;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Woman;
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(temp.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "This field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(temp,"");
            }
        }

        private void txtNationaleNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationaleNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationaleNo, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNationaleNo, null);
            }

            //Make sure the national number is not used by another person
            if (txtNationaleNo.Text.Trim() != _Person.NationalNo && clsPerson.isPersonExist(txtNationaleNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationaleNo, "National Number is used for another person!");

            }
            else
            {
                errorProvider1.SetError(txtNationaleNo, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (!_HandlePersonImage())
                return;

            int NationalityCountryId = clsCountry.Find(cbCountry.Text).ID;

            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.NationalNo = txtNationaleNo.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;

            _Person.NationalityCountryID = NationalityCountryId;

            if (rbMale.Checked)
                _Person.Gendor = (short)enGendor.Male;
            else
                _Person.Gendor = (short)enGendor.Female;

            if (pbPersonImage.ImageLocation != null)
                _Person.ImagePath = pbPersonImage.ImageLocation;
            else
                _Person.ImagePath = "";

            if (_Person.Save())
            {
                lblPersonID.Text = _Person.PersonID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblMainTitle.Text = "Update Person";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
