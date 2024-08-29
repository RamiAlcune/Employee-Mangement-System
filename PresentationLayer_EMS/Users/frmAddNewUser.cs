using BusinessLayer_ESM;
using BusinessLayer_ESM.Properties;
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
    public partial class frmAddNewUser : Form
    {
        public frmAddNewUser()
        {
            InitializeComponent();
            ImplementUserRoleComboBox();
        }

        public void ImplementUserRoleComboBox()
        {
            cbUserRoles.DataSource = clsUsers.GetAllUserRoles();
            cbUserRoles.DisplayMember = "Roles";
            cbUserRoles.ValueMember = "IDUserRoles";
            cbUserRoles.SelectedIndex = 0;
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            if (clsUsers.AddNewUser(tbUserName.Text, tbPassword.Text, int.Parse(cbUserRoles.SelectedValue.ToString())))
            {
                clsLogs.NewActionSaved("Users", $"Added New User ", DateTime.Now, frmLogin.UserNameIdFromFrmLogin);
                this.Close();
            }
            else MessageBox.Show("ERROR");

        }

        private void frmAddNewUser_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
