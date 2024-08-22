using BusinessLayer_ESM;
using BusinessLayer_ESM.Properties;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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

            switch (int.Parse(CurrentlySelected.Tag.ToString()))
            {
                case 1:
                    ListAllEmployees();
                    break;
                case 2:
                    ListAllDepartments();
                    break;
                case 4:
                    //Should Add Method
                    break;

                case 8:
                    //Should Add Method
                    break;

                case 16:
                    ListAllUsers();
                    break;

                case 32:
                    //Should Add Method
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
            DGV_Main.DataSource = clsEmployeeList.GetEmployeeList();
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
            DGV_Department.Columns.Add("id", "ID");
            DGV_Department.Columns.Add("DepartmentName", "Department Name");
            DGV_Department.Columns["ID"].Width = 30;
            DGV_Department.Columns["DepartmentName"].Width = 500;
            DGV_Department.Rows.Add(5, "Manage Employees");
            DGV_Department.Rows.Add(6, "Junior Developer");
            DGV_Department.Rows.Add(7, "Senior Developer");
            DGV_Department.Rows.Add(8, "Intership Developer");
        }
        public void ListAllUsers()
        {
            // Users Data List
            Settings.DataGridViewStyles(DGV_Users);
            DGV_Users.DataSource = clsUsers.GetAllUsers();
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
            Settings.SearchData(DGV_Department, "DepartmentName", tbSearch.Text.ToLower());
        }

        private void tbMainSearchingByName_KeyUp(object sender, KeyEventArgs e)
        {
            Settings.SearchData(DGV_Main, "FirstName", tbMainSearchingByName.Text.ToLower());
        }

        private void tbSearchByRole_KeyUp(object sender, KeyEventArgs e)
        {
            Settings.SearchData(DGV_Users, "Roles", tbSearchByRole.Text.ToLower());
        }

        private void deleteEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)DGV_Main.CurrentRow.Cells[0].Value;
            DialogResult result = frmMsg.Show($"Are You Sure You Want To Delete User");
            if (result == DialogResult.Yes)
            {
                if (!clsEmployeeList.DeleteEmployee(ID)) MessageBox.Show("Error!");
                clsEmployeeList.GetEmployeeList();
            }

        }

        private int ReturnINT(object tag) { return int.Parse(tag.ToString()); }
        public bool PermissionsON(object Tag)
        {
            int Permissions = 0;
            if ((Settings.FullPermissions & Permissions) == 0) return true;
            if ((Permissions & ReturnINT(Tag)) == 1) return true;
            return false;

        }
    }
}