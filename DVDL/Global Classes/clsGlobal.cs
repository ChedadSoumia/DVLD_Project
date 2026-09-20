using DVDL_business;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL.Global_Classes
{
    internal class clsGlobal
    {
       public static clsUser CurrentUser  ;
        public static string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVDL";
        public static string keyPathForDelete = @"SOFTWARE\DVDL";
        public static string valueUserame = "username";
        public static string valuePassword = "password";


        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            try
            {
                string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();

                string filePath = CurrentDirectory + "\\data.txt";

                if (Username == "" && File.Exists(filePath))
                {

                    File.Delete(filePath);
                    return true;
                }

                string dataToSave = Username + "#//#" + Password;

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(dataToSave);
                    return true;
                }

            }
            catch (Exception ex) {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            try
            {
                
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                string filePath = currentDirectory + "\\data.txt";

                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string Line;
                        while((Line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(Line);
                            string[] Result = Line.Split(new string[] { "#//#"},StringSplitOptions.None);
                            Username = Result[0];
                            Password = Result[1];
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public static bool WriteRegistryValue(string valueData )
        {
            try
            {
                // Write the value to the Registry
                Registry.SetValue(keyPath, valueUserame, valueData, RegistryValueKind.String);
                Registry.SetValue(keyPath, valuePassword, valueData, RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool ReadRegistryValue(ref string username, ref string password)
        {
            try
            {
                // Read the value from the Registry
                username = Registry.GetValue(keyPath, valueUserame, null) as string;
                password = Registry.GetValue(keyPath, valuePassword, null) as string;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool DeleteRegistryValue(string valueName)
        {
            try
            {
                // Open the registry key in read/write mode with explicit registry view
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey key = baseKey.OpenSubKey(keyPathForDelete, true))
                    {
                        if (key != null)
                        {
                            // Delete the specified value
                            key.DeleteValue(valueUserame);
                            key.DeleteValue(valuePassword);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
