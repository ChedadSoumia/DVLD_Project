using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_business
{
    public class clsTestTypes
    {

        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };

        public clsTestTypes.enTestType TestTypeID {  get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public float TestTypeFees { get; set; }


        private clsTestTypes(clsTestTypes.enTestType testTypeID, string testTypeTitle, string testTypeDescription, float testTypeFees)
        {
            this.TestTypeID = testTypeID;
            this.TestTypeTitle = testTypeTitle;
            this.TestTypeDescription = testTypeDescription;
            this.TestTypeFees = testTypeFees;
        }

        public static clsTestTypes Find(clsTestTypes.enTestType testTypeID)
        {
            string testTypeTitle = "", testTypeDescription = "";
            float testTypeFees = 0;

            bool isFound = clsTestTypesData.GetTestTypeByID((int)testTypeID,ref  testTypeTitle,ref testTypeDescription,ref testTypeFees);
            if (isFound)
            {
                return new clsTestTypes(testTypeID, testTypeTitle,testTypeDescription,testTypeFees);
            }
            else
            {
                return null;
            }

        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesData.GetAllTestTypes();
        }



        public bool Save()
        {
            return clsTestTypesData.UpdateTestType((int)this.TestTypeID,this.TestTypeTitle,this.TestTypeDescription,this.TestTypeFees);
        }

    }
}
