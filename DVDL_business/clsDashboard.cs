using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_business
{
    public class clsDashboard
    {
        public static int CountPerson()
        {
            return clsDashboardData.CountPerson();
        }
        public static int CountUsers()
        {
            return clsDashboardData.CountUsers();
        }
        public static int CountDrivers()
        {
            return clsDashboardData.CountDrivers();
        }
        public static int CountActiveLicenses()
        {
            return clsDashboardData.CountActiveLicenses();
        }
        public static int CountNewApplication()
        {
            return clsDashboardData.CountNewApplication();
        }
        public static int CountApplication()
        {
            return clsDashboardData.CountApplication();
        }
        public static int CancelledApplication()
        {
            return clsDashboardData.CancelledApplication();
        }
        public static int CompletedApplication()
        {
            return clsDashboardData.CompletedApplication();
        }

        public static DataTable AnalyseeAppliactionTable()
        {
            return clsDashboardData.AnalyseeAppliactionTable();
        }
    }
}
