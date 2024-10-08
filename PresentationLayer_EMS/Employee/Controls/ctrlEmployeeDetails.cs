﻿using BusinessLayer_ESM;
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
        public event EventHandler ClosedEvent;


        public ctrlEmployeeDetails()
        {
            InitializeComponent();
            ImplementComboBox();
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
        }
        private async void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
                if (clsEmployeeList.AddNewEmployee(tbFirstName.Text, tbLastName.Text, int.Parse(cbGender.SelectedIndex.ToString()), tpHireDate.Value, tbExtraNotes.Text, int.Parse(cbDepartmentID.SelectedIndex.ToString()) + 1, int.Parse(cbPositions.SelectedIndex.ToString()) + 1, tbEmail.Text, tbPhone.Text, tbLocation.Text))
                {
                    MessageBox.Show($"Has been added to DataBase: [{tbFirstName.Text} {tbLastName.Text}]", msgBox.Caption = $"Message From DataBase", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await Task.Run(() => clsLogs.NewActionSaved("Employee", $"Added New Employee", DateTime.Now, frmLogin.UserNameIdFromFrmLogin));
                    ClosedEvent?.Invoke(this, e);
                }
                else
                {
                    MessageBox.Show($"Has not been  added to DataBase: [{tbFirstName.Text} {tbLastName.Text}]", msgBox.Caption = $"Message From DataBase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

    }
