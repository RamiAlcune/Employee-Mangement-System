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
    }
}
