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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace PresentationLayer_EMS
{
    public partial class frmLogin : Form
    {
        public static int currentPermissions = 0;
        public frmLogin()
        {
            InitializeComponent();
        }

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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            currentPermissions = clsUsers.IsUserNameAndPasswordAreValid(tbUserName.Text, tbPassword.Text);
            if ( currentPermissions != -1)
            {
                frmMain frm1 = new frmMain();
                this.Hide();
                frm1.ShowDialog();
            }
        }
    }
}
