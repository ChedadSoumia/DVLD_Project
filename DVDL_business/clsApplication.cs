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
        enum enMode { eNewApp = 0, eUpdate = 1}
        enMode _Mode = enMode.eNewApp;

        public enum enApplicationStatus {eNew=1, eCancelled = 2, eCompleted = 3 };
        public int ApplicationID {  get; set; }

        
        public clsPerson ApplicantPerson {  get; set; }
        public DateTime ApplicationDate { get; set; }
        public enApplicationStatus ApplicationStatus = enApplicationStatus.eNew;
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID {  get; set; }

        public clsApplication()
        {
            ApplicationID = -1;
            ApplicantPerson = null;
            ApplicationDate = DateTime.Now;
            ApplicationStatus = enApplicationStatus.eNew;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;

            _Mode = enMode.eNewApp;
        }
        private clsApplication(int applicationID,clsPerson applicantPerson,DateTime applicationDate,
            enApplicationStatus applicationStatus,DateTime lastStatusDate,float paidFees,int createdByUserID)
        {
            this.ApplicationID = applicationID;
            this.ApplicantPerson = applicantPerson;
            this.ApplicationDate = applicationDate;
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
            byte applicationSatus = 1;
            float paidFees = 0; 
            int createdByUserID = -1;

            bool IsFound = clsApplicationData.GetApplicationByID(ApplicationId,ref applicantPersonID, ref applicationDate,ref applicationSatus,
                ref LastStatusDate,ref paidFees,ref createdByUserID);
            if(IsFound)
            {
                clsPerson applicantPerson = clsPerson.Find(applicantPersonID);
                return new clsApplication(ApplicationId, applicantPerson, applicationDate, (enApplicationStatus)applicationSatus, LastStatusDate, paidFees, createdByUserID);
            }
            else
            {
                return null;
            }


        }
        private bool _AddNewApplication()
        {
            ApplicationID = clsApplicationData.AddNewApplication(this.ApplicantPerson.PersonID, this.ApplicationDate,
            (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return (ApplicationID != -1);
        
        }
        private bool _UpdateApplication()
        { 
        return clsApplicationData.UpdateApplication(this.ApplicationID,this.ApplicantPerson.PersonID,this.ApplicationDate,
            (byte)this.ApplicationStatus, this.LastStatusDate,this.PaidFees,this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.eNewApp:
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
