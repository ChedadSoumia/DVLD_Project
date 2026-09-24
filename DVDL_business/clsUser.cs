using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;



namespace DVDL_business
{
    public class clsUser
    {
        [Flags]
        public enum enPermissions
        {
            None = 0,

            AddUser = 1,
            ChangePassword = 2,
            Dashboard = 4,
            LocalLicense = 8,
            InternationalLicense = 16,
            ReplacementLicense = 32,
            ReleaseDetainedLicense = 64,

            All = AddUser | ChangePassword | Dashboard | LocalLicense | InternationalLicense| ReplacementLicense | ReleaseDetainedLicense
        }

        public enPermissions Permissions = enPermissions.None;

        public enum _enMode {AddNew = 0, Update =1};
        public _enMode _Mode = _enMode.AddNew;
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public clsPerson clsPerson;
        public string UserName { get; set; }

        private string _hashPassword;

        public bool IsActive { get; set; }

        public int LoginHistoryID { get; set; }

        public clsUser()
        {
            this.UserID = -1; 
            this.PersonID= -1;
            this.UserName = "";
            this._hashPassword = "";
            this.IsActive = false;
            this.Permissions = enPermissions.None;
            
            _Mode = _enMode.AddNew;
        }
        public clsUser(int UserId,int PersonId, string Username, string HashPassword, bool IsActive,enPermissions permissions)
        {
            this.UserID = UserId;
            this.PersonID = PersonId;
            clsPerson = clsPerson.Find(PersonId);
            this.UserName = Username;
            this._hashPassword = HashPassword;
            this.IsActive = IsActive;
            this.Permissions = permissions;

            _Mode = _enMode.Update;
        }
        public static clsUser Find(int UserID)
        {
            int PersonID = -1;
            string Username = "", HashPassword = "";
            bool IsActive = false;
            enPermissions permissions = enPermissions.None;
            int p = (int)permissions;
            bool isFound = clsUserData.GetUserInfoByID(UserID, ref PersonID,ref Username, ref HashPassword, ref IsActive, ref p);

            if (isFound)
            {
                return new clsUser(UserID,PersonID,Username,HashPassword,IsActive, (enPermissions)p);
            }
            else
            {
                return null;
            }

        }
        public static clsUser Find(string Username)
        {
            int UserID = -1,PersonID = -1;
            string HashPassword = "";
            bool IsActive = false;
            enPermissions permissions = enPermissions.None;
            int p = (int)permissions;
            bool isFound = clsUserData.GetUserInfoByUserName(ref UserID,ref PersonID,Username,ref HashPassword,ref IsActive,ref p);

            if (isFound)
            {
                return new clsUser(UserID,PersonID,Username,HashPassword,IsActive,(enPermissions)p);
            }
            else
            {
                return null;
            }

        }
        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "", HashPassword = "";
            bool IsActive = false;
            enPermissions permissions = enPermissions.None;
            int p = (int)permissions;

            bool IsFound = clsUserData.GetUserInfoPersonID
                                (ref UserID, PersonID, ref UserName, ref HashPassword, ref IsActive,ref p);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUser(UserID, UserID, UserName, HashPassword, IsActive, (enPermissions)p);
            else
                return null;
        }
        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }
        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }
        public static bool IsUserExist(int UserID)
        {
            return clsUserData.IsUserExist(UserID);
        }
        public static bool IsUserExist(string username)
        {
            return clsUserData.IsUserExist(username);
        }
        public static bool PersonIsUser(int PersonID){
            return clsUserData.IsUserExistForPersonID(PersonID);
        }
        private bool _AddNewUser(string Password)
        {
            this._hashPassword = clsSecurity.ComputeHash(Password);
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName, this._hashPassword, this.IsActive,(int)this.Permissions);
            return (this.UserID != -1);
        }
        private bool _UpdateUser(string Password)
        {
            this._hashPassword = clsSecurity.ComputeHash(Password);
            return clsUserData.UpdateUser(this.UserID,this.PersonID,this.UserName,this._hashPassword,this.IsActive, (int)this.Permissions);
        }
        public bool Save(string Password)
        {
            switch(_Mode){
                case _enMode.AddNew:
                    if (_AddNewUser(Password))
                    {
                        _Mode = _enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case _enMode.Update:
                    return _UpdateUser(Password);
            }
            return false;
        }
        public bool ChangePassword(string NewPassword)
        {
            this._hashPassword = clsSecurity.ComputeHash(NewPassword);
            return clsUserData.ChangePassword(this.UserID, this._hashPassword);
        }

        public bool VerifyPassword(string Password)
        {
            Password = clsSecurity.ComputeHash(Password);
            return (this._hashPassword == Password);
        }
    }
}
