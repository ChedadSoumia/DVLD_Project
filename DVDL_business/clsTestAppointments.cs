using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_business
{
    public  class clsTestAppointments
    {
        public enum enTestTypes { eVisionType = 1, eWrittenType = 2, eStreetType = 3 };
        public enTestTypes TestType = enTestTypes.eVisionType;
    }
}
