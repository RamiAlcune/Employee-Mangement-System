using DataAccessLayer_EMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_ESM
{
    public class clsEmployeeList
    {
        public int EmployeeID { get; }
        public string FirstName { get;}
        public string LastName { get;}
        public int Gender { get;}
        public DateTime HireDate { get;}
        public string ExtraNotes { get;}
        public int DepartmenetID { get;}
        public int PoisonID { get;}
        public string Email { get;}
        public string Phone { get;}
        public string Location { get;}

        public clsEmployeeList(string firstName, string lastName, int gender, DateTime hireDate, string extraNotes, int departmenetID, int poisonID, string email, string phone, string location)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            HireDate = hireDate;
            ExtraNotes = extraNotes;
            DepartmenetID = departmenetID;
            PoisonID = poisonID;
            Email = email;
            Phone = phone;
            Location = location;
        }
        private clsEmployeeList()
        {
            FirstName = "";
            LastName = "";
            Gender = -1;
            HireDate = DateTime.Now;
            ExtraNotes = "";
            DepartmenetID = -1;
            PoisonID = -1;
            Email = "";
            Phone = "";
            Location = "";
        }

        public static bool UpdateEmployee(int EmployeeID, string FirstName, string LastName, int Gender, DateTime HireDate, string ExtraNotes, int DepartmentID, int PositionID, string Email, string Phone, string Location)
        {
            return clsEmployeeDataList.UpdateEmployee( EmployeeID,  FirstName,  LastName,  Gender,  HireDate,  ExtraNotes,  DepartmentID,  PositionID,  Email,  Phone, Location);
        }
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

        public static bool AddNewEmployee(string FirstName, string LastName,int Gender, DateTime HireDate, string ExtraNotes, int DepartmentID,int PositionID, string Email, string Phone, string Location)
        {
            if (clsEmployeeDataList.AddNewEmployee(FirstName,LastName,Gender,HireDate,ExtraNotes,DepartmentID,PositionID,Email,Phone,Location)) return true;

            return false;
        }

        public static DataTable GetEmployeeCardByID(int ID)
        {
            return clsEmployeeDataList.GetEmployeeCardByID(ID);
        }

        public static clsEmployeeList Find(int EmployeeID)
        {
            string FirstName = "", LastName = "", ExtraNotes="", Phone="", Location="", Email="";
            int Gender = -1, DepartmentID = -1, PositionID = -1;
            DateTime HireDate = DateTime.Now;
            bool isFound = clsEmployeeDataList.GetEmployeeInfoByID(EmployeeID,ref FirstName,ref LastName,ref Gender,ref HireDate,ref ExtraNotes,ref DepartmentID,ref PositionID,ref Email,ref Phone,ref Location);

            if(isFound) return new clsEmployeeList(FirstName, LastName,Gender,HireDate,  ExtraNotes,  DepartmentID,  PositionID,  Email,  Phone,  Location);
            else return null;
        }




    }
}
