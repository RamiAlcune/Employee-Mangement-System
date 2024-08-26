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

        public static void UpdateDepartment(ref int DepartmentID, ref int DepartmentName)
        {
            string query = @"INSERT INTO Employee (FirstName,LastName,Email,Phone,HireDate,DepartmentID) VALUES (@FirstName,@LastName,@Email,@Phone,@HireDate,@DepartmentID)";
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

        public static bool AddNewEmployee(int DepartmentName)
        {
            int rowAffected = 0;
            string query = @"INSERT INTO Employee (DepartmentName) VALUES (@DepartmentName)";

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
    }
}
