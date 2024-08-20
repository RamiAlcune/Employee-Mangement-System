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
    }
}
