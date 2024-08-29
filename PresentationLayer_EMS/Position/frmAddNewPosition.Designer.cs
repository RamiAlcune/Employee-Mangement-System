namespace PresentationLayer_EMS
{
    partial class frmAddNewPosition
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
            this.tb = new System.Windows.Forms.Label();
            this.tbPositionName = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAddNewPosition = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // tb
            // 
            this.tb.AutoSize = true;
            this.tb.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb.ForeColor = System.Drawing.Color.White;
            this.tb.Location = new System.Drawing.Point(3, 0);
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(99, 16);
            this.tb.TabIndex = 8;
            this.tb.Text = "Position Name";
            // 
            // tbPositionName
            // 
            this.tbPositionName.Animated = true;
            this.tbPositionName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPositionName.DefaultText = "";
            this.tbPositionName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbPositionName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbPositionName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPositionName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPositionName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.tbPositionName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPositionName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPositionName.ForeColor = System.Drawing.Color.White;
            this.tbPositionName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPositionName.Location = new System.Drawing.Point(3, 19);
            this.tbPositionName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPositionName.Name = "tbPositionName";
            this.tbPositionName.PasswordChar = '\0';
            this.tbPositionName.PlaceholderText = "";
            this.tbPositionName.SelectedText = "";
            this.tbPositionName.Size = new System.Drawing.Size(301, 49);
            this.tbPositionName.TabIndex = 7;
            // 
            // btnAddNewPosition
            // 
            this.btnAddNewPosition.Animated = true;
            this.btnAddNewPosition.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewPosition.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewPosition.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewPosition.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewPosition.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(170)))), ((int)(((byte)(43)))));
            this.btnAddNewPosition.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddNewPosition.ForeColor = System.Drawing.Color.White;
            this.btnAddNewPosition.Location = new System.Drawing.Point(-16, 117);
            this.btnAddNewPosition.Name = "btnAddNewPosition";
            this.btnAddNewPosition.Size = new System.Drawing.Size(337, 105);
            this.btnAddNewPosition.TabIndex = 14;
            this.btnAddNewPosition.Text = "Add New Position";
            this.btnAddNewPosition.Click += new System.EventHandler(this.btnAddNewPosition_Click);
            // 
            // frmAddNewPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(309, 224);
            this.Controls.Add(this.btnAddNewPosition);
            this.Controls.Add(this.tb);
            this.Controls.Add(this.tbPositionName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddNewPosition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddNewPosition";
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmAddNewPosition_MouseDoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tb;
        private Guna.UI2.WinForms.Guna2TextBox tbPositionName;
        private Guna.UI2.WinForms.Guna2Button btnAddNewPosition;
    }
}