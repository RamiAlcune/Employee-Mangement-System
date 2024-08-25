using DataAccessLayer_EMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_ESM
{
    public class clsLogs
    {
        public static DataTable GetAllLogs()
        {

        return clsLogsUsers.GetAllLogs();
        }

        public static void NewActionSaved(string TabName, string TypeOfAction, DateTime DateOfAction, int IDUsers)
        {
            clsLogsUsers.NewActionSaved(TabName, TypeOfAction, DateOfAction, IDUsers);
        }

        public static void ClearAllLogs()
        {
            clsLogsUsers.ClearAllLogs();
        }

    }
}
