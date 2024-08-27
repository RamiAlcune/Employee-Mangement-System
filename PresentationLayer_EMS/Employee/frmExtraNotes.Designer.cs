namespace PresentationLayer_EMS.Employee
{
    partial class frmExtraNotes
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
            this.tbExtraNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // tbExtraNotes
            // 
            this.tbExtraNotes.Animated = true;
            this.tbExtraNotes.BorderColor = System.Drawing.Color.Transparent;
            this.tbExtraNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbExtraNotes.DefaultText = "";
            this.tbExtraNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbExtraNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbExtraNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbExtraNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbExtraNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbExtraNotes.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.tbExtraNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbExtraNotes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbExtraNotes.ForeColor = System.Drawing.Color.White;
            this.tbExtraNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbExtraNotes.Location = new System.Drawing.Point(0, 0);
            this.tbExtraNotes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbExtraNotes.Multiline = true;
            this.tbExtraNotes.Name = "tbExtraNotes";
            this.tbExtraNotes.PasswordChar = '\0';
            this.tbExtraNotes.PlaceholderText = "";
            this.tbExtraNotes.ReadOnly = true;
            this.tbExtraNotes.SelectedText = "";
            this.tbExtraNotes.Size = new System.Drawing.Size(637, 471);
            this.tbExtraNotes.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(63)))), ((int)(((byte)(60)))));
            this.btnExit.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(0, 415);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(637, 56);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "EXIT";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmExtraNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 471);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tbExtraNotes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmExtraNotes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmExtraNotes";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox tbExtraNotes;
        private Guna.UI2.WinForms.Guna2Button btnExit;
    }
}