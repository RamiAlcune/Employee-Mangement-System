﻿using BusinessLayer_ESM;
using BusinessLayer_ESM.Properties;
using Guna.UI2.WinForms;
using PresentationLayer_EMS.Department;
using PresentationLayer_EMS.Employee;
using PresentationLayer_EMS.Employee.Controls;
using PresentationLayer_EMS.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PresentationLayer_EMS
{
 
    public partial class frmMain : Form
    {
        private static DataTable _EmployeesList = clsEmployeeList.GetEmployeeList();
        public frmMain()
        {
            InitializeComponent();
            ContextMenuEffects(MainMenu);
            ContextMenuEffects(cmUsers);


        }

        public  void LoadAllTabs()
        {
            ListAllEmployees();
            ListAllDepartments();
            ListAllLogs();
            ListAllPositions();
            ListAllUsers();
            ListAllSalary();
        }
        public void ContextMenuEffects(Guna2ContextMenuStrip test)
        {
            test.BackColor = Color.FromArgb(45, 45, 48);
            test.ForeColor = Color.White;
            test.RenderStyle.ArrowColor = Color.White;
            test.RenderStyle.SelectionBackColor = Color.FromArgb(63, 63, 70);
            test.RenderStyle.SelectionForeColor = Color.White;
            test.RenderStyle.BorderColor = Color.FromArgb(28, 28, 28);
            test.RenderStyle.RoundedEdges = true;
        }


        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage CurrentlySelected = tab.SelectedTab;
            lblTitle.Text = $"EMS~{CurrentlySelected.Text}";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread th1 = new Thread(LoadAllTabs);
            th1.Start();
        }

    public  void ListAllEmployees()
        {
            if (DGV_Main.InvokeRequired)
            {
                DGV_Main.Invoke(new Action(ListAllEmployees));
                return;
            }


            Settings.DataGridViewStyles(DGV_Main);
            BindingSource bs = new BindingSource();
            bs.DataSource = clsEmployeeList.GetEmployeeList();
            if (bs.Count > 0)
            {
                DGV_Main.DataSource = bs;
                //Employee Data List:
                DGV_Main.Columns[0].HeaderText = "ID";
                DGV_Main.Columns[0].Width = 35;
                DGV_Main.Columns[1].HeaderText = "First Name";
                DGV_Main.Columns[1].Width = 60;
                DGV_Main.Columns[2].HeaderText = "Last Name";
                DGV_Main.Columns[2].Width = 60;
                DGV_Main.Columns[3].HeaderText = "Gender";
                DGV_Main.Columns[3].Width = 60;
                DGV_Main.Columns[4].HeaderText = "Phone";
                DGV_Main.Columns[4].Width = 100;
                DGV_Main.Columns[5].HeaderText = "Department Name";
                DGV_Main.Columns[5].Width = 150;
                DGV_Main.Columns[6].HeaderText = "Position Name";
                DGV_Main.Columns[6].Width = 150;
            }
            else
            {
                frmMsg.Icon = MessageDialogIcon.Warning;
                frmMsg.Caption = "Logs are Empty.";
                frmMsg.Text = "there is not any rows to show.";
            }
        }


        public void ListAllSalary()
        {
            if (DGV_Salary.InvokeRequired)
            {
                DGV_Main.Invoke(new Action(ListAllSalary));
                return;
            }


            Settings.DataGridViewStyles(DGV_Salary);
            BindingSource bs = new BindingSource();
            bs.DataSource = clsSalary.GetAllSalary();
            if (bs.Count > 0)
            {
                DGV_Salary.DataSource = bs;
                //Salary Data List:
                DGV_Salary.Columns[0].HeaderText = "EmployeeID";
                DGV_Salary.Columns[0].Width = 50;
                DGV_Salary.Columns[1].HeaderText = "First Name";
                DGV_Salary.Columns[1].Width = 100;
                DGV_Salary.Columns[2].HeaderText = "Last Name";
                DGV_Salary.Columns[2].Width = 100;
                DGV_Salary.Columns[3].HeaderText = "Amount";
                DGV_Salary.Columns[3].Width = 150;
                DGV_Salary.Columns[4].HeaderText = "Salary Date";
                DGV_Salary.Columns[4].Width = 100;
            }
            else
            {
                frmMsg.Icon = MessageDialogIcon.Warning;
                frmMsg.Caption = "Salary are Empty.";
                frmMsg.Text = "there is not any rows to show.";
            }
        }



        public void ListAllDepartments()
        {
            if (DGV_Department.InvokeRequired)
            {
                DGV_Department.Invoke(new Action(ListAllDepartments));
                return;
            }

            // Departmenet Data List:
            Settings.DataGridViewStyles(DGV_Department);
            BindingSource bs = new BindingSource();
            bs.DataSource = clsDepartment.GetAllDepartments();
            if (bs.Count > 0)
            {
                DGV_Department.DataSource = bs;
                DGV_Department.Columns[0].Width = 100;
                DGV_Department.Columns[1].Width = 400;
                DGV_Department.Columns[2].Width = 200;

            }
            else
            {
                frmMsg.Icon = MessageDialogIcon.Warning;
                frmMsg.Caption = "Logs are Empty.";
                frmMsg.Text = "there is not any rows to show.";
            }
        }
        
        public void ListAllUsers()
        {
            if (DGV_Users.InvokeRequired)
            {
                DGV_Users.Invoke(new Action(ListAllUsers));
                return;
            }

            // Users Data List
            Settings.DataGridViewStyles(DGV_Users);
            BindingSource bs = new BindingSource();
            bs.DataSource = clsUsers.GetAllUsers();
            if (bs.Count > 0)
            {
                DGV_Users.DataSource = bs;
                DGV_Users.Columns[0].HeaderText = "ID";
                DGV_Users.Columns[0].Width = 35;
                DGV_Users.Columns[1].HeaderText = "User Name";
                DGV_Users.Columns[1].Width = 100;
                DGV_Users.Columns[2].HeaderText = "Password";
                DGV_Users.Columns[2].Width = 100;
                DGV_Users.Columns[3].HeaderText = "Roles";
                DGV_Users.Columns[3].Width = 150;
            }
            else
            {
                frmMsg.Icon = MessageDialogIcon.Warning;
                frmMsg.Caption = "Logs are Empty.";
                frmMsg.Text = "there is not any rows to show.";
            }
        }
        public void ListAllLogs()
        {
            if (DGV_Logs.InvokeRequired)
            {
                DGV_Logs.Invoke(new Action(ListAllLogs));
                return;
            }
            BindingSource bs = new BindingSource();
            bs.DataSource = clsLogs.GetAllLogs();
            if (bs.Count > 0) { 
            Settings.DataGridViewStyles(DGV_Logs);
            DGV_Logs.DataSource = bs;
            DGV_Logs.Columns[0].HeaderText = "User Name";
            DGV_Logs.Columns[0].Width = 40;
            DGV_Logs.Columns[1].HeaderText = "Date Of Action";
            DGV_Logs.Columns[1].Width = 40;
            DGV_Logs.Columns[2].HeaderText = "Action";
            DGV_Logs.Columns[2].Width = 550;
        }
            else
            {
                frmMsg.Icon = MessageDialogIcon.Warning;
                frmMsg.Caption = "Logs are Empty.";
                frmMsg.Text = "there is not any rows to show.";
            }
        }

        public void ListAllPositions()
        {
            if (DGV_Positions.InvokeRequired)
            {
                DGV_Positions.Invoke(new Action(ListAllPositions));
                return;
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = clsPosition.GetAllPositions();
            if (bs.Count > 0)
            {
                Settings.DataGridViewStyles(DGV_Positions);
                DGV_Positions.DataSource = bs;
                DGV_Positions.Columns[0].HeaderText = "Position ID";
                DGV_Positions.Columns[0].Width = 100;
                DGV_Positions.Columns[1].HeaderText = "Position Name";
                DGV_Positions.Columns[1].Width = 600;

            }
        }

        private void PnlBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                Settings.ReleaseCapture();
                Settings.SendMessage(Handle, Settings.WM_NCLBUTTONDOWN, Settings.HTCAPTION, 0);
            }
        }


        private void tbLogsSearchingByUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            (DGV_Logs.DataSource as BindingSource).Filter = $"UserName LIKE '%{tbLogsSearchingByUserName.Text.ToLower()}%'";
        }

        private void tbMainSearchingByName_KeyPress(object sender, KeyPressEventArgs e)
        {
            (DGV_Main.DataSource as BindingSource).Filter = $"FirstName LIKE '%{tbMainSearchingByName.Text.ToLower()}%'";
        }

        private void tbSearchByRole_KeyPress(object sender, KeyPressEventArgs e)
        {
            (DGV_Users.DataSource as BindingSource).Filter = $"Roles LIKE '%{tbSearchByRole.Text.ToLower()}%'";
        }
        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            (DGV_Department.DataSource as BindingSource).Filter = $"DepartmentName LIKE '%{tbDepartmentSearch.Text.ToLower()}%'";
        }
        private void tbSearchPosition_KeyPress(object sender, KeyPressEventArgs e)
        {
            (DGV_Positions.DataSource as BindingSource).Filter = $"PositionName LIKE '%{tbSearchPosition.Text.ToLower()}%'";
        }


        private void deleteEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)DGV_Main.CurrentRow.Cells[0].Value;
            DialogResult result = frmMsg.Show($"Are You Sure You Want To Delete User Number:[{ID}]?");
            if (result == DialogResult.Yes)
            {
                if (!clsEmployeeList.DeleteEmployee(ID)) MessageBox.Show("Error!");
                DGV_Main.DataSource = clsEmployeeList.GetEmployeeList();
                clsLogs.NewActionSaved("Employee", $"Delete [{ID}]", DateTime.Now, frmLogin.UserNameIdFromFrmLogin);

            }

        }

        public bool PermissionsON(TabPage tab)
        {
            if (frmLogin.currentPermissions == 0) return true;
            if ((frmLogin.currentPermissions & int.Parse(tab.Tag.ToString())) != 0) return true;

            return false;
        }


        private void TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            
            if (!PermissionsON(e.TabPage))
            {
                e.Cancel = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DGV_Main.DataSource = null;
            DGV_Main.DataSource = clsEmployeeList.GetEmployeeList();
        }

        private void ssToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewEmployee frm2 = new frmAddNewEmployee();
            frm2.ShowDialog();
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            int ID = (int)DGV_Main.CurrentRow.Cells[0].Value;
            DialogResult result = frmMsg.Show($"Are You Sure You Want To Delete User Number:[{ID}]?");
            if (result == DialogResult.Yes)
            {
                if (!clsEmployeeList.DeleteEmployee(ID)) {
                    MessageBox.Show("Error!");
                    clsLogs.NewActionSaved("Employee Table", "Fail To Delete", DateTime.Now, frmLogin.UserNameIdFromFrmLogin);
                }
                else
                {
                    DGV_Main.DataSource = clsEmployeeList.GetEmployeeList();
                    clsLogs.NewActionSaved("Employee", $"Delete [{ID}]", DateTime.Now, frmLogin.UserNameIdFromFrmLogin);

                }

            }

        }

        private void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(DGV_Main.CurrentRow.Cells[0].Value.ToString());
            frmAddNewEmployee frm2 = new frmAddNewEmployee();
            frm2.ShowDialog();
            if (!frm2.Visible) ListAllEmployees();
        }

        private void btnClearAllLogs_Click(object sender, EventArgs e)
        {
            clsLogs.ClearAllLogs();
            DGV_Logs.DataSource = null;
            DGV_Logs.DataSource = clsLogs.GetAllLogs();
        }

        private void DGV_Main_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show("Clicked");
        }

        private void DGV_Main_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int ID = (int)DGV_Main.CurrentRow.Cells[0].Value;
            if (e.ColumnIndex >= 0 && e.ColumnIndex <= 1)
            {
                frmShowEmployeeCard frm2 = new frmShowEmployeeCard(ID);
                frm2.ShowDialog();

            }

        }

        private void sssToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewEmployee frm2 = new frmAddNewEmployee();
            frm2.ShowDialog();
            if (!frm2.Visible) ListAllEmployees();
        }


        private void btnAddNewPosition_Click(object sender, EventArgs e)
        {
            frmAddNewPosition frm = new frmAddNewPosition();
            frm.ShowDialog();
            if (!frm.Visible) ListAllPositions();

        }

        private void btnDeletePosition_Click(object sender, EventArgs e)
        {
            if (clsPosition.DeletePosition((int)DGV_Positions.CurrentRow.Cells[0].Value))
            {
                clsLogs.NewActionSaved("Position", $"Deleted", DateTime.Now, frmLogin.UserNameIdFromFrmLogin);
                ListAllPositions();
            }
            else MessageBox.Show("ERROR");
        }

        private void AddNewUserToolStrip_Click(object sender, EventArgs e)
        {
            frmAddNewUser frm = new frmAddNewUser();
            frm.ShowDialog();
            if(!frm.Visible) ListAllUsers();
        }

        private void DeleteUserToolStrip_Click(object sender, EventArgs e)
        {
            if (clsUsers.DeleteUser((int)DGV_Users.CurrentRow.Cells[0].Value))
            {
                clsLogs.NewActionSaved("Users", $"Deleted ", DateTime.Now, frmLogin.UserNameIdFromFrmLogin);
                ListAllUsers();
            }
            else MessageBox.Show("ERROR");
        }

        private void ChangeUserPasswordToolStrip_Click(object sender, EventArgs e)
        {
            frmUsersChangePassword frm = new frmUsersChangePassword((int)DGV_Users.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            if(!frm.Visible) ListAllUsers();
        }

        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            Settings.DepartmentAddFalseOrUpdateTrue = false;
            frmAddNewDepartment frm = new frmAddNewDepartment();
            frm.ShowDialog();
            if(!frm.Visible) ListAllDepartments();
        }

        private void btnEditEmployee_Click_1(object sender, EventArgs e)
        {
            frmAddNewEmployee frm2 = new frmAddNewEmployee();
            frm2.ShowDialog();
            if (!frm2.Visible) ListAllEmployees();
        }

        private void btnEditDepartment_Click(object sender, EventArgs e)
        {
            Settings.CurrentDepartmentName = (string)DGV_Department.CurrentRow.Cells[1].Value;
            Settings.DepartmentAddFalseOrUpdateTrue = true;
            Settings.DepartmentCurrentRow = (int)DGV_Department.CurrentRow.Cells[0].Value;
            frmAddNewDepartment frm = new frmAddNewDepartment();
            frm.ShowDialog();
            if (!frm.Visible) ListAllDepartments();
        }

        private void btnDeleteDepartment_Click(object sender, EventArgs e)
        {
            if (clsDepartment.DeleteDepartment((int)DGV_Department.CurrentRow.Cells[0].Value))
            {
                clsLogs.NewActionSaved("Department", $"Deleted ", DateTime.Now, frmLogin.UserNameIdFromFrmLogin);
                ListAllDepartments();
            }


            else MessageBox.Show("ERROR");
        }
        
    }
}