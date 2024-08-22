using DataAccessLayer_EMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_ESM.Properties
{
    public class clsUsers
    {
        public static DataTable GetAllUsers()
        {
            DataTable dt = clsUsersData.GetAllUsers();
            return dt;
        }
    }
}
