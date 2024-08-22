using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_EMS
{
    public static class clsUsersData
    {

        public static DataTable GetAllUsers()
        {
            string query = @"SELECT IDUsers,UserName,Password,Roles FROM Users INNER join UserRoles ON UserRoles.IDUserRoles = Users.IDUserRoles";
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
