using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DataAccessLayer_EMS
{
    public class clsEmployeeDataList
    {
        public static DataTable GetAllEmployees()
        {
            string query = @"
select Employee.EmployeeID,FirstName,LastName,CASE
WHEN Employee.Gender = 0 THEN 'Male'
WHEN Employee.Gender = 1 THEN 'Female'
END AS Gender,
    Contact.Phone,
    Department.DepartmentName,
    Position.PositionName
	From Employee
INNER JOIN  Department ON Department.DepartmentID = Employee.DepartmentID 
INNER JOIN Contact ON Contact.EmployeeID = Employee.EmployeeID
INNER JOIN Position ON Position.PositionID = Employee.PositionID
";


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

        public static bool DeleteEmployee(int ID)
        {
            int rowaffected = 0;
            string query = @"DELETE FROM dbo.Employee WHERE EmployeeID = @ID";
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

        public static bool AddNewEmployee(string FirstName, string LastName,DateTime HireDate, string ExtraNotes, int DepartmentID, string Email, string Phone,string Location)
        {
            int EmployeeID = -1;
            string query = @"INSERT INTO Employee (FirstName,LastName,Email,Phone,HireDate,ExtraNotes,DepartmentID) 
                     VALUES (@FirstName,@LastName,@Email,@Phone,@HireDate,@ExtraNotes,@DepartmentID);" + "SELECT SCOPE_IDENTITY();";

            string query2 = @"INSERT INTO Contact (EmployeeID, Phone, Email, Location) " +
                      "VALUES (@EmployeeID, @Phone, @Email, @Location);";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@FirstName", FirstName);
                        command.Parameters.AddWithValue("@LastName", LastName);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        command.Parameters.AddWithValue("@HireDate", HireDate);
                        command.Parameters.AddWithValue("@ExtraNotes", ExtraNotes);
                        command.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                        EmployeeID = Convert.ToInt32(command.ExecuteScalar());
                        connection.Close();
                    }
                    using (SqlCommand command = new SqlCommand(query2, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@Location", Location);
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
            return false;
        }

        public static DataTable GetEmployeeCardByID(int ID)
        {
            string query = @"
select FirstName,LastName,
    Contact.Phone,
    Contact.Email,
    Contact.Location,
    Employee.ExtraNotes,
    Employee.Gender
	From Employee
INNER JOIN  Department ON Department.DepartmentID = Employee.DepartmentID 
INNER JOIN Contact ON Contact.EmployeeID = Employee.EmployeeID
INNER JOIN Position ON Position.PositionID = Employee.PositionID
";


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
