using DataAccessLayer_EMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_ESM.Properties
{
    public class clsUsers
    {
        public static DataTable GetAllUsers()
        {
            DataTable dt = clsUsersData.GetAllUsers();
            return dt;
        }
        public static int IsUserNameAndPasswordAreValid(string UserName,string Password)
        {
            return clsUsersData.IsUserNameAndPasswordAreValid(UserName,Password);
        }

        public static int GetUserNameIdFromUserName(string UserName)
        {
            return clsUsersData.GetUserNameIdFromUserName(UserName);

        }

        public static bool DeleteUser(int ID)
        {
            return clsUsersData.DeleteUser(ID);
        }

        public static DataTable GetAllUserRoles()
        {
            return clsUsersData.GetAllUserRoles();
        }
        public static bool AddNewUser(string UserName, string Password, int IDUserRoles)
        {
            return clsUsersData.AddNewUser(UserName, Password, IDUserRoles);
        }

        public static void ChangeUserPassword(int IDUsers,string NewPassword)
        {
            clsUsersData.ChangeUserPassword(IDUsers, NewPassword);
        }


    }
}
