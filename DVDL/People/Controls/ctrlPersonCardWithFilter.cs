using DVDL_business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL.People.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {

        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int personId)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(personId);
            }
        }

        private bool _FilterEnable = true;
        public bool FilterEnable
        {
            get { return _FilterEnable; }
            set { 
                _FilterEnable = value;
                gbFilters.Enabled = _FilterEnable;
            }
        }

        private bool _AddShowPerson = true; 
        public bool AddShowPerson
        {
            get { return _AddShowPerson; }
            set
            {
                _AddShowPerson = value;
                btAddPerson.Enabled = _AddShowPerson;
            }
        }

        private int _PersonID = -1;
        public int PersonID
        {
            get { return ctrlPersonCard1.PersonID; }
        }

        private clsPerson _Person;
        public clsPerson Person
        {
            get { return ctrlPersonCard1.SelectedPersonInfo; }
        }

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson addNewPerson = new frmAddUpdatePerson();
            addNewPerson.DataBack += DataBackEvent;
            addNewPerson.ShowDialog();
        }

        private void DataBackEvent(object sender, int PersonID)
        {
            cbFilterList.SelectedIndex = 1;
            txtFilter.Text = PersonID.ToString();
            ctrlPersonCard1.LoadPersonInfo(PersonID);
        }

        private void txtFilter_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilter.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilter, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFilter, null);
            }
        }


        private void _FindNow()
        {

            switch (cbFilterList.Text)
            {
                case "Person ID":
                    if (int.TryParse(txtFilter.Text, out int ToPersonID))
                    {
                        ctrlPersonCard1.LoadPersonInfo(ToPersonID);
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid Person ID");
                    }
                    break;
                case "National No.":
                    ctrlPersonCard1.LoadPersonInfo(txtFilter.Text);
                    break;
                default:
                    break;
            }
            
            if(OnPersonSelected != null  && FilterEnable)
            {
                OnPersonSelected(ctrlPersonCard1.PersonID);
            }

        }

        public void LoadPersonInfo(int PersonID)
        {
            cbFilterList.SelectedIndex = 0;
            txtFilter.Text = PersonID.ToString();
            _FindNow();

        }


        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            _FindNow();
        }

        private void cbFilterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            txtFilter.Focus();
        }


        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                btnFilter.PerformClick();
            }

            if (cbFilterList.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterList.SelectedIndex = 0;
            txtFilter.Focus();
        }

        public void FilterFocus()
        {
            txtFilter.Focus();
        }


    }
}
