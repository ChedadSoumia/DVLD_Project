using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDL.Global_Classes
{
    public static class clsFormat
    {
        public static string DateToShort(DateTime date)
        {
            return date.ToString("dd/MMM/yyyy");
        }

    }
}
