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

    }
}
