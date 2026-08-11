using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_business
{
    public class clsSettings
    {
        public static byte GetInternationalLicenseValidityLength()
        {
            return clsSettingsData.GetInternationalLicenseValidityLength();
        }
    }
}
