namespace ClinicWise.Appointments
{
    partial class frmManageAppointments
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbManageAppointments = new System.Windows.Forms.ComboBox();
            this.dgvManageAppointments = new System.Windows.Forms.DataGridView();
            this.cmsManageUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbAppointmentStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mtxtFilter = new System.Windows.Forms.MaskedTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbDoctors = new System.Windows.Forms.ComboBox();
            this.cbPatients = new System.Windows.Forms.ComboBox();
            this.cbDate = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageAppointments)).BeginInit();
            this.cmsManageUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbManageAppointments
            // 
            this.cbManageAppointments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbManageAppointments.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbManageAppointments.FormattingEnabled = true;
            this.cbManageAppointments.Items.AddRange(new object[] {
            "None",
            "Appointment ID",
            "Doctor",
            "Patient",
            "Status",
            "Dates"});
            this.cbManageAppointments.Location = new System.Drawing.Point(31, 271);
            this.cbManageAppointments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbManageAppointments.Name = "cbManageAppointments";
            this.cbManageAppointments.Size = new System.Drawing.Size(254, 31);
            this.cbManageAppointments.TabIndex = 32;
            this.cbManageAppointments.SelectedIndexChanged += new System.EventHandler(this.cbManageAppointments_SelectedIndexChanged);
            // 
            // dgvManageAppointments
            // 
            this.dgvManageAppointments.AllowUserToAddRows = false;
            this.dgvManageAppointments.AllowUserToDeleteRows = false;
            this.dgvManageAppointments.AllowUserToResizeRows = false;
            this.dgvManageAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvManageAppointments.BackgroundColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManageAppointments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvManageAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManageAppointments.ContextMenuStrip = this.cmsManageUsers;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvManageAppointments.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvManageAppointments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvManageAppointments.Location = new System.Drawing.Point(31, 316);
            this.dgvManageAppointments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvManageAppointments.MultiSelect = false;
            this.dgvManageAppointments.Name = "dgvManageAppointments";
            this.dgvManageAppointments.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManageAppointments.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvManageAppointments.RowHeadersWidth = 51;
            this.dgvManageAppointments.RowTemplate.Height = 24;
            this.dgvManageAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManageAppointments.Size = new System.Drawing.Size(1759, 416);
            this.dgvManageAppointments.TabIndex = 31;
            this.dgvManageAppointments.TabStop = false;
            // 
            // cmsManageUsers
            // 
            this.cmsManageUsers.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsManageUsers.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManageUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsManageUsers.Name = "cmsManageDoctors";
            this.cmsManageUsers.Size = new System.Drawing.Size(205, 94);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(204, 28);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(201, 6);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(204, 28);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(204, 28);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // cbAppointmentStatus
            // 
            this.cbAppointmentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAppointmentStatus.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAppointmentStatus.FormattingEnabled = true;
            this.cbAppointmentStatus.Items.AddRange(new object[] {
            "Pending",
            "Confirmed",
            "Completed",
            "Cancelled",
            "Rescheduled",
            "NoShow"});
            this.cbAppointmentStatus.Location = new System.Drawing.Point(305, 272);
            this.cbAppointmentStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbAppointmentStatus.Name = "cbAppointmentStatus";
            this.cbAppointmentStatus.Size = new System.Drawing.Size(290, 31);
            this.cbAppointmentStatus.TabIndex = 38;
            this.cbAppointmentStatus.SelectedIndexChanged += new System.EventHandler(this.cbAppointmentStatus_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Azure;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(630, 133);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(591, 98);
            this.label1.TabIndex = 29;
            this.label1.Text = "Manage Appointments";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Image = global::ClinicWise.Properties.Resources.Add_Person_40;
            this.btnAddUser.Location = new System.Drawing.Point(1285, 233);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(95, 69);
            this.btnAddUser.TabIndex = 37;
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1627, 749);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(163, 52);
            this.btnClose.TabIndex = 36;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.Location = new System.Drawing.Point(173, 750);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(25, 27);
            this.lblRecordCount.TabIndex = 35;
            this.lblRecordCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 750);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 27);
            this.label2.TabIndex = 34;
            this.label2.Text = "# Records:";
            // 
            // mtxtFilter
            // 
            this.mtxtFilter.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtFilter.Location = new System.Drawing.Point(305, 270);
            this.mtxtFilter.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtFilter.Name = "mtxtFilter";
            this.mtxtFilter.Size = new System.Drawing.Size(472, 32);
            this.mtxtFilter.TabIndex = 33;
            this.mtxtFilter.TextChanged += new System.EventHandler(this.mtxtFilter_TextChanged);
            this.mtxtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtFilter_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::ClinicWise.Properties.Resources.appointments_64;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1815, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // cbDoctors
            // 
            this.cbDoctors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDoctors.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDoctors.FormattingEnabled = true;
            this.cbDoctors.Location = new System.Drawing.Point(305, 270);
            this.cbDoctors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDoctors.Name = "cbDoctors";
            this.cbDoctors.Size = new System.Drawing.Size(417, 31);
            this.cbDoctors.TabIndex = 39;
            this.cbDoctors.SelectedIndexChanged += new System.EventHandler(this.cbDoctors_SelectedIndexChanged);
            // 
            // cbPatients
            // 
            this.cbPatients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPatients.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPatients.FormattingEnabled = true;
            this.cbPatients.Location = new System.Drawing.Point(305, 270);
            this.cbPatients.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbPatients.Name = "cbPatients";
            this.cbPatients.Size = new System.Drawing.Size(290, 31);
            this.cbPatients.TabIndex = 40;
            this.cbPatients.SelectedIndexChanged += new System.EventHandler(this.cbPatients_SelectedIndexChanged);
            // 
            // cbDate
            // 
            this.cbDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDate.FormattingEnabled = true;
            this.cbDate.Items.AddRange(new object[] {
            "Today",
            "Tomorrow",
            "This Week",
            "Next Week",
            "This Month",
            "Next Month"});
            this.cbDate.Location = new System.Drawing.Point(305, 271);
            this.cbDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDate.Name = "cbDate";
            this.cbDate.Size = new System.Drawing.Size(334, 31);
            this.cbDate.TabIndex = 41;
            this.cbDate.SelectedIndexChanged += new System.EventHandler(this.cbDate_SelectedIndexChanged);
            // 
            // frmManageAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1815, 814);
            this.Controls.Add(this.cbDate);
            this.Controls.Add(this.cbPatients);
            this.Controls.Add(this.cbDoctors);
            this.Controls.Add(this.cbManageAppointments);
            this.Controls.Add(this.dgvManageAppointments);
            this.Controls.Add(this.cbAppointmentStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mtxtFilter);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmManageAppointments";
            this.Load += new System.EventHandler(this.frmManageAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageAppointments)).EndInit();
            this.cmsManageUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbManageAppointments;
        private System.Windows.Forms.DataGridView dgvManageAppointments;
        private System.Windows.Forms.ContextMenuStrip cmsManageUsers;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbAppointmentStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mtxtFilter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbDoctors;
        private System.Windows.Forms.ComboBox cbPatients;
        private System.Windows.Forms.ComboBox cbDate;
    }
}