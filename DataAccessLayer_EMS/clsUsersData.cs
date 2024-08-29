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
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows) dt.Load(reader);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return dt;
        }

        public static int IsUserNameAndPasswordAreValid(string UserName, string Password)
        {
            string query = @"SELECT UserName,Password,Permissions FROM Users INNER JOIN UserRoles ON UserRoles.IDUserRoles = Users.IDUserRoles WHERE @UserName = UserName AND @Password = Password";
            int Permissions = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                try
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
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return -1;
        }

        public static int GetUserNameIdFromUserName(string UserName)
        {
            string query = @"SELECT IDUsers from Users WHERE @UserName = UserName";
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            return int.Parse(reader["IDUsers"].ToString());
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return -1;
        }

        public static bool DeleteUser(int ID)
        {
            int rowaffected = 0;
            string query = @"DELETE FROM Users WHERE IDUsers = @ID";
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", ID);
                        connection.Open();
                        rowaffected = command.ExecuteNonQuery();
                        if (rowaffected > 0)
                        {
                            return true;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return false;
        }

        public static DataTable GetAllUserRoles()
        {
            string query = @"SELECT IDUserRoles,Roles FROM UserRoles";
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows) dt.Load(reader);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return dt;
        }

        public static bool AddNewUser(string UserName, string Password, int IDUserRoles)
        {
            string query = "INSERT INTO Users (UserName,Password,IDUserRoles) VALUES (@UserName,@Password,@IDUserRoles)";
            int rowaffected = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@IDUserRoles", IDUserRoles);
                        connection.Open();
                        rowaffected = command.ExecuteNonQuery();
                        if (rowaffected > 0) return true;
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return false;
                }
            }

            return false;
        }

        public static void ChangeUserPassword(int IDUsers, string NewPassword)
        {
            string query = @"UPDATE Users SET Password = @NewPassword WHERE IDUsers = @IDUsers";
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("@NewPassword", NewPassword);
                        command.Parameters.AddWithValue("@IDUsers", IDUsers);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

    }
}
