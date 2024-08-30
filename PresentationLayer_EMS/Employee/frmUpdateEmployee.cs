using BusinessLayer_ESM;
using PresentationLayer_EMS.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer_EMS
{
    public partial class frmUpdateEmployee : Form
    {
        public frmUpdateEmployee()
        {
            InitializeComponent();
            ImplementComboBox();
            ImplementDataRowToTextBoxes();
        }


        private void ImplementComboBox()
        {
            // Department
            cbDepartmentID.DataSource = clsDepartment.GetAllDepartmentName();
            cbDepartmentID.DisplayMember = "DepartmentName";
            cbDepartmentID.ValueMember = "DepartmentID";
            cbDepartmentID.SelectedIndex = 0;

            //Positions
            cbPositions.DataSource = clsPosition.GetAllPositions();
            cbPositions.DisplayMember = "PositionName";
            cbPositions.ValueMember = "PositionID";
            cbPositions.SelectedIndex = 0;


            // Gender
            cbGender.SelectedIndex = 0;
        }

        private void ImplementDataRowToTextBoxes()
        {
            clsEmployeeList Employee = clsEmployeeList.Find(Settings.EmployeeUpdatedRow);
            if (Employee != null)
            {
                tbFirstName.Text = Employee.FirstName;
                tbLastName.Text = Employee.LastName;
                tbEmail.Text = Employee.Email;
                tbPhone.Text = Employee.Phone;
                tbExtraNotes.Text = Employee.ExtraNotes;
                tpHireDate.Value = Employee.HireDate;
                cbGender.SelectedIndex = Employee.Gender;
                cbDepartmentID.SelectedItem = Employee.DepartmenetID + 1;
                cbPositions.SelectedItem = Employee.PoisonID + 1;
                tbLocation.Text = Employee.Location;
            }
        }

        private async void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (Settings.EmployeeUpdatedRow != -1)
            {

                if (clsEmployeeList.UpdateEmployee(Settings.EmployeeUpdatedRow, tbFirstName.Text, tbLastName.Text, int.Parse(cbGender.SelectedIndex.ToString()), tpHireDate.Value, tbExtraNotes.Text, int.Parse(cbDepartmentID.SelectedIndex.ToString()) + 1, int.Parse(cbPositions.SelectedIndex.ToString()) + 1, tbEmail.Text, tbPhone.Text, locatio.Text))
                {

                    MessageBox.Show($"Has been Updated: [{tbFirstName.Text} {tbLastName.Text}]", msgBox.Caption = $"Message From DataBase", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await Task.Run(() => clsLogs.NewActionSaved("Employee", $"Updated", DateTime.Now, frmLogin.UserNameIdFromFrmLogin));
                    clsLogs.NewActionSaved("Employee", "Update", DateTime.Now, frmLogin.UserNameIdFromFrmLogin);
                    this.Close();


                }
                else
                {
                    MessageBox.Show($"Has not been updated to DataBase: [{tbFirstName.Text} {tbLastName.Text}]", msgBox.Caption = $"Message From DataBase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

 
}
