using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

using DVLD_DataAccess;

namespace DVDL_business
{
    public class clsTest
    {

       
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public clsTestAppointments TestAppointmentInfo;
        public byte TestResult { get; set; }
        public string Notes { get; set; }
        public int CrearedByUserID { get; set; }
        public clsUser CreatedByUserInfo;

        clsTest()
        {
            TestID = -1;
            TestAppointmentID = -1;
            TestResult = 0;
            Notes = "";
            CrearedByUserID= -1;

        }


        clsTest(int testID, int testAppointmentID, byte testResult, string notes,int crearedByUserID)
        {
            TestID=testID;
            TestAppointmentID=testAppointmentID;
            TestAppointmentInfo = clsTestAppointments.Find(testAppointmentID);
            TestResult=testResult;
            Notes=notes;
            CrearedByUserID=crearedByUserID;
            CreatedByUserInfo = clsUser.Find(crearedByUserID);

        }


        private bool _AddNewTest()
        {
            TestID = clsTestData.AddNewTest(this.TestAppointmentID, this.TestResult, this.Notes, this.CrearedByUserID);
            return (TestID != -1);
        }


        public static clsTest Find(int TestID)
        {
            int testAppointmentID = -1,  createdByUserId = -1;
            byte testResult = 0;
            string notes = "";

            bool isFound = clsTestData.GetTestByID(TestID, ref testAppointmentID, ref testResult, ref notes, ref createdByUserId);

            if (isFound)
            {
                return new clsTest(TestID,testAppointmentID,testResult,notes,createdByUserId);
            }
            else
            {
                return null;
            }
        }

        public static clsTest FindByTestAppointmentID(int testAppointmentID)
        {
            int testID = -1, createdByUserId = -1;
            byte testResult = 0;
            string notes = "";

            bool isFound = clsTestData.GetTestByTestAppointmentID(ref testID, testAppointmentID, ref testResult, ref notes, ref createdByUserId);

            if (isFound)
            {
                return new clsTest(testID, testAppointmentID, testResult, notes, createdByUserId);
            }
            else
            {
                return null;
            }
        }



        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTestData.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }


        public bool Save()
        {
            return _AddNewTest();
        }



    }
}
