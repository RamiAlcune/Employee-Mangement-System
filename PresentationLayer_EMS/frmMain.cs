using BusinessLayer_ESM;
using BusinessLayer_ESM.Properties;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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
            ContextMenuEffects();


        }
        public void ContextMenuEffects()
        {
            MainMenu.BackColor = Color.FromArgb(45, 45, 48);
            MainMenu.ForeColor = Color.White;
            MainMenu.RenderStyle.ArrowColor = Color.White;
            MainMenu.RenderStyle.SelectionBackColor = Color.FromArgb(63, 63, 70);
            MainMenu.RenderStyle.SelectionForeColor = Color.White;
            MainMenu.RenderStyle.BorderColor = Color.FromArgb(28, 28, 28);
            MainMenu.RenderStyle.RoundedEdges = true;
        }


        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage CurrentlySelected = TabControl1.SelectedTab;
            lblTitle.Text = $"EMS~{CurrentlySelected.Text}";
            int Cases = TabControl1.SelectedIndex;
            switch ((Cases))
            {
                case 0:

                    ListAllEmployees();
                    break;
                case 1:
                    ListAllDepartments();

                    break;
                case 2:
                    //Should Add Method
                    break;

                case 3:
                    //Should Add Method
                    break;

                case 4:
                    ListAllUsers();
                    break;

                case 5:
                    ListAllLogs();
                    break;


            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListAllEmployees();
        }


        public void ListAllEmployees()
        {
            Settings.DataGridViewStyles(DGV_Main);
            BindingSource bs = new BindingSource();
            bs.DataSource = clsEmployeeList.GetEmployeeList();
            DGV_Main.DataSource = bs;
            //Employee Data List:
            DGV_Main.Columns[0].HeaderText = "ID";
            DGV_Main.Columns[0].Width = 35;
            DGV_Main.Columns[1].HeaderText = "First Name";
            DGV_Main.Columns[1].Width = 100;
            DGV_Main.Columns[2].HeaderText = "Last Name";
            DGV_Main.Columns[2].Width = 100;
            DGV_Main.Columns[3].HeaderText = "Email";
            DGV_Main.Columns[3].Width = 150;
            DGV_Main.Columns[4].HeaderText = "Phone";
            DGV_Main.Columns[4].Width = 100;
            DGV_Main.Columns[5].HeaderText = "Hire Date";
            DGV_Main.Columns[5].Width = 100;
            DGV_Main.Columns[6].HeaderText = "Department Name";
            DGV_Main.Columns[6].Width = 200;
        }
        public void ListAllDepartments()
        {
            // Departmenet Data List:
            Settings.DataGridViewStyles(DGV_Department);
            BindingSource bs = new BindingSource();
            bs.DataSource = clsDepartment.GetAllDepartments();
            DGV_Department.DataSource = bs;
            DGV_Department.Columns[0].Width = 100;
            DGV_Department.Columns[1].Width = 400;
            DGV_Department.Columns[2].Width = 200;


        }
        public void ListAllUsers()
        {
            // Users Data List
            Settings.DataGridViewStyles(DGV_Users);
            BindingSource bs = new BindingSource();
            bs.DataSource = clsUsers.GetAllUsers();
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
        public void ListAllLogs()
        {
            Settings.DataGridViewStyles(DGV_Logs);
            BindingSource bs = new BindingSource();
            bs.DataSource = clsLogs.GetAllLogs();
            DGV_Logs.DataSource = bs;
            DGV_Logs.Columns[0].HeaderText = "User Name";
            DGV_Logs.Columns[0].Width = 60;
            DGV_Logs.Columns[1].HeaderText = "Date Of Action";
            DGV_Logs.Columns[1].Width = 60;
            DGV_Logs.Columns[2].HeaderText = "Action";
            DGV_Logs.Columns[2].Width = 300;
        }

        private void PnlBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                Settings.ReleaseCapture();
                Settings.SendMessage(Handle, Settings.WM_NCLBUTTONDOWN, Settings.HTCAPTION, 0);
            }
        }



        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            (DGV_Department.DataSource as BindingSource).Filter = $"DepartmentName LIKE '%{tbDepartmentSearch.Text.ToLower()}%'";
        }

        private void tbMainSearchingByName_KeyUp(object sender, KeyEventArgs e)
        {
            (DGV_Main.DataSource as BindingSource).Filter = $"FirstName LIKE '%{tbMainSearchingByName.Text.ToLower()}%'";
        }

        private void tbSearchByRole_KeyUp(object sender, KeyEventArgs e)
        {
            (DGV_Users.DataSource as BindingSource).Filter = $"Roles LIKE '%{tbSearchByRole.Text.ToLower()}%'";
        }

        private void deleteEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)DGV_Main.CurrentRow.Cells[0].Value;
            DialogResult result = frmMsg.Show($"Are You Sure You Want To Delete User Number:[{ID}]?");
            if (result == DialogResult.Yes)
            {
                if (!clsEmployeeList.DeleteEmployee(ID)) MessageBox.Show("Error!");
                DGV_Main.DataSource = clsEmployeeList.GetEmployeeList();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
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
                if (!clsEmployeeList.DeleteEmployee(ID)) MessageBox.Show("Error!");
                DGV_Main.DataSource = clsEmployeeList.GetEmployeeList();
            }

        }

        private void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            frmAddNewEmployee frm2 = new frmAddNewEmployee();
            frm2.ShowDialog();
        }
    }
}