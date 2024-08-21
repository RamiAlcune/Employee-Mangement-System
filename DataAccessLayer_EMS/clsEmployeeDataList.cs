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
                
                using (SqlCommand command = new SqlCommand(query, connection)) { 
                connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows) dt.Load(reader);


                
                }

            }
            return dt;
        }
        
        public static bool DeleteEmployee(int ID)
        {
            int rowaffected = 0;
            string query = @"DELETE FROM Employee WHERE @ID = EmployeeID";
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@ID",ID);
                    rowaffected = command.ExecuteNonQuery();
                    if (rowaffected > 0) {
                        return true;
                    }

                }
            }


            return false;
        }


    }
}
