using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
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

        public static int AddLoginHistory(int? UserID, bool IsSuccessful)
        {
            return clsSettingsData.AddLoginHistory(UserID, IsSuccessful);

        }
        public static bool AddLogoutHistory(int LoginID)
        {
            return clsSettingsData.AddLogoutHistory(LoginID);
        }

        public static DataTable LoginUsersHistory()
        {
            return clsSettingsData.LoginUsersHistory();
        }
}
}

