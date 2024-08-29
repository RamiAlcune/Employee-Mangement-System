using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer_EMS
{
    public static  class Settings
    {
        public static bool DepartmentAddFalseOrUpdateTrue = false;
        public static int DepartmentCurrentRow = -1;
        public static string CurrentDepartmentName = "";
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        // Define constants for the messages
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int WM_NCRBUTTONDOWN = 0xA4; // Added for right-click
        public const int HTCAPTION = 0x2;

        public static int FullPermissions = 63;

        public static void DataGridViewStyles(DataGridView DataView)
        {
            DataView.BackgroundColor = Color.FromArgb(30, 30, 30);
            DataView.BorderStyle = BorderStyle.None;
            DataView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DataView.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            DataView.DefaultCellStyle.ForeColor = Color.White;
            DataView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(75, 75, 80);
            DataView.DefaultCellStyle.SelectionForeColor = Color.White;
            DataView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(28, 28, 28);
            DataView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataView.EnableHeadersVisualStyles = false;
            DataView.GridColor = Color.FromArgb(50, 50, 50);
            DataView.RowHeadersVisible = false;
            DataView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataView.AllowUserToAddRows = false;
            DataView.AllowUserToDeleteRows = false;
            DataView.AllowUserToResizeRows = false;
            DataView.AllowUserToResizeColumns = false;
            DataView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            DataView.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            DataView.ColumnHeadersHeight = 25;
            DataView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataView.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(185, 63, 60);

        }

        public static void SearchData(DataGridView DataGrid, string RowSearching, string Data)
        {


            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                if (row.Cells[RowSearching].Value != null && row.Cells[RowSearching].Value.ToString().ToLower().Contains(Data))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }

        }
        static string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
