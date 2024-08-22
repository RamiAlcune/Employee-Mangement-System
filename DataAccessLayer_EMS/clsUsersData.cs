using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_EMS
{
    public static class clsUsersData
    {

        public static DataTable GetAllUsers()
        {
            string query = @"SELECT IDUsers,UserName,Password,Roles FROM Users INNER join UserRoles ON UserRoles.IDUserRoles = Users.IDUserRoles";
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows) dt.Load(reader);



                }

            }
            return dt;
        }

        public static void GetUserPermission(int ID)
        {
            string query = @"SELECT Permissions from ";
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows) dt.Load(reader);



                }

            }
        }

        public static int IsUserNameAndPasswordAreValid(string UserName,string Password)
        {
            string query = @"SELECT UserName,Password,Permissions FROM Users INNER JOIN UserRoles ON UserRoles.IDUserRoles = Users.IDUserRoles WHERE @UserName = UserName AND @Password = Password";
            int Permissions = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
              

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Permissions = int.Parse(reader["Permissions"].ToString());
                        return Permissions;
                    }
                    else
                    {
                        return -1;
                    }




                }

            }
        }
    }
}
