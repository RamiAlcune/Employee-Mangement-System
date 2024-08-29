using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_EMS
{
    public class clsSalaryData
    {

        public static DataTable GetAllSalary()
        {
            string query = @"
            SELECT 
                Employee.EmployeeID,
                Employee.FirstName,
                Employee.LastName,
                FORMAT(Salary.Amount, 'C', 'en-US') AS Amount, -- Format as currency
                Salary.Date 
            FROM Salary 
            INNER JOIN Employee ON Employee.EmployeeID = Salary.EmployeeID";

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
