using DVDL.Global_Classes;
using DVDL.Properties;
using DVDL_business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL.License
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        private int _LicenseID=-1;
        private clsLicenses _LicenseInfo;

        public int LicenseID
        {
            get { return _LicenseID; }
        }

        public clsLicenses SelectedLicenseInfo {  get { return _LicenseInfo; } }


      

        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }
        private void _LoadPersonImage()
        {
            if (_LicenseInfo.DriverInfo.PersonInfo.Gendor == 0)
                pbPersonImage.Image = Resources.Man;
            else
                pbPersonImage.Image = Resources.Woman;

            string ImagePath = _LicenseInfo.DriverInfo.PersonInfo.ImagePath;
            if (ImagePath != "")
            {
                if (File.Exists(ImagePath))
                {
                    pbPersonImage.ImageLocation = ImagePath;
                }
                else
                {
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void _LoadLicenseDate()
        {
            lblLicenseClass.Text = _LicenseInfo.LicenseClassesInfo.ClassName;
            lblName.Text = _LicenseInfo.ApplicationInfo.ApplicantFullName;
            lblLicenseID.Text = _LicenseInfo.LicenseID.ToString();
            lblNationalNo.Text = _LicenseInfo.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = (_LicenseInfo.DriverInfo.PersonInfo.Gendor == 0) ? "Male" : "Female";

            lblIssueDate.Text = clsFormat.DateToShort(_LicenseInfo.IssueDate);
            lblIssueReason.Text = _LicenseInfo.IssueReasonText;
            lblNotes.Text = (_LicenseInfo.Notes == "") ?"No Notes": _LicenseInfo.Notes;

            lblIsActive.Text = (_LicenseInfo.IsActive) ? "Yes" : "No";
            lblDateOfBirth.Text = clsFormat.DateToShort(_LicenseInfo.DriverInfo.PersonInfo.DateOfBirth);
            lblDriverID.Text = _LicenseInfo.DriverID.ToString();
            lblExpirationDate.Text = clsFormat.DateToShort(_LicenseInfo.ExpirationDate);

            lblIsDetained.Text = "[???]";

            _LoadPersonImage();
        }
            
        
        public void LoadLicenseInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _LicenseInfo = clsLicenses.Find(LicenseID);
            if (_LicenseInfo != null) {
                _LoadLicenseDate();
            }
            else
            {
                MessageBox.Show("Could not find License ID = " + _LicenseID.ToString(),
                                 "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1; return;
            }
        }

    }
}
