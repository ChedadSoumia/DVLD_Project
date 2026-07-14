using DVDL.Global_Classes;
using DVDL_business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVDL_business.clsTestTypes;

namespace DVDL.Test
{
    public partial class ctrlSecheduledTest : UserControl
    {

        private enum enMode { eAddNew = 0, eUpdate = 1 }
        private enMode _Mode = enMode.eAddNew;

        private int _TestAppointmentID = -1;
        private clsTestAppointments _TestAppointmentInfo;

        private int _TestID = -1;
        private clsTest _TestInfo;

        private clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.VisionTest;
        public clsTestTypes.enTestType TestTypeID
        {
            get { return _TestTypeID; }

            set
            {
                _TestTypeID = value;
                switch (_TestTypeID)
                {
                    case clsTestTypes.enTestType.VisionTest:
                        groupBox1.Text = "Vision Test";
                        break;
                    case clsTestTypes.enTestType.WrittenTest:
                        groupBox1.Text = "Written Test";
                        break;
                    case clsTestTypes.enTestType.StreetTest:
                        groupBox1.Text = "Street Test";
                        break;
                }
            }

        }
        private void _LoadDesign()
        {
            Design.MainLabelTitleDesign(lblMainTitle);
        }
        public ctrlSecheduledTest()
        {
            InitializeComponent();
            _LoadDesign();
        }
        private void _LoadData()
        {
            
        }

        public void LoadTestAppointmentInfo(int testAppointmentID,clsTestTypes.enTestType testTypeID)
        {
            _TestAppointmentID = testAppointmentID;
            _TestAppointmentInfo = clsTestAppointments.Find(testAppointmentID);
            _TestTypeID = testTypeID;



            _LoadData();
        }

    }
}
