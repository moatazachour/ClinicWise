namespace ClinicWise.Patients
{
    partial class frmPatientPicker
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAddPatient = new System.Windows.Forms.Button();
            this.mtxtFilter = new System.Windows.Forms.MaskedTextBox();
            this.cbManagePatients = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvManagePatients = new System.Windows.Forms.DataGridView();
            this.cmsManageDoctors = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pickPatientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagePatients)).BeginInit();
            this.cmsManageDoctors.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddPatient
            // 
            this.btnAddPatient.Image = global::ClinicWise.Properties.Resources.Add_Person_40;
            this.btnAddPatient.Location = new System.Drawing.Point(1065, 125);
            this.btnAddPatient.Name = "btnAddPatient";
            this.btnAddPatient.Size = new System.Drawing.Size(59, 48);
            this.btnAddPatient.TabIndex = 38;
            this.btnAddPatient.UseVisualStyleBackColor = true;
            this.btnAddPatient.Click += new System.EventHandler(this.btnAddPatient_Click);
            // 
            // mtxtFilter
            // 
            this.mtxtFilter.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtFilter.Location = new System.Drawing.Point(310, 133);
            this.mtxtFilter.Name = "mtxtFilter";
            this.mtxtFilter.Size = new System.Drawing.Size(355, 27);
            this.mtxtFilter.TabIndex = 37;
            this.mtxtFilter.TextChanged += new System.EventHandler(this.mtxtFilter_TextChanged);
            // 
            // cbManagePatients
            // 
            this.cbManagePatients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbManagePatients.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbManagePatients.FormattingEnabled = true;
            this.cbManagePatients.Items.AddRange(new object[] {
            "None",
            "PatientID",
            "Fullname",
            "Gender",
            "Phone",
            "Email",
            "Address"});
            this.cbManagePatients.Location = new System.Drawing.Point(130, 134);
            this.cbManagePatients.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbManagePatients.Name = "cbManagePatients";
            this.cbManagePatients.Size = new System.Drawing.Size(164, 27);
            this.cbManagePatients.TabIndex = 36;
            this.cbManagePatients.SelectedIndexChanged += new System.EventHandler(this.frmPatientPicker_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 23);
            this.label3.TabIndex = 35;
            this.label3.Text = "Filter By:";
            // 
            // dgvManagePatients
            // 
            this.dgvManagePatients.AllowUserToAddRows = false;
            this.dgvManagePatients.AllowUserToDeleteRows = false;
            this.dgvManagePatients.AllowUserToResizeRows = false;
            this.dgvManagePatients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvManagePatients.BackgroundColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManagePatients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvManagePatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManagePatients.ContextMenuStrip = this.cmsManageDoctors;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvManagePatients.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvManagePatients.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvManagePatients.Location = new System.Drawing.Point(15, 180);
            this.dgvManagePatients.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvManagePatients.MultiSelect = false;
            this.dgvManagePatients.Name = "dgvManagePatients";
            this.dgvManagePatients.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManagePatients.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvManagePatients.RowHeadersWidth = 51;
            this.dgvManagePatients.RowTemplate.Height = 24;
            this.dgvManagePatients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManagePatients.Size = new System.Drawing.Size(1109, 338);
            this.dgvManagePatients.TabIndex = 34;
            this.dgvManagePatients.TabStop = false;
            this.dgvManagePatients.DoubleClick += new System.EventHandler(this.dgvManagePatients_DoubleClick);
            // 
            // cmsManageDoctors
            // 
            this.cmsManageDoctors.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsManageDoctors.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManageDoctors.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.pickPatientToolStripMenuItem});
            this.cmsManageDoctors.Name = "cmsManageDoctors";
            this.cmsManageDoctors.Size = new System.Drawing.Size(179, 62);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // pickPatientToolStripMenuItem
            // 
            this.pickPatientToolStripMenuItem.Name = "pickPatientToolStripMenuItem";
            this.pickPatientToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.pickPatientToolStripMenuItem.Text = "Pick Patient";
            this.pickPatientToolStripMenuItem.Click += new System.EventHandler(this.pickPatientToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Azure;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(382, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(443, 80);
            this.label1.TabIndex = 33;
            this.label1.Text = "Choose Patient";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(997, 537);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(127, 39);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmPatientPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1147, 588);
            this.Controls.Add(this.btnAddPatient);
            this.Controls.Add(this.mtxtFilter);
            this.Controls.Add(this.cbManagePatients);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvManagePatients);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmPatientPicker";
            this.Text = "Choose Patient";
            this.Load += new System.EventHandler(this.frmPatientPicker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagePatients)).EndInit();
            this.cmsManageDoctors.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddPatient;
        private System.Windows.Forms.MaskedTextBox mtxtFilter;
        private System.Windows.Forms.ComboBox cbManagePatients;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvManagePatients;
        private System.Windows.Forms.ContextMenuStrip cmsManageDoctors;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem pickPatientToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
    }
}