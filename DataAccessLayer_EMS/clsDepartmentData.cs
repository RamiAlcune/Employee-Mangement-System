using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_EMS
{
    public class clsDepartmentData
    {
        public static DataTable GetAllDepartments()
        {
            string query = @"SELECT  Department.DepartmentID,Department.DepartmentName,COUNT(Employee.EmployeeID) AS EmployeeCount
FROM 
	Department
LEFT JOIN 
    employee ON Department.DepartmentID = Employee.DepartmentID
GROUP BY 
    Department.DepartmentID, 
    Department.DepartmentName
ORDER BY 
    Department.DepartmentName;";
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

        public static bool UpdateDepartment(int DepartmentID, string DepartmentName)
        {
            string query = @"UPDATE Department SET DepartmentName = @DepartmentName WHERE DepartmentID = @DepartmentID";
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DepartmentName", DepartmentName);
                        command.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    return true;
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
        }

        public static bool AddNewDepartment(string DepartmentName)
        {
            int rowAffected = 0;
            string query = @"INSERT INTO Department (DepartmentName) VALUES (@DepartmentName)";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DepartmentName", DepartmentName);
                        connection.Open();
                        rowAffected = command.ExecuteNonQuery();

                        if (rowAffected > 0)
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

        public static DataTable GetAllDepartmentName()
        {
            string query = @"SELECT Department.DepartmentID,Department.DepartmentName From Department";
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



        public static bool DeleteDepartment(int DepartmentID)
        {
            int rowaffected = 0;
            string query = @"DELETE FROM dbo.Department WHERE DepartmentID = @DepartmentID";
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DepartmentID", DepartmentID);
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
