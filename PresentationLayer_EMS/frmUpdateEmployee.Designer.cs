namespace PresentationLayer_EMS
{
    partial class frmUpdateEmployee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlEmployeeUpdate2 = new PresentationLayer_EMS.Employee.Controls.ctrlEmployeeUpdate();
            this.SuspendLayout();
            // 
            // ctrlEmployeeUpdate2
            // 
            this.ctrlEmployeeUpdate2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(54)))));
            this.ctrlEmployeeUpdate2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlEmployeeUpdate2.Location = new System.Drawing.Point(0, 0);
            this.ctrlEmployeeUpdate2.Name = "ctrlEmployeeUpdate2";
            this.ctrlEmployeeUpdate2.Size = new System.Drawing.Size(597, 625);
            this.ctrlEmployeeUpdate2.TabIndex = 0;
            this.ctrlEmployeeUpdate2.BooleanCheck += new System.EventHandler(this.ctrlEmployeeUpdate2_BooleanCheck);
            // 
            // frmUpdateEmployee
            // 
            this.ClientSize = new System.Drawing.Size(597, 625);
            this.Controls.Add(this.ctrlEmployeeUpdate2);
            this.Name = "frmUpdateEmployee";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUpdateEmployee_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private Employee.Controls.ctrlEmployeeUpdate ctrlEmployeeUpdate1;
        private Employee.Controls.ctrlEmployeeUpdate ctrlEmployeeUpdate2;
    }
}