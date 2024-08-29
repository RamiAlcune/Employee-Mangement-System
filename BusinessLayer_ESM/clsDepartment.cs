using DataAccessLayer_EMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_ESM
{

    public class clsDepartment
    {
        public int DepartmentID {get;}
        public string DepartmentName { get;}

        clsDepartment(int departmentID, string departmentName)
        {
            this.DepartmentID = departmentID;
            this.DepartmentName = departmentName;
        }

        public static DataTable GetAllDepartments()
        {
            return clsDepartmentData.GetAllDepartments();
        }
        
        public static DataTable GetAllDepartmentName()
        {

        return clsDepartmentData.GetAllDepartmentName();
        }

        public static bool AddNewDepartment(string Department)
        {
            if (clsDepartmentData.AddNewDepartment(Department)) return true;

            return false;   
        }

        public static bool UpdateDepartment(int DepartmentID, string DepartmentName)
        {
            return clsDepartmentData.UpdateDepartment(DepartmentID, DepartmentName);
        }

        public static bool DeleteDepartment(int DepartmentID) { 
        return clsDepartmentData.DeleteDepartment(DepartmentID);
        }

    }
}
