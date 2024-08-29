using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Security.Policy;

namespace DataAccessLayer_EMS
{
    public class clsPositionData
    {

        public static DataTable GetAllPositions()
        {
            string query = @"SELECT Position.PositionID,Position.PositionName From Position";
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



        public static bool AddNewPosition(string PositionName)
        {
            string query = "INSERT INTO Position (PositionName) VALUES (@PositionName)";
            int rowaffected = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PositionName", PositionName);
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

        public static bool DeletePosition(int PositionID)
        {
                int rowaffected = 0;
                string query = @"DELETE FROM Position WHERE PositionID = @PositionID";
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@PositionID", PositionID);
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
    }
}
