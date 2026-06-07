using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsApplicationData
    {
        public static DataTable GetAllApplications()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query =
              @"
                SELECT LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, 
                        LocalDrivingLicenseApplications.LicenseClassID, People.NationalNo, 
                        Fullname =  People.FirstName + ' '+ People.SecondName +' '+ (
                                  CASE
                                    WHEN People.ThirdName is NULL THEN ''
                                    ELSE People.ThirdName
                                  END) 
                                  +' '+ People.LastName, 
                        Applications.ApplicationDate, 
                        CASE
                                  WHEN Applications.ApplicationStatus = 1 THEN 'New'
                                  WHEN Applications.ApplicationStatus = 2 THEN 'Cancelled'

                                  ELSE 'Completed'

                                  END as ApplicationStatus 
                FROM     Applications INNER JOIN
                                  LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID INNER JOIN
                                  LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID INNER JOIN
                                  People ON Applications.ApplicantPersonID = People.PersonID
                ORDER BY Applications.ApplicationDate DESC;
                ";




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
