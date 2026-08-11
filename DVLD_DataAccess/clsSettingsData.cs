using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsSettingsData
    {
        public static byte GetInternationalLicenseValidityLength()
        {
            byte InternationalLicenseValidityLength = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"  
                            SELECT TOP 1 Settings.InternationalLicenseValidityLength 
                            FROM		 Settings;";

            SqlCommand command = new SqlCommand(query, connection);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte insertedID))
                {
                    InternationalLicenseValidityLength = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return InternationalLicenseValidityLength;
        }
    }
}
