using DataAccessLayer_EMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_ESM
{
    public class clsEmployeeList
    {
        public static DataTable GetEmployeeList()
        {
            DataTable dt= clsEmployeeDataList.GetAllEmployees();
            return dt;
        }

        public static bool DeleteEmployee(int ID)
        {
            if (clsEmployeeDataList.DeleteEmployee(ID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool AddNewEmployee(string FirstName, string LastName, string Email, string Phone, DateTime HireDate, string ExtraNotes,int DepartmenetID)
        {
            if (clsEmployeeDataList.AddNewEmployee(FirstName, LastName, Email, Phone, HireDate, ExtraNotes, DepartmenetID)) return true;

            return false;
        }

        public static DataTable GetEmployeeCardByID(int ID)
        {
            return clsEmployeeDataList.GetEmployeeCardByID(ID);
        }
    }
}
