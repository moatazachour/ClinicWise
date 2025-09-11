namespace ClinicWise
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.doctorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doctorsToolStripMenuItem,
            this.patientsToolStripMenuItem,
            this.appointmentsToolStripMenuItem,
            this.paymentsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.accountSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(431, 778);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "msMain";
            // 
            // doctorsToolStripMenuItem
            // 
            this.doctorsToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doctorsToolStripMenuItem.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.doctorsToolStripMenuItem.Image = global::ClinicWise.Properties.Resources.doctor_96;
            this.doctorsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.doctorsToolStripMenuItem.Name = "doctorsToolStripMenuItem";
            this.doctorsToolStripMenuItem.Size = new System.Drawing.Size(418, 100);
            this.doctorsToolStripMenuItem.Text = "Doctors";
            this.doctorsToolStripMenuItem.Click += new System.EventHandler(this.doctorsToolStripMenuItem_Click);
            // 
            // patientsToolStripMenuItem
            // 
            this.patientsToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientsToolStripMenuItem.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.patientsToolStripMenuItem.Image = global::ClinicWise.Properties.Resources.patient_care_100;
            this.patientsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.patientsToolStripMenuItem.Name = "patientsToolStripMenuItem";
            this.patientsToolStripMenuItem.Size = new System.Drawing.Size(418, 104);
            this.patientsToolStripMenuItem.Text = "Patients";
            this.patientsToolStripMenuItem.Click += new System.EventHandler(this.patientsToolStripMenuItem_Click);
            // 
            // appointmentsToolStripMenuItem
            // 
            this.appointmentsToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentsToolStripMenuItem.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.appointmentsToolStripMenuItem.Image = global::ClinicWise.Properties.Resources.appointments_64;
            this.appointmentsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.appointmentsToolStripMenuItem.Name = "appointmentsToolStripMenuItem";
            this.appointmentsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.appointmentsToolStripMenuItem.Size = new System.Drawing.Size(418, 98);
            this.appointmentsToolStripMenuItem.Text = "   Appointments";
            // 
            // paymentsToolStripMenuItem
            // 
            this.paymentsToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentsToolStripMenuItem.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.paymentsToolStripMenuItem.Image = global::ClinicWise.Properties.Resources.medical_records_64;
            this.paymentsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.paymentsToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.paymentsToolStripMenuItem.Name = "paymentsToolStripMenuItem";
            this.paymentsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 15, 4, 15);
            this.paymentsToolStripMenuItem.Size = new System.Drawing.Size(418, 98);
            this.paymentsToolStripMenuItem.Text = "Medical Records";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.toolStripMenuItem2.Image = global::ClinicWise.Properties.Resources.payment_method_67;
            this.toolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem2.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Padding = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.toolStripMenuItem2.Size = new System.Drawing.Size(418, 101);
            this.toolStripMenuItem2.Text = "   Payments";
            // 
            // accountSettingsToolStripMenuItem
            // 
            this.accountSettingsToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountSettingsToolStripMenuItem.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.accountSettingsToolStripMenuItem.Image = global::ClinicWise.Properties.Resources.account_settings_64;
            this.accountSettingsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.accountSettingsToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.accountSettingsToolStripMenuItem.Name = "accountSettingsToolStripMenuItem";
            this.accountSettingsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 15, 4, 15);
            this.accountSettingsToolStripMenuItem.Size = new System.Drawing.Size(418, 98);
            this.accountSettingsToolStripMenuItem.Text = "   Account Settings";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::ClinicWise.Properties.Resources.background;
            this.pictureBox1.Location = new System.Drawing.Point(431, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1477, 778);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1908, 778);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem doctorsToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem patientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appointmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}