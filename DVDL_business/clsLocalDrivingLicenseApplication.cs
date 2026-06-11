using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DVDL_business
{
    public class clsLocalDrivingLicenseApplication :  clsApplication
    {
        public enum enMode { eAddNew = 0, eUpdate = 1 }
        public enMode _Mode = enMode.eAddNew;

        public int LocalDrivingLicenceApplicationID { get; set; }

        public int LisenceClassID { get; set; }
        public clsLicenseClasses LicenseClassInfo;


        public clsLocalDrivingLicenseApplication()
        {
            LocalDrivingLicenceApplicationID = -1;
            LisenceClassID = -1;

            _Mode = enMode.eAddNew;
        }
        

    }
}
