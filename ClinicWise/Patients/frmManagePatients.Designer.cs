namespace ClinicWise.Patients
{
    partial class frmManagePatients
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
            this.cbManagePatients = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvManagePatients = new System.Windows.Forms.DataGridView();
            this.cmsManagePatients = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddPatient = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mtxtFilter = new System.Windows.Forms.MaskedTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagePatients)).BeginInit();
            this.cmsManagePatients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbManagePatients
            // 
            this.cbManagePatients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbManagePatients.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbManagePatients.FormattingEnabled = true;
            this.cbManagePatients.Items.AddRange(new object[] {
            "None",
            "DoctorID",
            "Fullname",
            "Gender",
            "Phone",
            "Email",
            "Address"});
            this.cbManagePatients.Location = new System.Drawing.Point(211, 280);
            this.cbManagePatients.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbManagePatients.Name = "cbManagePatients";
            this.cbManagePatients.Size = new System.Drawing.Size(217, 31);
            this.cbManagePatients.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 27);
            this.label3.TabIndex = 21;
            this.label3.Text = "Filter By:";
            // 
            // dgvManagePatients
            // 
            this.dgvManagePatients.AllowUserToAddRows = false;
            this.dgvManagePatients.AllowUserToDeleteRows = false;
            this.dgvManagePatients.AllowUserToResizeRows = false;
            this.dgvManagePatients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvManagePatients.BackgroundColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManagePatients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvManagePatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManagePatients.ContextMenuStrip = this.cmsManagePatients;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvManagePatients.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvManagePatients.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvManagePatients.Location = new System.Drawing.Point(37, 337);
            this.dgvManagePatients.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvManagePatients.MultiSelect = false;
            this.dgvManagePatients.Name = "dgvManagePatients";
            this.dgvManagePatients.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManagePatients.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvManagePatients.RowHeadersWidth = 51;
            this.dgvManagePatients.RowTemplate.Height = 24;
            this.dgvManagePatients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManagePatients.Size = new System.Drawing.Size(1469, 410);
            this.dgvManagePatients.TabIndex = 20;
            this.dgvManagePatients.TabStop = false;
            // 
            // cmsManagePatients
            // 
            this.cmsManagePatients.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsManagePatients.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManagePatients.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsManagePatients.Name = "cmsManageDoctors";
            this.cmsManagePatients.Size = new System.Drawing.Size(250, 122);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(249, 28);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(246, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(249, 28);
            this.toolStripMenuItem1.Text = "Add New Patient";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(249, 28);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(249, 28);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Azure;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(487, 134);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(591, 98);
            this.label1.TabIndex = 18;
            this.label1.Text = "Manage Patients";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddPatient
            // 
            this.btnAddPatient.Image = global::ClinicWise.Properties.Resources.Add_Person_40;
            this.btnAddPatient.Location = new System.Drawing.Point(1411, 262);
            this.btnAddPatient.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPatient.Name = "btnAddPatient";
            this.btnAddPatient.Size = new System.Drawing.Size(95, 69);
            this.btnAddPatient.TabIndex = 27;
            this.btnAddPatient.UseVisualStyleBackColor = true;
            this.btnAddPatient.Click += new System.EventHandler(this.btnAddPatient_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1343, 766);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(163, 52);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.Location = new System.Drawing.Point(186, 766);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(25, 27);
            this.lblRecordCount.TabIndex = 25;
            this.lblRecordCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 766);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 27);
            this.label2.TabIndex = 24;
            this.label2.Text = "# Records";
            // 
            // mtxtFilter
            // 
            this.mtxtFilter.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtFilter.Location = new System.Drawing.Point(463, 280);
            this.mtxtFilter.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtFilter.Name = "mtxtFilter";
            this.mtxtFilter.Size = new System.Drawing.Size(472, 32);
            this.mtxtFilter.TabIndex = 23;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::ClinicWise.Properties.Resources.patient_care_100;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1567, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // frmManagePatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1567, 840);
            this.Controls.Add(this.cbManagePatients);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvManagePatients);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddPatient);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mtxtFilter);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManagePatients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Patients";
            this.Load += new System.EventHandler(this.frmManagePatients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagePatients)).EndInit();
            this.cmsManagePatients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbManagePatients;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvManagePatients;
        private System.Windows.Forms.ContextMenuStrip cmsManagePatients;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddPatient;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mtxtFilter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}