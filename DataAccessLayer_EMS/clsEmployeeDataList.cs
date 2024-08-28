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

        public static bool AddNewEmployee(string FirstName, string LastName, int Gender, DateTime HireDate, string ExtraNotes, int DepartmentID, int PositionID, string Email, string Phone, string Location)
        {
            int EmployeeID = -1;
            string query = @"INSERT INTO Employee (FirstName, LastName, Gender, HireDate, ExtraNotes, DepartmentID, PositionID) 
                     VALUES (@FirstName, @LastName, @Gender, @HireDate, @ExtraNotes, @DepartmentID, @PositionID); 
                     SELECT SCOPE_IDENTITY();";

            string query2 = @"INSERT INTO Contact (EmployeeID, Phone, Email, Location) 
                      VALUES (@EmployeeID, @Phone, @Email, @Location);";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@FirstName", FirstName);
                        command.Parameters.AddWithValue("@LastName", LastName);
                        command.Parameters.AddWithValue("@Gender", Gender);
                        command.Parameters.AddWithValue("@HireDate", HireDate);
                        command.Parameters.AddWithValue("@ExtraNotes", ExtraNotes);
                        command.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                        command.Parameters.AddWithValue("@PositionID", PositionID);
                        EmployeeID = Convert.ToInt32(command.ExecuteScalar());
                    }

                    using (SqlCommand command = new SqlCommand(query2, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@Location", Location);
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                    transaction.Rollback();
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public static bool UpdateEmployee(int EmployeeID, string FirstName, string LastName, int Gender, DateTime HireDate, string ExtraNotes, int DepartmentID, int PositionID, string Email, string Phone, string Location)
        {
            string query = @"UPDATE Employee 
                     SET FirstName = @FirstName, 
                         LastName = @LastName, 
                         Gender = @Gender, 
                         HireDate = @HireDate, 
                         ExtraNotes = @ExtraNotes, 
                         DepartmentID = @DepartmentID, 
                         PositionID = @PositionID
                     WHERE EmployeeID = @EmployeeID;";

            string query2 = @"UPDATE Contact 
                      SET Phone = @Phone, 
                          Email = @Email, 
                          Location = @Location
                      WHERE EmployeeID = @EmployeeID;";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        command.Parameters.AddWithValue("@FirstName", FirstName);
                        command.Parameters.AddWithValue("@LastName", LastName);
                        command.Parameters.AddWithValue("@Gender", Gender);
                        command.Parameters.AddWithValue("@HireDate", HireDate);
                        command.Parameters.AddWithValue("@ExtraNotes", ExtraNotes);
                        command.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                        command.Parameters.AddWithValue("@PositionID", PositionID);
                        command.ExecuteNonQuery();
                    }

                    using (SqlCommand command = new SqlCommand(query2, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@Location", Location);
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                    transaction.Rollback();
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    transaction.Rollback();
                    return false;
                }
            }
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
    WHERE Employee.EmployeeID = @ID
";


            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", ID);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
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
            return dt;
        }


        public static bool GetEmployeeInfoByID(int EmployeeID, ref string FirstName, ref string LastName, ref int Gender, ref DateTime HireDate, ref string ExtraNotes, ref int DepartmentID, ref int PositionID, ref string Email, ref string Phone, ref string Location)
        {
            string query = @"SELECT e.FirstName, e.LastName, e.Gender, e.HireDate, e.ExtraNotes, e.DepartmentID, e.PositionID, 
                            c.Email, c.Phone, c.Location
                     FROM Employee e
                     LEFT JOIN Contact c ON e.EmployeeID = c.EmployeeID
                     WHERE e.EmployeeID = @EmployeeID";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            FirstName = reader["FirstName"].ToString();
                            LastName = reader["LastName"].ToString();
                            Gender = Convert.ToInt32(reader["Gender"]);
                            HireDate = Convert.ToDateTime(reader["HireDate"]);
                            ExtraNotes = reader["ExtraNotes"].ToString();
                            DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
                            PositionID = Convert.ToInt32(reader["PositionID"]);
                            Email = reader["Email"].ToString();
                            Phone = reader["Phone"].ToString();
                            Location = reader["Location"].ToString();

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }

















    }
}
