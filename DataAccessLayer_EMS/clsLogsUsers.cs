using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_EMS
{
    public class clsLogsUsers
    {
        public static DataTable GetAllLogs()
        {
            string query = @"SELECT UserName,DateOfAction,Action FROM Logs INNER JOIN Users ON Users.IDUsers = Logs.IDUsers";
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
