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
   
    public class TestAppointmentEventArgs
    {
        public int AppointmentID { get; }
        public int ApplicationID { get; }
        public string ApplicantName { get; }
        public string ApplicantEmail { get; }
        public int TestTypeID { get; }
        public DateTime AppointmentDate { get; }

        public TestAppointmentEventArgs(
            int appointmentID,
            int applicationID,
            string applicantName,
            string applicantEmail,
            int testTypeID,
            DateTime appointmentDate)
        {
            AppointmentID = appointmentID;
            ApplicationID = applicationID;
            ApplicantName = applicantName;
            ApplicantEmail = applicantEmail;
            TestTypeID = testTypeID;
            AppointmentDate = appointmentDate;
        }
    }
    public  class clsTestAppointments
    {

        public event EventHandler<TestAppointmentEventArgs> OnTestBooked;
        public event EventHandler<TestAppointmentEventArgs> OnTestBookedUpdated;
        public enum enMode { eAddNew = 0, eUpdate = 1 };
        public enMode Mode = enMode.eAddNew;

        public int TestAppointmentID { set; get; }
        public clsTestTypes.enTestType TestTypeID { set; get; }
        public clsTestTypes TestTypesInfo;
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
            this.LocalDrivingLicenseApplicationID = -1;
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
            this.TestTypesInfo = clsTestTypes.Find(testTypeId);
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

            if (this.TestAppointmentID != -1)
            {
                if (OnTestBooked != null)
                {
                    LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplication.FindlocalDrivingLicenceApplicationID(this.LocalDrivingLicenseApplicationID);
                    OnTestBooked(this, new TestAppointmentEventArgs(this.TestAppointmentID, this.LocalDrivingLicenseApplicationInfo.ApplicationID,
                        this.LocalDrivingLicenseApplicationInfo.ApplicantFullName, this.LocalDrivingLicenseApplicationInfo.PersonInfo.Email, (int)this.TestTypeID,
                                                    this.AppointmentDate));
                }
            }

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
            bool IsUpdated = clsTestAppointmentsData.UpdateTestAppointment(this.TestAppointmentID, (int)this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);

           if(IsUpdated)
            {
                if (OnTestBookedUpdated != null)
                {
                    OnTestBookedUpdated(this, new TestAppointmentEventArgs(this.TestAppointmentID, this.LocalDrivingLicenseApplicationInfo.ApplicationID,
                        this.LocalDrivingLicenseApplicationInfo.ApplicantFullName, this.LocalDrivingLicenseApplicationInfo.PersonInfo.Email, (int)this.TestTypeID,
                                                    this.AppointmentDate));
                }
            }

            return IsUpdated;
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
