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
using System.Windows.Forms;

namespace PresentationLayer_EMS
{

    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();

        }


        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage CurrentlySelected = TabControl.SelectedTab;
            lblTitle.Text = $"EMS~{CurrentlySelected.Text}" ;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridViewConfigEmployeeList();
        }


        public void DataGridViewConfigEmployeeList()
        {
            Settings.DataGridViewStyles(DGV_Main);
            //Employee Data List:
            DGV_Main.Columns.Add("id", "ID");
            DGV_Main.Columns.Add("FirstName", "First Name");
            DGV_Main.Columns.Add("LastName", "Last Name");
            DGV_Main.Columns.Add("Email", "Email");
            DGV_Main.Columns.Add("Phone", "Phone");
            DGV_Main.Columns.Add("HireDate", "Hire Date");
            DGV_Main.Columns.Add("DepartmentName", "Department Name");
            DGV_Main.Columns["ID"].Width = 30;
            DGV_Main.Columns["FirstName"].Width = 150;
            DGV_Main.Columns["LastName"].Width = 150;
            DGV_Main.Columns["Email"].Width = 200;
            DGV_Main.Columns["Phone"].Width = 120;
            DGV_Main.Columns["HireDate"].Width = 150;
            DGV_Main.Columns["DepartmentName"].Width = 150;
            DGV_Main.Rows.Add(1, "John", "Doe", "john.doe@example.com", "123-456-7890", "01/01/2020", "Engineering");
            DGV_Main.Rows.Add(2, "Jane", "Smith", "jane.smith@example.com", "123-456-7891", "02/01/2020", "Marketing");
            DGV_Main.Rows.Add(3, "John", "Doe", "john.doe@example.com", "123-456-7890", "01/01/2020", "Engineering");
            DGV_Main.Rows.Add(4, "Jane", "Smith", "jane.smith@example.com", "123-456-7891", "02/01/2020", "Marketing");
            DGV_Main.Rows.Add(5, "John", "Doe", "john.doe@example.com", "123-456-7890", "01/01/2020", "Engineering");
            DGV_Main.Rows.Add(6, "Jane", "Smith", "jane.smith@example.com", "123-456-7891", "02/01/2020", "Marketing");

            // Departmenet Data List:
            Settings.DataGridViewStyles(DGV_Department);
            DGV_Department.Columns.Add("id", "ID");
            DGV_Department.Columns.Add("DepartmentName", "Department Name");
            DGV_Department.Columns["ID"].Width = 30;
            DGV_Department.Columns["DepartmentName"].Width = 500;
            DGV_Department.Rows.Add(5, "Super Admin");
            DGV_Department.Rows.Add(6, "Super Admin");
            DGV_Department.Rows.Add(7, "Super Leader");
            DGV_Department.Rows.Add(8, "Super Owner");

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
    }
}
