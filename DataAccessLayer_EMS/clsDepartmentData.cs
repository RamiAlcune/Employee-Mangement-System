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
    Department.DepartmentName;
";
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

        public static void UpdateDepartment(ref int DepartmentID,ref int DepartmentName)
        {
            string query = @"INSERT INTO Employee (FirstName,LastName,Email,Phone,HireDate,DepartmentID) VALUES (@FirstName,@LastName,@Email,@Phone,@HireDate,@DepartmentID)";

        }

        public static bool AddNewEmployee(int DepartmentName)
        {
            int rowAffected = 0;
            string query = @"INSERT INTO Employee (DepartmentName) VALUES (@DepartmentName)";

            using (SqlConnection connection = new SqlConnection())
            {

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DepartmentName", DepartmentName);
                    connection.Open();
                    rowAffected = command.ExecuteNonQuery();

                    if (rowAffected > 0) {
                        return true;
                    }

                }
            }
            return false;
        }
    }
}
