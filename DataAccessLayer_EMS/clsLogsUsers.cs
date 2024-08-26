using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;

namespace DataAccessLayer_EMS
{
    public class clsLogsUsers
    {
        public static DataTable GetAllLogs()
        {
            string query = @"SELECT UserName,DateOfAction,Action FROM Logs INNER JOIN Users ON Users.IDUsers = Logs.IDUsers";
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

        public static void NewActionSaved(string TabName, string TypeOfAction, DateTime DateOfAction, int IDUsers)
        {
            string Action = $"{TabName} | {TypeOfAction} | Date: {DateOfAction}";
            string query = @"INSERT INTO Logs (DateOfAction, Action, IDUsers) 
                     VALUES (@DateOfAction, @Action, @IDUsers)";
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateOfAction", DateOfAction);
                        command.Parameters.AddWithValue("@Action", Action);
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

        public static void ClearAllLogs()
        {
            string query = @"TRUNCATE TABLE Logs;";
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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
