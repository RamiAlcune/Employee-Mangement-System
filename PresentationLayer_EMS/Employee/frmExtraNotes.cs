using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer_EMS.Employee
{
    public partial class frmExtraNotes : Form
    {
        public frmExtraNotes(string ExtraNotes)
        {
            
            InitializeComponent();
            tbExtraNotes.Text = ExtraNotes;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
