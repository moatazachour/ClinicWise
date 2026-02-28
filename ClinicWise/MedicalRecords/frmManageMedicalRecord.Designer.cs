namespace ClinicWise.MedicalRecords
{
    partial class frmManageMedicalRecord
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
            this.btnClose = new System.Windows.Forms.Button();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mtxtFilter = new System.Windows.Forms.MaskedTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsManageAppointments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbManageMedicalRecord = new System.Windows.Forms.ComboBox();
            this.dgvManageMedicalRecords = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddMedicalRecord = new System.Windows.Forms.Button();
            this.cbVisitTypes = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cmsManageAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageMedicalRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(909, 622);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 42);
            this.btnClose.TabIndex = 49;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.Location = new System.Drawing.Point(135, 622);
            this.lblRecordCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(21, 23);
            this.lblRecordCount.TabIndex = 48;
            this.lblRecordCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 622);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 23);
            this.label2.TabIndex = 47;
            this.label2.Text = "# Records:";
            // 
            // mtxtFilter
            // 
            this.mtxtFilter.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtFilter.Location = new System.Drawing.Point(262, 221);
            this.mtxtFilter.Name = "mtxtFilter";
            this.mtxtFilter.Size = new System.Drawing.Size(345, 27);
            this.mtxtFilter.TabIndex = 46;
            this.mtxtFilter.TextChanged += new System.EventHandler(this.mtxtFilter_TextChanged);
            this.mtxtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtFilter_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::ClinicWise.Properties.Resources.medical_records_64;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1068, 107);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            // 
            // cmsManageAppointments
            // 
            this.cmsManageAppointments.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsManageAppointments.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManageAppointments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.addToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsManageAppointments.Name = "cmsManageDoctors";
            this.cmsManageAppointments.Size = new System.Drawing.Size(181, 136);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // cbManageMedicalRecord
            // 
            this.cbManageMedicalRecord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbManageMedicalRecord.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbManageMedicalRecord.FormattingEnabled = true;
            this.cbManageMedicalRecord.Items.AddRange(new object[] {
            "None",
            "Medical Record ID",
            "Appointment ID",
            "Visit Type"});
            this.cbManageMedicalRecord.Location = new System.Drawing.Point(30, 222);
            this.cbManageMedicalRecord.Margin = new System.Windows.Forms.Padding(2);
            this.cbManageMedicalRecord.Name = "cbManageMedicalRecord";
            this.cbManageMedicalRecord.Size = new System.Drawing.Size(214, 27);
            this.cbManageMedicalRecord.TabIndex = 45;
            this.cbManageMedicalRecord.SelectedIndexChanged += new System.EventHandler(this.cbManageMedicalRecord_SelectedIndexChanged);
            // 
            // dgvManageMedicalRecords
            // 
            this.dgvManageMedicalRecords.AllowUserToAddRows = false;
            this.dgvManageMedicalRecords.AllowUserToDeleteRows = false;
            this.dgvManageMedicalRecords.AllowUserToResizeRows = false;
            this.dgvManageMedicalRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvManageMedicalRecords.BackgroundColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManageMedicalRecords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvManageMedicalRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManageMedicalRecords.ContextMenuStrip = this.cmsManageAppointments;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvManageMedicalRecords.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvManageMedicalRecords.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvManageMedicalRecords.Location = new System.Drawing.Point(30, 268);
            this.dgvManageMedicalRecords.Margin = new System.Windows.Forms.Padding(2);
            this.dgvManageMedicalRecords.MultiSelect = false;
            this.dgvManageMedicalRecords.Name = "dgvManageMedicalRecords";
            this.dgvManageMedicalRecords.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManageMedicalRecords.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvManageMedicalRecords.RowHeadersWidth = 51;
            this.dgvManageMedicalRecords.RowTemplate.Height = 24;
            this.dgvManageMedicalRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManageMedicalRecords.Size = new System.Drawing.Size(1001, 338);
            this.dgvManageMedicalRecords.TabIndex = 44;
            this.dgvManageMedicalRecords.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Azure;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(316, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(443, 85);
            this.label1.TabIndex = 42;
            this.label1.Text = "Manage Medical Record";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddMedicalRecord
            // 
            this.btnAddMedicalRecord.Image = global::ClinicWise.Properties.Resources.Add_Person_40;
            this.btnAddMedicalRecord.Location = new System.Drawing.Point(960, 194);
            this.btnAddMedicalRecord.Name = "btnAddMedicalRecord";
            this.btnAddMedicalRecord.Size = new System.Drawing.Size(71, 56);
            this.btnAddMedicalRecord.TabIndex = 50;
            this.btnAddMedicalRecord.UseVisualStyleBackColor = true;
            this.btnAddMedicalRecord.Click += new System.EventHandler(this.btnAddMedicalRecord_Click);
            // 
            // cbVisitTypes
            // 
            this.cbVisitTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVisitTypes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVisitTypes.FormattingEnabled = true;
            this.cbVisitTypes.Location = new System.Drawing.Point(262, 223);
            this.cbVisitTypes.Margin = new System.Windows.Forms.Padding(2);
            this.cbVisitTypes.Name = "cbVisitTypes";
            this.cbVisitTypes.Size = new System.Drawing.Size(245, 27);
            this.cbVisitTypes.TabIndex = 51;
            this.cbVisitTypes.SelectedIndexChanged += new System.EventHandler(this.cbVisitTypes_SelectedIndexChanged);
            // 
            // frmManageMedicalRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1068, 683);
            this.Controls.Add(this.cbVisitTypes);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mtxtFilter);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbManageMedicalRecord);
            this.Controls.Add(this.dgvManageMedicalRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddMedicalRecord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageMedicalRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Medical Record";
            this.Load += new System.EventHandler(this.frmManageMedicalRecord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cmsManageAppointments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageMedicalRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mtxtFilter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsManageAppointments;
        private System.Windows.Forms.ComboBox cbManageMedicalRecord;
        private System.Windows.Forms.DataGridView dgvManageMedicalRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddMedicalRecord;
        private System.Windows.Forms.ComboBox cbVisitTypes;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}