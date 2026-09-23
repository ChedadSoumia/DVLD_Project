
﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    static class clsDataAccessSettings
    {
        //public static string ConnectionString = "Server=.;Database=DVLD;User Id=sa;Password=sa123456;";
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
    }
}

