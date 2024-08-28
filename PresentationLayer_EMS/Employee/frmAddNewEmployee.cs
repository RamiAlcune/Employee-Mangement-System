using Guna.UI2.AnimatorNS;
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
    public partial class frmAddNewEmployee : Form
    {
        public int EmployeeID = -1;
        public frmAddNewEmployee()
        {
            InitializeComponent();
            ctrlEmployeeDetails1.ClosedEvent += ctrlEmployeeDetails1_ClosedEvent;
        }

        private void ctrlEmployeeDetails1_ClosedEvent(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
