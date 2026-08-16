using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;



namespace DVDL_business
{
    public class clsLocalDrivingLicenseApplication :  clsApplication
    {
        public enum enMode { eAddNew = 0, eUpdate = 1 }
        public enMode Mode = enMode.eAddNew;

        public int LocalDrivingLicenceApplicationID { get; set; }

        public int LicenseClassID { get; set; }
        public clsLicenseClasses LicenseClassInfo;

        public string PersonFullName
        {
            get
            {
                return base.ApplicantFullName;
            }
        }

        public clsLocalDrivingLicenseApplication()
        {
            LocalDrivingLicenceApplicationID = -1;
            LicenseClassID = -1;

            Mode = enMode.eAddNew;
        }

        private clsLocalDrivingLicenseApplication(int localDrivingLicenceApplicationID,int applicationID,int applicantPersonID, 
             DateTime applicationDate,int  applicationTypeId,enApplicationStatus applicationStatus,
             DateTime lastStatusDate,float paidFees,int createdByUserID ,int licenseClassID)
        {
            this.LocalDrivingLicenceApplicationID = localDrivingLicenceApplicationID;
            this.ApplicationID = applicationID;
            this.ApplicantPersonID = applicantPersonID;
            this.ApplicationDate = applicationDate;
            this.ApplicationTypeID = applicationTypeId;
            this.ApplicationStatus = applicationStatus;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;
            this.LicenseClassID = licenseClassID;

            this.LicenseClassInfo = clsLicenseClasses.Find(licenseClassID);

            Mode = enMode.eUpdate;
        }
        
        public static clsLocalDrivingLicenseApplication FindlocalDrivingLicenceApplicationID(int localDrivingLicenceApplicationID)
        {
            int licenseClassID = -1, applicationId=-1;

            bool isFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationID(localDrivingLicenceApplicationID,ref applicationId,ref licenseClassID);

            if (isFound) {

                clsApplication application = clsApplication.FindBaseApplication(applicationId);
                
                return new clsLocalDrivingLicenseApplication(localDrivingLicenceApplicationID,application.ApplicationID,
                    application.ApplicantPersonID,application.ApplicationDate,application.ApplicationTypeID,
                    application.ApplicationStatus,application.LastStatusDate,
                    application.PaidFees,application.CreatedByUserID,licenseClassID);
                

            }
            else
            {
                return null;
            }

        }
        public static clsLocalDrivingLicenseApplication FindByApplicationID(int applicationID)
        {
            int licenseClassID = -1, localDrivingLicenceApplicationId = -1;

            bool isFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseByApplicationID(applicationID, ref localDrivingLicenceApplicationId, ref licenseClassID);

            if (isFound)
            {

                clsApplication application = clsApplication.FindBaseApplication(applicationID);

                return new clsLocalDrivingLicenseApplication(localDrivingLicenceApplicationId, application.ApplicationID,
                    application.ApplicantPersonID, application.ApplicationDate, application.ApplicationTypeID,
                    application.ApplicationStatus, application.LastStatusDate,
                    application.PaidFees, application.CreatedByUserID, licenseClassID);


            }
            else
            {
                return null;
            }

        }


        public bool DoesAttendTestType(clsTestTypes.enTestType TestTypeID)

        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(this.LocalDrivingLicenceApplicationID, (int)TestTypeID);
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplications(this.LocalDrivingLicenceApplicationID,this.ApplicationID,this.LicenseClassID);
        }

        private bool _AddLocalDrivingLicenseApplication()
        {
            LocalDrivingLicenceApplicationID = clsLocalDrivingLicenseApplicationData.AddNewLocalApplication(this.ApplicationID,this.LicenseClassID);

            return (LocalDrivingLicenceApplicationID != -1);
        
        }

        
        public bool Delete()
        {
            bool IsLocalDrivingApplicationDeleted = false;
            bool IsBaseApplicationDeleted = false;

            IsLocalDrivingApplicationDeleted = clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplication(this.LocalDrivingLicenceApplicationID);

            if (!IsLocalDrivingApplicationDeleted)
                return false;

            IsBaseApplicationDeleted = base.Delete();

            return IsBaseApplicationDeleted;
        }

        public bool Save()
        {

            base.Mode = (clsApplication.enMode) Mode;

            if (!base.Save())
                return false;



            switch (Mode)
            {
                case enMode.eAddNew:
                    if (_AddLocalDrivingLicenseApplication())
                    {
                        Mode = enMode.eAddNew;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.eUpdate:
                    return _UpdateLocalDrivingLicenseApplication();
            }
            return false;

        }


        public bool DoesPassTheTest(clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTheTest(this.LocalDrivingLicenceApplicationID, (int)TestTypeID);
        }


        public int TrialsTest(clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TrialsTest(this.LocalDrivingLicenceApplicationID, (int)TestTypeID);
        }


        public bool  IsTestAppointmentActive( clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.IsTestAppointmentActive(this.LocalDrivingLicenceApplicationID, (int)TestTypeID);
        }

        public static bool IsTestAppointmentActive(int localDrivingLicenceApplicationID,clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.IsTestAppointmentActive(localDrivingLicenceApplicationID, (int)TestTypeID);
        }

        public clsTest GetLastTestPerTestType(clsTestTypes.enTestType TestTypeID) 
        {
            return clsTest.FindLastTestPerPersonAndLicenseClass(this.ApplicantPersonID, this.LicenseClassID, TestTypeID);
        }

        public bool PassedAllTests()
        {
            return clsTest.PassedAllTests(this.LocalDrivingLicenceApplicationID);
        }

        public int IssueLicenseForTheFirstTime(string Notes, int CreatedByUserID)
        {
            int DriverID = -1;
            clsDriver Driver = clsDriver.FindByPersonID(this.ApplicantPersonID);
            if (Driver == null)
            {
                Driver = new clsDriver();
                Driver.PersonID = this.ApplicantPersonID;
                Driver.CreatedByUserID = CreatedByUserID;

                if (Driver.Save())
                {
                    DriverID = Driver.DriverID;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                DriverID = Driver.DriverID;
            }

            clsLicenses _LicenseInfo = new clsLicenses();
            _LicenseInfo.DriverID = DriverID;
            _LicenseInfo.ApplicationID = this.ApplicationID;
            _LicenseInfo.LicenseClass = this.LicenseClassID;
            _LicenseInfo.IssueDate = DateTime.Now;
            _LicenseInfo.ExpirationDate = _LicenseInfo.IssueDate.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            _LicenseInfo.Notes = Notes;
            _LicenseInfo.PaidFees = this.LicenseClassInfo.ClassFees;
            _LicenseInfo.IsActive = true;
            _LicenseInfo.IssueReason = clsLicenses.enIssueReason.eFirstTime;
            _LicenseInfo.CreatedByUserID = CreatedByUserID;

            if (_LicenseInfo.Save())
            {
                this.SetComplete();
                return _LicenseInfo.LicenseID;
            }
            else
                return -1;

        }

        public bool IsLicenseIssued()
        {
            return (GetActiveLicenseID() != -1);
        }

        public int GetActiveLicenseID()
        {

            return clsLicenses.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, (int)this.LicenseClassID);
        }

       

    }
}
