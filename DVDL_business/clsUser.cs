using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;



namespace DVDL_business
{
    public class clsUser
    {
        public enum _enMode {AddNew = 0, Update =1};
        public _enMode _Mode = _enMode.AddNew;
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public clsPerson clsPerson;
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public clsUser()
        {
            this.UserID = -1; 
            this.PersonID= -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = false;

            _Mode = _enMode.AddNew;
        }
        public clsUser(int UserId,int PersonId, string Username, string Password, bool IsActive)
        {
            this.UserID = UserId;
            this.PersonID = PersonId;
            clsPerson = clsPerson.Find(PersonId);
            this.UserName = Username;
            this.Password = Password;
            this.IsActive = IsActive;

            _Mode = _enMode.Update;
        }
        public static clsUser Find(int UserID)
        {
            int PersonID = -1;
            string Username = "", Password = "";
            bool IsActive = false;

            bool isFound = clsUserData.GetUserInfoByID(UserID, ref PersonID,ref Username, ref Password, ref IsActive);

            if (isFound)
            {
                return new clsUser(UserID,PersonID,Username,Password,IsActive);
            }
            else
            {
                return null;
            }

        }
        public static clsUser Find(string Username)
        {
            int UserID = -1,PersonID = -1;
            string Password = "";
            bool IsActive = false;

            bool isFound = clsUserData.GetUserInfoByUserName(ref UserID,ref PersonID,Username,ref Password,ref IsActive);

            if (isFound)
            {
                return new clsUser(UserID,PersonID,Username,Password,IsActive);
            }
            else
            {
                return null;
            }

        }
        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoPersonID
                                (ref UserID, PersonID, ref UserName, ref Password, ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUser(UserID, UserID, UserName, Password, IsActive);
            else
                return null;
        }
        public static clsUser FindByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int PersonID = -1;

            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByUserNameAndPassword
                                (ref UserID, ref PersonID, UserName, Password, ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
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
        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);
            return (this.UserID != -1);
        }
        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.UserID,this.PersonID,this.UserName,this.Password,this.IsActive);
        }
        public bool Save()
        {
            switch(_Mode){
                case _enMode.AddNew:
                    if (_AddNewUser())
                    {
                        _Mode = _enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case _enMode.Update:
                    return _UpdateUser();
            }
            return false;
        }
        public bool ChangePassword()
        {
            return clsUserData.ChangePassword(this.UserID, this.Password);
        }

    
    }
}
