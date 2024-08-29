using BusinessLayer_ESM.Properties;
using Microsoft.Win32;
using PresentationLayer_EMS.Properties;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace PresentationLayer_EMS
{
    public partial class frmLogin : Form
    {
        string PathWR = @"HKEY_LOCAL_MACHINE\SOFTWARE\EsmRememberedUsers";

        public static int currentPermissions = -1;
        public frmLogin()
        {
            InitializeComponent();
            tbPassword.PasswordChar = '*';
            string UserName = Registry.GetValue(PathWR,"UserName", null) as string;
            string Password = Registry.GetValue(PathWR, "Password", null) as string;
            if(UserName != null &&  Password != null)
            {
                tbUserName.Text = UserName;
                tbPassword.Text = Password;
            }

        }


        public static int UserNameIdFromFrmLogin = -1;
        private void PnlLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                {
                    Settings.ReleaseCapture();
                    Settings.SendMessage(Handle, Settings.WM_NCLBUTTONDOWN, Settings.HTCAPTION, 0);
                }
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            

            if (cbRememberMe.Checked)
            {
                Registry.SetValue(PathWR, "UserName", tbUserName.Text, RegistryValueKind.String);
                Registry.SetValue(PathWR, "Password", tbPassword.Text, RegistryValueKind.String);
            }



            AnimationEffect.Start();
            AnimationEffect.Visible = true;

            int LoginAsynchonous = await Task.Run(() => currentPermissions = clsUsers.IsUserNameAndPasswordAreValid(tbUserName.Text, tbPassword.Text));
            btnLogin.Enabled = false;
            currentPermissions = clsUsers.IsUserNameAndPasswordAreValid(tbUserName.Text, tbPassword.Text);
            UserNameIdFromFrmLogin = clsUsers.GetUserNameIdFromUserName(tbUserName.Text);


            if ( currentPermissions != -1)
            {

                frmMain frm1 = new frmMain();
                this.Hide();
                frm1.FormClosed += (s, args) => this.Show();
                tbUserName.Text = "";
                tbPassword.Text = "";
                frm1.ShowDialog();

            }
            
            AnimationEffect.Stop();
            AnimationEffect.Visible = false;
            btnLogin.Enabled = true;
        }

        private void BtnHide_Click(object sender, EventArgs e)
        {
            if (tbPassword.PasswordChar == '*')
            {
                BtnHide.Image = Resources.eye;
                tbPassword.PasswordChar = '\0';
            }
            else
            {
                BtnHide.Image = Resources.hide;
                tbPassword.PasswordChar = '*';
            }

            tbPassword.Refresh();
        }
    }
}
