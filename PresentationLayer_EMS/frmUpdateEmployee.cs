using PresentationLayer_EMS.Employee;
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
    public partial class frmUpdateEmployee : Form
    {
        public event Action RefreshTable;
        public static int EmployeeID = -1;
        public frmUpdateEmployee(int ID)
        {
            InitializeComponent();
            EmployeeID = ID;
            ctrlEmployeeUpdate2.BooleanCheck += ctrlEmployeeUpdate2_BooleanCheck;


        }

        private void ctrlEmployeeUpdate2_BooleanCheck(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void frmUpdateEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            RefreshTable?.Invoke();
        }
    }
}
