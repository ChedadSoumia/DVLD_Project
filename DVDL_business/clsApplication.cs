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



        public static DataTable GetAllApplications()
        {
            return clsApplicationData.GetAllApplications();
        }

    }

}
