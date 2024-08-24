using BusinessLayer_ESM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            ImplementComboBoxDepartment();
        }

        private void ImplementComboBoxDepartment()
        {
            
            cbDepartmentID.DataSource = clsDepartment.GetAllDepartmentName();
            cbDepartmentID.DisplayMember = "DepartmentName";
            cbDepartmentID.ValueMember = "DepartmentID";
            cbDepartmentID.SelectedIndex = 0;
        }
        private void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
        if (clsEmployeeList.AddNewEmployee(tbFirstName.Text, tbLastName.Text, tbEmail.Text, tbPhoneNumber.Text, tpHireDate.Value, tbExtraNotes.Text, int.Parse(cbDepartmentID.SelectedIndex.ToString())+1)) MessageBox.Show($"Has been added to DataBase: [{tbFirstName.Text} {tbLastName.Text}]", msgBox.Caption = $"Message From DataBase", MessageBoxButtons.OK, MessageBoxIcon.Information);
        else
            {
                MessageBox.Show($"Has not been  added to DataBase: [{tbFirstName.Text} {tbLastName.Text}]", msgBox.Caption = $"Message From DataBase", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
