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

        public enum enMode { eAddNew = 1, eUpdate=2 }
        public enMode Mode = enMode.eAddNew;
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

            Mode = enMode.eAddNew;
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

            Mode = enMode.eUpdate;
        }


        private bool _AddNewTest()
        {
            TestID = clsTestData.AddNewTest(this.TestAppointmentID,this.TestResult,this.Notes,this.CrearedByUserID);
            return (TestID != -2);
        }

       






    }
}
