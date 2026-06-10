using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_business
{
    public class clsApplication
    {
        enum enMode { eAddNew = 0, eUpdate = 1 }
        enMode _Mode = enMode.eAddNew;
        public enum enApplicationType {eNewDrivingLicense= 1, eRenewDrivingLicense= 2 , eReplaceLostDrivingLicense = 3,
            eReplaceDamagedDrivingLicense = 4, eReleaseDetainedDrivingLicense=5, eNewInternationalLicense=6,eRetakeTest=7
        };
        public enum enApplicationStatus {eNew=1, eCancelled = 2, eCompleted = 3 };
        public int ApplicationID {  get; set; }

        public int ApplicantPersonID { get; set; }

        public string ApplicantFullName
        {
            get
            {
                return clsPerson.Find(ApplicantPersonID).FullName;
            }
        }

        public clsPerson PersonInfo;
        public DateTime ApplicationDate { get; set; }

        public int ApplicationTypeID { get; set; }
        public clsApplicationType ApplicationTypeInfo;


        public enApplicationStatus ApplicationStatus { get; set; }
        
        public string StatusText
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.eNew:
                        return "New";
                    case enApplicationStatus.eCancelled:
                        return "Cancelled";
                    case enApplicationStatus.eCompleted:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }
        }
        
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID {  get; set; }
        public clsUser CreatedByUserInfo;
        public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.eNew;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.CreatedByUserInfo = clsUser.Find(CreatedByUserID);
            _Mode = enMode.eAddNew;
        }
        private clsApplication(int applicationID,int applicantPersonId,DateTime applicationDate,int applicationTypeID,
            enApplicationStatus applicationStatus,DateTime lastStatusDate,float paidFees,int createdByUserID)
        {
            this.ApplicationID = applicationID;
            this.ApplicantPersonID = applicantPersonId;
            PersonInfo = clsPerson.Find(applicantPersonId);
            this.ApplicationDate = applicationDate;
            this.ApplicationTypeID = applicationTypeID;
            ApplicationTypeInfo = clsApplicationType.Find(ApplicationTypeID);
            this.ApplicationStatus = applicationStatus;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;

            _Mode = enMode.eUpdate;
        }

        public clsApplication Find(int ApplicationId)
        {
         int applicantPersonID = -1;
            DateTime applicationDate = DateTime.Now, LastStatusDate = DateTime.Now;
            int appliactionTypeID = -1;
            byte applicationSatus = 1;
            float paidFees = 0; 
            int createdByUserID = -1;

            bool IsFound = clsApplicationData.GetApplicationByID(ApplicationId,ref applicantPersonID, ref applicationDate,ref appliactionTypeID,ref applicationSatus,
                ref LastStatusDate,ref paidFees,ref createdByUserID);
            if(IsFound)
            {
                clsPerson applicantPerson = clsPerson.Find(applicantPersonID);
                return new clsApplication(ApplicationId, applicantPersonID, applicationDate, appliactionTypeID,(enApplicationStatus)applicationSatus, LastStatusDate, paidFees, createdByUserID);
            }
            else
            {
                return null;
            }


        }
        private bool _AddNewApplication()
        {
            ApplicationID = clsApplicationData.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate,this.ApplicationTypeID,
            (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return (ApplicationID != -1);
        
        }
        private bool _UpdateApplication()
        { 
        return clsApplicationData.UpdateApplication(this.ApplicationID,this.ApplicantPersonID,this.ApplicationDate, this.ApplicationTypeID,
            (byte)this.ApplicationStatus, this.LastStatusDate,this.PaidFees,this.CreatedByUserID);
        }

        public bool Cancel()
        {
            return clsApplicationData.UpdateStatus(this.ApplicationID, 2);
        }

        public bool SetComplete()
        {
            return clsApplicationData.UpdateStatus(this.ApplicationID, 3);
        }

        public bool Delete()
        {
            return clsApplicationData.DeleteApplication(this.ApplicationID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.eAddNew:
                    if (_AddNewApplication())
                    {
                        _Mode = enMode.eUpdate;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.eUpdate:
                    return _UpdateApplication();
            } 
            return false;
        }

        public static DataTable GetAllApplications()
        {
            return clsApplicationData.GetAllApplications();
        }

        public static int IfApplicationIsCancelledWithPerson(int applicantPersonID)
        {
            return clsApplicationData.IfApplicationIsCancelledWithPerson(applicantPersonID);
        }
    }

}
