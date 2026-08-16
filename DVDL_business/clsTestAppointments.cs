using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVDL_business.clsTestTypes;

namespace DVDL_business
{
    public  class clsTestAppointments
    {
        public enum enMode { eAddNew = 0, eUpdate = 1 };
        public enMode Mode = enMode.eAddNew;

        public int TestAppointmentID { set; get; }
        public clsTestTypes.enTestType TestTypeID { set; get; }
        public int LocalDrivingLicenseApplicationID { set; get; }
        public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplicationInfo { set; get; }
        public DateTime AppointmentDate { set; get; }
        public float PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
        public bool IsLocked { set; get; }
        public int RetakeTestApplicationID { set; get; }
        public clsApplication RetakeTestAppInfo { set; get; }


        private int _GetTestID()
        {
            return clsTestAppointmentsData.GetTestID(TestAppointmentID);
        }
        public int TestID
        {
            get
            {
                return _GetTestID();
            }
        }
        public clsTestAppointments() {


            this.TestAppointmentID = -1;
            this.TestTypeID = clsTestTypes.enTestType.VisionTest;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.RetakeTestApplicationID = -1;
            Mode = enMode.eAddNew;
        }

       private clsTestAppointments(int testAppointmentID, clsTestTypes.enTestType testTypeId, int localDrivingLicenseApplicationID,
            DateTime appointmentDate, float paidFees, int createdByUserID, bool isLocked, int retakeTestApplicationID)
        {
            this.TestAppointmentID= testAppointmentID;
            this.TestTypeID = testTypeId;
            this.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            this.LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplication.FindlocalDrivingLicenceApplicationID(localDrivingLicenseApplicationID);
            this.AppointmentDate=appointmentDate;
            this.PaidFees= paidFees;
            this.CreatedByUserID= createdByUserID;
            this.IsLocked = isLocked;
            this.RetakeTestApplicationID= retakeTestApplicationID;
            this.RetakeTestAppInfo = clsApplication.FindBaseApplication(retakeTestApplicationID);
            
            Mode = enMode.eUpdate;
        }



        public static clsTestAppointments Find(int testAppointmentID)
        {
            int testTypeId = -1, localDrivingLicenseApplicationID = -1,
             createdByUserID = -1,  retakeTestApplicationID = -1;
            bool isLocked = false;
            float paidFees = 0;
            DateTime appointmentDate = DateTime.Now;

            bool IsFound = clsTestAppointmentsData.GetTestAppointmentByID(testAppointmentID,ref testTypeId,ref localDrivingLicenseApplicationID
                ,ref appointmentDate,ref paidFees,ref createdByUserID,ref isLocked,ref retakeTestApplicationID);


            if (IsFound)
            {
                return new clsTestAppointments(testAppointmentID,(clsTestTypes.enTestType)testTypeId,localDrivingLicenseApplicationID,appointmentDate,
                    paidFees,createdByUserID,isLocked,retakeTestApplicationID);
            }
            else
            {
                return null;
            }
        }


        public static DataTable GetAppointments(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)
        {
            return clsTestAppointmentsData.GetTestAppointmentsPerTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

      
        private bool _AddTestAppointment()
        {
            this.TestAppointmentID = clsTestAppointmentsData.AddNewTestAppointment((int)this.TestTypeID, this.LocalDrivingLicenseApplicationID,
               this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.RetakeTestApplicationID);

            return (this.TestAppointmentID != -1);
        }

        public static clsTestAppointments GetLastTestAppointment(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)
        {
            int TestAppointmentID = -1;
            DateTime AppointmentDate = DateTime.Now; float PaidFees = 0;
            int CreatedByUserID = -1; bool IsLocked = false; int RetakeTestApplicationID = -1;

            if (clsTestAppointmentsData.GetLastTestAppointment(LocalDrivingLicenseApplicationID, (int)TestTypeID,
                ref TestAppointmentID, ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))

                return new clsTestAppointments(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID,
             AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            else
                return null;

        }

        private bool _UpdateAppointmentTest()
        {
            return clsTestAppointmentsData.UpdateTestAppointment(this.TestAppointmentID, (int)this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.eAddNew:
                    if (_AddTestAppointment())
                    {
                        Mode = enMode.eUpdate;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                 case enMode.eUpdate:
                    return _UpdateAppointmentTest();
            }
            return false;
        }

    }
}
