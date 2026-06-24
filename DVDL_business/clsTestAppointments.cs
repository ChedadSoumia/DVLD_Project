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
        enum enMode { eAddNew = 1, eUpdate=2,eRetakeTest};
        enMode _Mode = enMode.eAddNew;

        int _TestAppointmentID =-1;
        int _TestTypeID =-1;
        clsTestTypes TestTypeInfo;
        
        int _LocalDrivingLicenseApplicationID = -1;
        clsLocalDrivingLicenseApplication LocalDrivingLicenseApplicationInfo;

        DateTime _AppointmentDate;
        float _PaidFees;
        int _CreatedByUserID = -1;
        clsUser _CreatedByUserInfo;
        byte _IsLocked;
        int _RetakeTestApplicationID = -1;
        clsApplication _RetakeTestApplicationInfo;
        public enum enTestTypes { eVisionType = 1, eWrittenType = 2, eStreetType = 3 };
        public enTestTypes TestType = enTestTypes.eVisionType;

        public clsTestAppointments() {

            _TestAppointmentID = -1;
            _TestTypeID = -1;
            TestType = enTestTypes.eVisionType;
            _LocalDrivingLicenseApplicationID = -1;
            _AppointmentDate = DateTime.Now;
            _PaidFees = 0;
            _CreatedByUserID= -1;
            _IsLocked = 0;
            _RetakeTestApplicationID=-1;
           
            _Mode = enMode.eAddNew;
        }

        public clsTestAppointments(int testAppointmentID, int testTypeId, int localDrivingLicenseApplicationID,
            DateTime appointmentDate, float paidFees, int createdByUserID, int retakeTestApplicationID)
        {

            _TestAppointmentID = testAppointmentID;
            _TestTypeID = testTypeId;
            TestType = (clsTestAppointments.enTestTypes)testTypeId;
            TestTypeInfo = clsTestTypes.Find((clsTestTypes.enTestType)TestType);
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplication.FindlocalDrivingLicenceApplicationID(localDrivingLicenseApplicationID);
            _AppointmentDate = appointmentDate;
            _PaidFees = paidFees;
            _CreatedByUserID = createdByUserID;
            _CreatedByUserInfo = clsUser.Find(createdByUserID);
            _IsLocked = 0;
            _RetakeTestApplicationID = -1;
            _RetakeTestApplicationInfo = clsApplication.FindBaseApplication(retakeTestApplicationID);

            _Mode = enMode.eRetakeTest;
        }


        private clsTestAppointments(int testAppointmentID, int testTypeId, int localDrivingLicenseApplicationID,
            DateTime appointmentDate, float paidFees, int createdByUserID, byte isLocked, int retakeTestApplicationID)
        {
            _TestAppointmentID= testAppointmentID;
            _TestTypeID= testTypeId;
            TestType = (clsTestAppointments.enTestTypes)testTypeId;
            TestTypeInfo = clsTestTypes.Find((clsTestTypes.enTestType)TestType);
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplication.FindlocalDrivingLicenceApplicationID(localDrivingLicenseApplicationID);
            _AppointmentDate = appointmentDate;
            _PaidFees= paidFees;
            _CreatedByUserID = createdByUserID;
            _CreatedByUserInfo = clsUser.Find(createdByUserID);
            _IsLocked = isLocked;
            _RetakeTestApplicationID = retakeTestApplicationID;
            _RetakeTestApplicationInfo = clsApplication.FindBaseApplication(retakeTestApplicationID);
            _Mode = enMode.eUpdate;
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
                return new clsTestAppointments(testAppointmentID,testTypeId,localDrivingLicenseApplicationID,appointmentDate,
                    paidFees,createdByUserID,isLocked,retakeTestApplicationID);
            }
            else
            {
                return null;
            }
        }


        public static DataTable GetAppointments(int LocalDrivingLicenseApplicationID, clsTestAppointments.enTestTypes TestTypeID)
        {
            return clsTestAppointmentsData.GetTestAppointments(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool IsTestAppointmentActive()
        {
            return clsTestAppointmentsData.IsTestAppointmentActive(this._LocalDrivingLicenseApplicationID,this._TestTypeID);
        }

        private bool _AddTestAppointment()
        {
            this._TestAppointmentID = clsTestAppointmentsData.AddNewTestAppointment(this._TestTypeID,this._LocalDrivingLicenseApplicationID,this._AppointmentDate,this._PaidFees,_CreatedByUserID);

            return (this._TestAppointmentID != -1);
        }

        private bool _RetakeTestAppointment()
        {
            this._TestAppointmentID = clsTestAppointmentsData.AddNewTestAppointment(this._TestTypeID, this._LocalDrivingLicenseApplicationID, this._AppointmentDate, this._PaidFees, this._CreatedByUserID);

            return (this._TestAppointmentID != -1);
        }
        private bool _UpdateAppointmentTest()
        {
            return clsTestAppointmentsData.UpdateTestAppointment(this._TestAppointmentID, this._AppointmentDate);
        }


        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.eAddNew:
                    if (_AddTestAppointment())
                    {
                        _Mode = enMode.eUpdate;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.eRetakeTest:
                    if (_RetakeTestAppointment())
                    {
                        _Mode = enMode.eUpdate;
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
