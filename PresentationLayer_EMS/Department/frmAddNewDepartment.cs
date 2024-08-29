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

namespace PresentationLayer_EMS.Department
{
    public partial class frmAddNewDepartment : Form
    {
        public frmAddNewDepartment()
        {
            InitializeComponent();
            if(Settings.DepartmentAddFalseOrUpdateTrue) tbDepartment.Text = Settings.CurrentDepartmentName;
        }

        private void btnAddNewDepartment_Click(object sender, EventArgs e)
        {

            if (Settings.DepartmentAddFalseOrUpdateTrue == true)
            {
                

                if (clsDepartment.UpdateDepartment(Settings.DepartmentCurrentRow, tbDepartment.Text))
                {
                   
                    clsLogs.NewActionSaved("Department", $"Updated Department ", DateTime.Now, frmLogin.UserNameIdFromFrmLogin);
                    this.Close();
                }
                else MessageBox.Show("ERROR");

            }
            else
            {
                if (clsDepartment.AddNewDepartment(tbDepartment.Text))
                {
                    clsLogs.NewActionSaved("Department", $"Added New Department ", DateTime.Now, frmLogin.UserNameIdFromFrmLogin);
                    this.Close();
                }
                else MessageBox.Show("ERROR");

            }
        }

        private void frmAddNewDepartment_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
