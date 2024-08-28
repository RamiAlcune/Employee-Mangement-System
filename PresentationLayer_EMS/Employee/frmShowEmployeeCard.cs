using BusinessLayer_ESM;
using PresentationLayer_EMS.Properties;
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
    public partial class frmShowEmployeeCard : Form
    {


        private int _ID { get; }
        public frmShowEmployeeCard(int ID)
        {
            this._ID = ID;

            InitializeComponent();
            
            ShowProfileDetails();


        }

        public void ShowProfileDetails()
        {
            DataTable dt = new DataTable();
            dt = clsEmployeeList.GetEmployeeCardByID(_ID);
            DataRow row = dt.Rows[0];

            lblFullName.Text = $"{row["FirstName"].ToString()} {row["LastName"].ToString()}";
            lblEmail.Text = row["Email"].ToString();
            lblPhone.Text = row["Phone"].ToString();
            lblLocation.Text = row["Location"].ToString();
            if ((bool)row["Gender"]) {
                pbProfileImage.Image = Resources.Female;
            }
            else
            {
                pbProfileImage.Image = Resources.Male;
            }

        }

        private void lblLocation_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void frmShowEmployeeCard_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void btnExtraNotes_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = clsEmployeeList.GetEmployeeCardByID(_ID);
            DataRow row = dt.Rows[0];
            string Notes = row["ExtraNotes"].ToString();
            frmExtraNotes frm = new frmExtraNotes(Notes);
            frm.ShowDialog();
        }

        private void frmShowEmployeeCard_Load(object sender, EventArgs e)
        {
        
        }
    }
}
