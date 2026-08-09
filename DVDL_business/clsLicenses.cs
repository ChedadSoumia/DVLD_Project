using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVDL_business.clsLicenses;

namespace DVDL_business
{
    public class clsLicenses
    {
        public enum enMode { eAddNew = 0, eUpdate = 1 }
        public enMode Mode = enMode.eAddNew;

        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public clsApplication ApplicationInfo;
        public int DriverID { get; set; }
        public clsDriver DriverInfo;
        public int LicenseClass { get; set; }
        public clsLicenseClasses LicenseClassesInfo;
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public bool IsActive { get; set; }
        
        public enum enIssueReason {eFirstTime = 1,eLostreplacement = 2,eDamagedreplacement = 3,eRenewal=4 }
        public enIssueReason IssueReason {  get; set; }

        public string IssueReasonText
        {
            get
            {
                switch (IssueReason)
                {
                    case enIssueReason.eFirstTime:
                        return "First Time";
                    case enIssueReason.eLostreplacement:
                        return "Lost replacement";
                    case enIssueReason.eDamagedreplacement:
                        return "Damaged replacement";
                    case enIssueReason.eRenewal:
                        return "Renewal";
                    default:
                        return "First Time";

                }
            }
        }

        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo;


        public clsDetainAndReleaseLicense DetainInfo;
        


        public bool IsDetained
        {
            get { return clsDetainAndReleaseLicense.IsLicenseDetained(this.LicenseID); }
        }

        public clsLicenses()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClass = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = "";
            PaidFees = 0;
            IsActive = false;
            IssueReason = enIssueReason.eFirstTime;
            CreatedByUserID = -1;

            Mode = enMode.eAddNew;
        }
        private clsLicenses(int licenseId, int applicationId, int driverId,int licenseClass,DateTime issueDate,DateTime expirationDate,string notes,float paidFees,bool isActive, enIssueReason issueReason,int createdByUserId)
        {
            LicenseID=licenseId; 
            ApplicationID=applicationId;
            ApplicationInfo = clsApplication.FindBaseApplication(applicationId);
            DriverID=driverId;
            DriverInfo = clsDriver.FindByID(driverId);
            LicenseClass=licenseClass;
            LicenseClassesInfo = clsLicenseClasses.Find(licenseClass);
            IssueDate=issueDate;
            ExpirationDate=expirationDate;
            Notes=notes;
            PaidFees=paidFees;
            IsActive=isActive;
            IssueReason=issueReason;
            CreatedByUserID=createdByUserId;
            CreatedByUserInfo = clsUser.Find(createdByUserId);

            DetainInfo = clsDetainAndReleaseLicense.FindByLicenseID(licenseId);

            Mode = enMode.eUpdate;
        }

        public static clsLicenses Find(int LicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int LicenseClass = -1;
            
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = 1;
            int CreatedByUserID = -1;

            bool IsFound = clsLicenseData.GetLicenseInfoByID( LicenseID,ref ApplicationID, ref DriverID, ref LicenseClass, ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID);

            if (IsFound)
            {
                return new clsLicenses(
                    LicenseID,
                    ApplicationID,
                    DriverID,
                    LicenseClass,
                    IssueDate,
                    ExpirationDate,
                    Notes,
                    PaidFees,
                    IsActive,
                    (enIssueReason)IssueReason,
                    CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        public bool DeactivateLicense()
        {
            return clsLicenseData.DeactivateLicense(this.LicenseID);
        }

        public static bool IsLicenseExist(int LicenseID)
        {
            return clsLicenseData.IsLicenseExist(LicenseID);
        }

        private bool _AddNewLicense()
        {
            LicenseID = clsLicenseData.AddNewLicense(this.ApplicationID,this.DriverID,this.LicenseClass,this.IssueDate,this.ExpirationDate,this.Notes,this.PaidFees,(byte)this.IssueReason,this.CreatedByUserID);
            return (LicenseID != -1);
        }
        public bool Save()
        {
            return _AddNewLicense();
        }

        public static DataTable GetAllLicenses()
        {
            return clsLicenseData.GetAllLicenses();
        }
        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClass)
        {
            return clsLicenseData.GetActiveLicenseIDByPersonID(PersonID, LicenseClass);
        }


        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClass)
        {
            return (GetActiveLicenseIDByPersonID(PersonID, LicenseClass) != -1);
        }

        public bool DeactivateCurrentLicense()
        {
            return clsLicenseData.DeactivateLicense(this.LicenseID);
        }


        public clsLicenses ReplaceLicense(enIssueReason issueReason, int CreatedByUserID)
        {

            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.ApplicationInfo.ApplicantPersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (issueReason == enIssueReason.eDamagedreplacement)?
                          (int)clsApplication.enApplicationType.eReplaceDamagedDrivingLicense
                        : (int)clsApplication.enApplicationType.eReplaceLostDrivingLicense ;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.eCompleted;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find(Application.ApplicationTypeID).ApplicationTypeFees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
                return null;

            clsLicenses ReplacmentLicense = new clsLicenses();
            ReplacmentLicense.ApplicationID = Application.ApplicationID;
            ReplacmentLicense.DriverID = this.DriverID;
            ReplacmentLicense.LicenseClass = this.LicenseClass;
            ReplacmentLicense.IssueDate = DateTime.Now;


            ReplacmentLicense.ExpirationDate = this.ExpirationDate;
            ReplacmentLicense.Notes = Notes;
            ReplacmentLicense.PaidFees = 0;
            ReplacmentLicense.IsActive = true;
            
            ReplacmentLicense.IssueReason = issueReason;

            ReplacmentLicense.CreatedByUserID = CreatedByUserID;


            if (!ReplacmentLicense.Save())
            {
                Application.Delete();
                return null;
            }


            DeactivateCurrentLicense();
            return ReplacmentLicense;
        }
        public clsLicenses RenewLicence(string Notes,int CreatedByUserID)
        {
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.ApplicationInfo.ApplicantPersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.eRenewDrivingLicense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.eCompleted;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.eRenewDrivingLicense).ApplicationTypeFees;
            Application.CreatedByUserID = CreatedByUserID;
            
            if (!Application.Save())
                return null;


           clsLicenses NewLicense = new clsLicenses();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClass = this.LicenseClass;
            NewLicense.IssueDate = DateTime.Now;


            NewLicense.ExpirationDate = NewLicense.IssueDate.AddYears(this.LicenseClassesInfo.DefaultValidityLength);
            NewLicense.Notes =Notes;
            NewLicense.PaidFees = this.LicenseClassesInfo.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = clsLicenses.enIssueReason.eRenewal;
            NewLicense.CreatedByUserID = CreatedByUserID;


            if (!NewLicense.Save())
            {
                Application.Delete();
                return null;
            }


            DeactivateCurrentLicense();
            return NewLicense;            
        }


        public static DataTable GetDriverLicenses(int DriverId)
        {
            return clsLicenseData.GetDriverLicenses(DriverId);
        }

        public bool IsLicenseExpired()
        {
            return (this.ExpirationDate  < DateTime.Now);
        }

        public int Detain(float FineFees, int CreatedByUserID)
        {
            clsDetainAndReleaseLicense DetainLicense = new clsDetainAndReleaseLicense();
            DetainLicense.LicenseID = this.LicenseID;
            DetainLicense.DetainDate = DateTime.Now;
            DetainLicense.FineFees = FineFees;
            DetainLicense.CreatedByUserID = CreatedByUserID;

            if (!DetainLicense.Save())
            {
                return -1;
            }

            return DetainLicense.DetainID;

        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID , ref int ApplicationID)
        {
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.eReleaseDetainedDrivingLicense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.eCompleted;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.eReleaseDetainedDrivingLicense).ApplicationTypeFees;
            Application.CreatedByUserID = ReleasedByUserID;

            if (!Application.Save())
            {
                ApplicationID = -1;
                return false;
            }

            ApplicationID = Application.ApplicationID;

            return this.DetainInfo.Release(ReleasedByUserID, Application.ApplicationID);
        }

    }
}
