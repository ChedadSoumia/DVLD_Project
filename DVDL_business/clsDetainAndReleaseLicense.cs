using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_business
{
    public class clsDetainAndReleaseLicense
    {
        public int DetainID {  get; set; }
        public int LicenseID {  get; set; }
        public DateTime DetainDate {  get; set; }
        public float FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo;
        public bool IsReleased { get; set; }
        public Nullable<DateTime> ReleaseDate { get; set; }
        public int ReleaseByUserID { get; set; }
        public clsUser ReleaseByUserInfo;
        public int ReleaseApplicationID { get; set; }
        public clsApplication ReleaseApplicationInfo;


        public clsDetainAndReleaseLicense()
        {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.Now;
            FineFees = 0;
            CreatedByUserID = -1;
            IsReleased = false;
            ReleaseDate = null;
            ReleaseByUserID = -1;
            ReleaseApplicationID = -1;
        }

        private clsDetainAndReleaseLicense(int detainID, int licenseID, DateTime detainDate, float fineFees, int createdByUserID, bool isReleased, Nullable<DateTime> releaseDate, int releaseByUserID, int releaseApplicationID)
        {
            DetainID = detainID;
            LicenseID = licenseID;
            DetainDate = detainDate;
            FineFees = fineFees;
            CreatedByUserID = createdByUserID;
            CreatedByUserInfo = clsUser.Find(createdByUserID);
            IsReleased = isReleased;
            ReleaseDate = releaseDate;
            ReleaseByUserID = releaseByUserID;
            ReleaseByUserInfo = clsUser.Find(releaseByUserID);
            ReleaseApplicationID = releaseApplicationID;
            ReleaseApplicationInfo = clsApplication.FindBaseApplication(releaseApplicationID);
        }

        public static clsDetainAndReleaseLicense Find(int detainID)
        {
            int licenseID = -1, createdByUserID = -1, releaseByUserID = -1, releaseApplicationID=-1;
            float fineFees = 0;
            DateTime detainDate = DateTime.Now;
            Nullable <DateTime> releaseDate = null;
            bool isReleased = false;

            bool IsFound = clsDetainAndReleaseLicenseData.GetDeatedLicenseByID(detainID, ref licenseID, ref detainDate, ref fineFees, ref createdByUserID,
                ref isReleased, ref releaseDate, ref releaseByUserID,ref releaseApplicationID);
            if (IsFound)
                return new clsDetainAndReleaseLicense(detainID,licenseID,detainDate,fineFees,createdByUserID,isReleased,releaseDate,releaseByUserID,releaseApplicationID);
            else
                return null;
        }

        public static clsDetainAndReleaseLicense FindByLicenseID(int licenseID)
        {
            int detainID = -1, createdByUserID = -1, releaseByUserID = -1, releaseApplicationID = -1;
            float fineFees = 0;
            DateTime detainDate = DateTime.Now;
            Nullable<DateTime> releaseDate = null;
            bool isReleased = false;

            bool IsFound = clsDetainAndReleaseLicenseData.GetDeatedLicenseByLicenseID(licenseID, ref detainID, ref detainDate, ref fineFees, ref createdByUserID,
                ref isReleased, ref releaseDate, ref releaseByUserID, ref releaseApplicationID);
            if (IsFound)
                return new clsDetainAndReleaseLicense(detainID, licenseID, detainDate, fineFees, createdByUserID, isReleased, releaseDate, releaseByUserID, releaseApplicationID);
            else
                return null;
        }

        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainAndReleaseLicenseData.GetAllDetainedLicenses();
        }

        private bool _AddNewDetain()
        {
            this.DetainID = clsDetainAndReleaseLicenseData.AddNewDetain(this.LicenseID, this.FineFees, this.CreatedByUserID);
            return (this.DetainID != -1);
        }

        public bool Release(int releaseByUserID,int releaseApplicationID)
        {
          
            return clsDetainAndReleaseLicenseData.ReleaseDetainedLicense(this.DetainID, releaseByUserID, releaseApplicationID);

        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainAndReleaseLicenseData.IsLicenseDetained(LicenseID);
        }

        public bool Save()
        {
            return _AddNewDetain();
        }


    }
}
