using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_business
{
    public class clsApplicationType
    {

        public int ApplicationTypeID;
        public string ApplicationTypeTitle;
        public float ApplicationTypeFees;
        private clsApplicationType(int ApplicationTypeId, string ApplicationTypeTitle,float ApplicationTypeFees) 
        {
            this.ApplicationTypeID = ApplicationTypeId;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationTypeFees = ApplicationTypeFees;
        }

        public static clsApplicationType Find(int applicationTypeID)
        {
            string applicationTypeTitle = "";
            float applicationTypeFees = 0;

            bool isFound = clsApplicationTypeData.GetAppliactionTypeByID(applicationTypeID, ref applicationTypeTitle, ref applicationTypeFees);
            if (isFound) {
                return new clsApplicationType(applicationTypeID, applicationTypeTitle, applicationTypeFees);
            }
            else
            {
                return null;
            }

        }

        public bool Save()
        {
            return clsApplicationTypeData.UpdateApplicationType(this.ApplicationTypeID,this.ApplicationTypeTitle,this.ApplicationTypeFees);
        }

        public static DataTable GetAllApplicationType()
        {
            return clsApplicationTypeData.GetAllApplicationType();
        }

    }
}
