using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_business
{
    public class clsLicenseClasses
    {
        public int LicenseClassID {  get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }
        private clsLicenseClasses(int licenseClassID, string className,string classDescription,byte minimumAllowedAge,
            byte defaultValidityLength, float classFees) {
            this.LicenseClassID = licenseClassID;
            this.ClassName = className;
            this.ClassDescription = classDescription;
            this.MinimumAllowedAge = minimumAllowedAge;
            this.DefaultValidityLength = defaultValidityLength;
            this.ClassFees = classFees;
        }
        public static clsLicenseClasses Find(int licenseClassID)
        {
            string className = "", classDescription = "";
            byte minimumAllowedAge = 0, defaultValidityLength = 0;
            float classFees = 0;


            bool isFound = clsLicenseClassesData.GetLicenseClassByID(licenseClassID, ref className, ref classDescription, ref minimumAllowedAge,
            ref defaultValidityLength, ref classFees);
            if (isFound) {
                return new clsLicenseClasses(licenseClassID, className, classDescription, minimumAllowedAge,
            defaultValidityLength, classFees);
            }
            else
            {
                return null;
            }
        }
        public static clsLicenseClasses Find(string className)
        {
            int licenseClassID = -1;
            string classDescription = "";
            byte minimumAllowedAge = 0, defaultValidityLength = 0;
            float classFees = 0;


            bool isFound = clsLicenseClassesData.GetLicenseClassByName(ref licenseClassID, className, ref classDescription, ref minimumAllowedAge,
            ref defaultValidityLength, ref classFees);
            if (isFound)
            {
                return new clsLicenseClasses(licenseClassID, className, classDescription, minimumAllowedAge,
            defaultValidityLength, classFees);
            }
            else
            {
                return null;
            }
        }
        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassesData.GetAllLicenseClasses();
        }


        private bool _UpdateLicenseClass()
        {
            return clsLicenseClassesData.UpdateLicenseClass(this.LicenseClassID, this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
        }

        public bool Save()
        {
            return _UpdateLicenseClass();
        }


    }
}

