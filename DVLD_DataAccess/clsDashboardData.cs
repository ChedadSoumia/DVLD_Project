using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsDashboardData
    {
        public static int CountPerson()
        {
            try
            {
                
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("CS_CountPerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        return Convert.ToInt32(command.ExecuteScalar());

                    }
                }
            }
            catch (Exception ex)
            {
                // Loggin here
                return 0;
                
            }
        }

        public static int CountUsers()
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("CS_CountUsers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        return Convert.ToInt32(command.ExecuteScalar());

                    }
                }
            }
            catch (Exception ex)
            {
                // Loggin here
                return 0;

            }
        }
        public static int CountDrivers()
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("CS_CountDrivers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        return Convert.ToInt32(command.ExecuteScalar());

                    }
                }
            }
            catch (Exception ex)
            {
                // Loggin here
                return 0;

            }
        }
        public static int CountActiveLicenses()
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("CS_ActiveLicenses", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        return Convert.ToInt32(command.ExecuteScalar());

                    }
                }
            }
            catch (Exception ex)
            {
                // Loggin here
                return 0;

            }
        }
        public static int CountNewApplication()
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("CS_CountNewApplication", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        return Convert.ToInt32(command.ExecuteScalar());

                    }
                }
            }
            catch (Exception ex)
            {
                // Loggin here
                return 0;

            }
        }
        public static int CancelledApplication()
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("CS_CancelledApplication", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        return Convert.ToInt32(command.ExecuteScalar());

                    }
                }
            }
            catch (Exception ex)
            {
                // Loggin here
                return 0;

            }
        }
        public static int CompletedApplication()
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("CS_CompletedApplication", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        return Convert.ToInt32(command.ExecuteScalar());

                    }
                }
            }
            catch (Exception ex)
            {
                // Loggin here
                return 0;

            }
        }
        public static int CountApplication()
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("[CS_CounTApplication]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        return Convert.ToInt32(command.ExecuteScalar());

                    }
                }
            }
            catch (Exception ex)
            {
                // Loggin here
                return 0;

            }
        }
        public static DataTable AnalyseeAppliactionTable()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("CS_AnalyseAppliationView", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)

                            {
                                dt.Load(reader);
                            }
                        }

                        connection.Close();

                    }
                }

            }
            catch (Exception ex)
            {

               
            }
            return dt;
        }

    }
}
