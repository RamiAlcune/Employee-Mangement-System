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

namespace PresentationLayer_EMS
{
    public partial class frmAddNewPosition : Form
    {
        public frmAddNewPosition()
        {
            InitializeComponent();
        }

        private void btnAddNewPosition_Click(object sender, EventArgs e)
        {
            if (clsPosition.AddNewPosition(tbPositionName.Text)) {
                clsLogs.NewActionSaved("Employee", "Position Added ", DateTime.Now, frmLogin.UserNameIdFromFrmLogin);
                this.Close();
            } 
            else MessageBox.Show("ERROR Not added");
        }

        private void frmAddNewPosition_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
