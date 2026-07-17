using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVDL_business.clsUser;

namespace DVDL_business
{
    public class clsDriver
    {
        public enum enMode { eAddNew = 0, eUpdate = 1 };
        public enMode Mode = enMode.eAddNew;

        public clsPerson PersonInfo;

        public int DriverID {  get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }


        public clsDriver()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now ;

            Mode = enMode.eAddNew;
        } 
        private clsDriver(int driverID, int personID, int createdByUserID, DateTime createdDate)    
        {
            DriverID = driverID;
            PersonID = personID;
            PersonInfo = clsPerson.Find(personID);
            CreatedByUserID = createdByUserID;
            CreatedDate = createdDate;

            Mode = enMode.eUpdate;
        }


        private bool _AddNewDriver()
        {
            DriverID = clsDriverData.AddNewDriver(this.PersonID,this.CreatedByUserID,this.CreatedDate);
            return (DriverID != -1);
        }

        public static clsDriver FindByID(int driverID)
        {
            int personID = -1, createdByUserID = -1;
            DateTime createdDate = DateTime.Now;

            if (clsDriverData.GetDriverByID(driverID,ref personID,ref createdByUserID,ref createdDate))
            {
                return new clsDriver(driverID,personID,createdByUserID,createdDate);
            }
            else
            {
                return null;
            }

        }
        public static clsDriver FindByPersonID(int personID)
        {
            int driverID = -1, createdByUserID = -1;
            DateTime createdDate = DateTime.Now;

            if (clsDriverData.GetDriverByPersonID(ref driverID, personID, ref createdByUserID, ref createdDate))
            {
                return new clsDriver(driverID, personID, createdByUserID, createdDate);
            }
            else
            {
                return null;
            }

        }

        public static DataTable GetAlltDrivers()
        {
            return clsDriverData.GetAlltDrivers();
        }

        public static bool IsPersonADriver(int personID)
        {
            return clsDriverData.IsPersonADriver(personID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.eAddNew:
                    if (_AddNewDriver())
                    {
                        Mode = enMode.eUpdate;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

             
            }
            return false;
        }
    }
}
