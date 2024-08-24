using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DataAccessLayer_EMS
{
    public class clsEmployeeDataList
    {


        public static DataTable GetAllEmployees()
        {
            string query = @"SELECT EmployeeID,FirstName,LastName,Email,Phone,HireDate,DepartmentName FROM Employee INNER join Department ON Department.DepartmentID = Employee.DepartmentID";
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

        public static bool DeleteEmployee(int ID)
        {
            int rowaffected = 0;
            string query = @"DELETE FROM dbo.Employee WHERE EmployeeID = @ID";
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
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


            return false;
        }

        public static bool AddNewEmployee(string FirstName, string LastName, string Email, string Phone, DateTime HireDate, string ExtraNotes, int DepartmentID)
        {
            string query = @"INSERT INTO Employee (FirstName,LastName,Email,Phone,HireDate,ExtraNotes,DepartmentID) 
                     VALUES (@FirstName,@LastName,@Email,@Phone,@HireDate,@ExtraNotes,@DepartmentID)";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
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
                    object RowEffected = command.ExecuteNonQuery();
                    if (RowEffected != null) return true;
                }


            }
            return false;
        }

    }
}
