using BusinessLayer_ESM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer_EMS.Employee
{

    public partial class ctrlEmployeeDetails : UserControl
    {
        public ctrlEmployeeDetails()
        {
            InitializeComponent();
        }

        private void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            clsEmployeeList.AddNewEmployee(tbFirstName.Text, tbLastName.Text, tbEmail.Text, tbPhoneNumber.Text, tpHireDate.Value, tbExtraNotes.Text,int.Parse(tbDepartmentID.Text));
        }
    }
}
