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

namespace PresentationLayer_EMS.Users
{
    public partial class frmUsersChangePassword : Form
    {
        public int ID = -1;
        public frmUsersChangePassword(int ID)
        {
            this.ID = ID;
            InitializeComponent();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (tbNewPassword.Text == tbConfNewPassword.Text)
            {
                clsUsers.ChangeUserPassword(ID, tbNewPassword.Text);
                clsLogs.NewActionSaved($"Users", $"Changed Password ", DateTime.Now, frmLogin.UserNameIdFromFrmLogin);
                this.Close();
            }
            else MessageBox.Show("ERROR");
        }

        private void frmUsersChangePassword_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
