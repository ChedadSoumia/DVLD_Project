using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_business
{
    public class clsInternationalDrivingLicenseApplicaiton : clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;


        public int InternationalLicenseID { get; set; }

        public int DriverID { get; set; }

        public clsDriver DriverInfo;

        public int IssuedUsingLocalLicenseID { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        


        public clsInternationalDrivingLicenseApplicaiton()
        {

            this.ApplicationTypeID = (int)clsApplication.enApplicationType.eNewInternationalLicense;



            this.InternationalLicenseID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.IsActive = true;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private bool _AddNewInternationalDrivingLicenseApplicaiton()
        {
            this.InternationalLicenseID = clsInternationalDrivingLicenseApplicaitonData.AddNewInternationalDrivingLicenseApplicaiton(base.ApplicationID,this.DriverID,this.IssuedUsingLocalLicenseID,this.IsActive,this.CreatedByUserID);

            return (this.InternationalLicenseID != -1);
        }

        private clsInternationalDrivingLicenseApplicaiton(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,enApplicationStatus applicationStatus,DateTime LastStatusDate,
            float PaidFees,int CreatedByUserID , int internationalLicenseID ,int driverID, int issuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate, 
            bool isActive)
        {
            base.ApplicationID = ApplicationID;
            base.ApplicantPersonID = ApplicantPersonID;
            base.ApplicationDate = ApplicationDate;
            base.ApplicationTypeID = (int)clsApplication.enApplicationType.eNewInternationalLicense;
            base.ApplicationStatus = applicationStatus;
            base.PaidFees=PaidFees;
            base.CreatedByUserID= CreatedByUserID;

            this.InternationalLicenseID = internationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = driverID;
            this.DriverInfo = clsDriver.FindByID(driverID);
            this.IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
            this.IssueDate = issueDate;
            this.ExpirationDate = expirationDate;
            this.IsActive = isActive;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }



        public static clsInternationalDrivingLicenseApplicaiton FindByID(int internationalLicenseID)
        {
            int applcationID = -1, driverID = -1, issuedUsingLocalLicenseID = -1, createdByUserID = -1; ;
            DateTime issueDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now;
            bool isActive = false;

            if(clsInternationalDrivingLicenseApplicaitonData.GetInternationalDrivingLicenseApplicationByID(internationalLicenseID, ref applcationID, ref driverID, ref issuedUsingLocalLicenseID, ref issueDate, ref expirationDate, ref isActive, ref createdByUserID))
            {
                clsApplication application = clsApplication.FindBaseApplication(applcationID);
                return new clsInternationalDrivingLicenseApplicaiton(application.ApplicationID, application.ApplicantPersonID, application.ApplicationDate, application.ApplicationStatus, application.LastStatusDate,
                    application.PaidFees, application.CreatedByUserID, internationalLicenseID,driverID,issuedUsingLocalLicenseID,issueDate,expirationDate,isActive);
            }
            else 
                return null;
        }

        public bool Save()
        {

            base.Mode = (clsApplication.enMode)Mode;
            if (!base.Save())
                return false;

            return _AddNewInternationalDrivingLicenseApplicaiton();
        }

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {

            return clsInternationalDrivingLicenseApplicaitonData.GetActiveInternationalLicenseIDByDriverID(DriverID);

        }

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            return clsInternationalDrivingLicenseApplicaitonData.GetDriverInternationalLicenses(DriverID);
        }


        public static DataTable GetInternationalDrivingLicenseApplicationsList()
        {
            return clsInternationalDrivingLicenseApplicaitonData.GetInternationalDrivingLicenseApplications();
        }

    }
}
