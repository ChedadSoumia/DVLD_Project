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
                return base.PersonInfo.FullName;
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

                clsApplication application = clsApplication.FindBaseApplication(localDrivingLicenceApplicationId);

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




        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplications(this.LocalDrivingLicenceApplicationID,this.ApplicationID,this.LicenseClassID);
        }

        private bool _AddLocalDrivingLicenseApplication()
        {
            LocalDrivingLicenceApplicationID = clsLocalDrivingLicenseApplicationData.AddNewLocalApplication(this.ApplicationID,this.LicenseClassID);

            return (LocalDrivingLicenceApplicationID != -1);
        
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


    }
}
