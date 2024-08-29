namespace PresentationLayer_EMS.Department
{
    partial class frmAddNewDepartment
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
            this.btnAddNewDepartment = new Guna.UI2.WinForms.Guna2Button();
            this.tbDepartment = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // btnAddNewDepartment
            // 
            this.btnAddNewDepartment.Animated = true;
            this.btnAddNewDepartment.AutoRoundedCorners = true;
            this.btnAddNewDepartment.BorderRadius = 21;
            this.btnAddNewDepartment.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewDepartment.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewDepartment.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewDepartment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewDepartment.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(170)))), ((int)(((byte)(43)))));
            this.btnAddNewDepartment.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAddNewDepartment.ForeColor = System.Drawing.Color.White;
            this.btnAddNewDepartment.Location = new System.Drawing.Point(28, 109);
            this.btnAddNewDepartment.Name = "btnAddNewDepartment";
            this.btnAddNewDepartment.Size = new System.Drawing.Size(274, 45);
            this.btnAddNewDepartment.TabIndex = 5;
            this.btnAddNewDepartment.Text = "Confirm";
            this.btnAddNewDepartment.Click += new System.EventHandler(this.btnAddNewDepartment_Click);
            // 
            // tbDepartment
            // 
            this.tbDepartment.Animated = true;
            this.tbDepartment.BorderThickness = 0;
            this.tbDepartment.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbDepartment.DefaultText = "";
            this.tbDepartment.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbDepartment.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbDepartment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbDepartment.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbDepartment.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(48)))));
            this.tbDepartment.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbDepartment.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.tbDepartment.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbDepartment.Location = new System.Drawing.Point(52, 38);
            this.tbDepartment.Name = "tbDepartment";
            this.tbDepartment.PasswordChar = '\0';
            this.tbDepartment.PlaceholderText = "Department Name";
            this.tbDepartment.SelectedText = "";
            this.tbDepartment.Size = new System.Drawing.Size(240, 36);
            this.tbDepartment.TabIndex = 3;
            // 
            // frmAddNewDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(15)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(339, 166);
            this.Controls.Add(this.btnAddNewDepartment);
            this.Controls.Add(this.tbDepartment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddNewDepartment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddNewDepartment";
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmAddNewDepartment_MouseDoubleClick);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnAddNewDepartment;
        private Guna.UI2.WinForms.Guna2TextBox tbDepartment;
    }
}