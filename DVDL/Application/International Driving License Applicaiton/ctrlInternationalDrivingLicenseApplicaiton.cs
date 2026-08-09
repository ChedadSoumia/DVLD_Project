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

namespace DVDL.Application.International_Driving_License_Applicaiton
{

   

    public partial class ctrlInternationalDrivingLicenseApplicaiton : UserControl
    {

        private clsInternationalDrivingLicenseApplicaiton _InternationalLicenseInfo;
        private clsPerson _PersonInfo;

        public ctrlInternationalDrivingLicenseApplicaiton()
        {
            InitializeComponent();
        }

        private void _LoadPersonImage()
        {
            if (_PersonInfo.Gendor == 0)
                pbPersonImage.Image = Resources.Man;
            else
                pbPersonImage.Image = Resources.Woman;

            string ImagePath = _PersonInfo.ImagePath;
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

        public void LoadInternationalInfo(int InternationalLicenseID)
        {

            if (InternationalLicenseID == -1)
                return;

             _InternationalLicenseInfo= clsInternationalDrivingLicenseApplicaiton.FindByID(InternationalLicenseID);

            if (_InternationalLicenseInfo == null)
            {
                
                return;
            }


            lblIntApplicationID.Text = InternationalLicenseID.ToString();
            lblApplicationID.Text= _InternationalLicenseInfo.ApplicationID.ToString();
            lblLicenseID.Text = _InternationalLicenseInfo.IssuedUsingLocalLicenseID.ToString();
            lblIsActive.Text = (_InternationalLicenseInfo.IsActive) ? "Yes" : "No";
            lblDriverID.Text = _InternationalLicenseInfo.DriverID.ToString();

            _PersonInfo = clsDriver.FindByID(_InternationalLicenseInfo.DriverID).PersonInfo;

            lblName.Text = _PersonInfo.FullName;
            lblNationalNo.Text = _PersonInfo.NationalNo;
            lblGendor.Text = (_PersonInfo.Gendor == 0) ? "Male" : "Female";
            lblDateOfBirth.Text = clsFormat.DateToShort(_PersonInfo.DateOfBirth);


            lblIssueDate.Text = clsFormat.DateToShort(_InternationalLicenseInfo.IssueDate);
            lblExpirationDate.Text = clsFormat.DateToShort(_InternationalLicenseInfo.ExpirationDate);


            _LoadPersonImage();
        }
    }
}
