namespace PresentationLayer_EMS
{
    partial class frmAddNewEmployee
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
            this.ctrlEmployeeDetails1 = new PresentationLayer_EMS.Employee.ctrlEmployeeDetails();
            this.SuspendLayout();
            // 
            // ctrlEmployeeDetails1
            // 
            this.ctrlEmployeeDetails1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(54)))));
            this.ctrlEmployeeDetails1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlEmployeeDetails1.Location = new System.Drawing.Point(0, 0);
            this.ctrlEmployeeDetails1.Name = "ctrlEmployeeDetails1";
            this.ctrlEmployeeDetails1.Size = new System.Drawing.Size(609, 570);
            this.ctrlEmployeeDetails1.TabIndex = 0;
            this.ctrlEmployeeDetails1.ClosedEvent += new System.EventHandler(this.ctrlEmployeeDetails1_ClosedEvent);
            // 
            // frmAddNewEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 570);
            this.Controls.Add(this.ctrlEmployeeDetails1);
            this.Name = "frmAddNewEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddNewEmployee";
            this.ResumeLayout(false);

        }

        #endregion

        private Employee.ctrlEmployeeDetails ctrlEmployeeDetails1;
    }
}