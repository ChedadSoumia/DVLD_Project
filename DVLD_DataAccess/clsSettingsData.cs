using System;
using System.Collections.Generic;
using System.Data;
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
        public static int AddLoginHistory(int? UserID, bool IsSuccessful)
        {
            int LoginHistoryID = -1;

            using (SqlConnection connection =
                   new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command =
                       new SqlCommand("sp_AddLoginHistory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@UserID", SqlDbType.Int).Value =
                        UserID.HasValue ? (object)UserID.Value : DBNull.Value;

                    command.Parameters.Add("@IsSuccessful", SqlDbType.Bit).Value =
                        IsSuccessful;

                    SqlParameter outputID =
                        new SqlParameter("@LoginHistoryID", SqlDbType.Int);

                    outputID.Direction = ParameterDirection.Output;

                    command.Parameters.Add(outputID);

                    connection.Open();
                    command.ExecuteNonQuery();

                    LoginHistoryID = (int)outputID.Value;
                }
            }

            return LoginHistoryID;
        }

        public static bool AddLogoutHistory(int LoginID)
        {
            int RowsAffected = 0;

            using (SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command =
                    new SqlCommand("sp_AddLogoutHistory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@LoginID", SqlDbType.Int).Value = LoginID;

                    connection.Open();

                    RowsAffected = command.ExecuteNonQuery();
                }
            }

            return RowsAffected > 0;
        }

        public static DataTable LoginUsersHistory()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query =
              @"sp_LogsUsersHistory";




            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }
    }
}
