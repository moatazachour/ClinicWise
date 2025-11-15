namespace ClinicWise.Doctors
{
    partial class frmDoctorPicker
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
            this.cbDoctorSpecialization = new System.Windows.Forms.ComboBox();
            this.btnAddDoctor = new System.Windows.Forms.Button();
            this.mtxtFilter = new System.Windows.Forms.MaskedTextBox();
            this.cbManageDoctors = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvManageDoctors = new System.Windows.Forms.DataGridView();
            this.cmsManageDoctors = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pickDoctorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageDoctors)).BeginInit();
            this.cmsManageDoctors.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(922, 658);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(163, 52);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbDoctorSpecialization
            // 
            this.cbDoctorSpecialization.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDoctorSpecialization.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDoctorSpecialization.FormattingEnabled = true;
            this.cbDoctorSpecialization.Location = new System.Drawing.Point(419, 166);
            this.cbDoctorSpecialization.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDoctorSpecialization.Name = "cbDoctorSpecialization";
            this.cbDoctorSpecialization.Size = new System.Drawing.Size(359, 31);
            this.cbDoctorSpecialization.TabIndex = 31;
            this.cbDoctorSpecialization.SelectedIndexChanged += new System.EventHandler(this.cbDoctorSpecialization_SelectedIndexChanged);
            // 
            // btnAddDoctor
            // 
            this.btnAddDoctor.Image = global::ClinicWise.Properties.Resources.Add_Person_40;
            this.btnAddDoctor.Location = new System.Drawing.Point(990, 131);
            this.btnAddDoctor.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddDoctor.Name = "btnAddDoctor";
            this.btnAddDoctor.Size = new System.Drawing.Size(95, 69);
            this.btnAddDoctor.TabIndex = 30;
            this.btnAddDoctor.UseVisualStyleBackColor = true;
            this.btnAddDoctor.Click += new System.EventHandler(this.btnAddDoctor_Click);
            // 
            // mtxtFilter
            // 
            this.mtxtFilter.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtFilter.Location = new System.Drawing.Point(419, 164);
            this.mtxtFilter.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtFilter.Name = "mtxtFilter";
            this.mtxtFilter.Size = new System.Drawing.Size(472, 32);
            this.mtxtFilter.TabIndex = 29;
            this.mtxtFilter.TextChanged += new System.EventHandler(this.mtxtFilter_TextChanged);
            // 
            // cbManageDoctors
            // 
            this.cbManageDoctors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbManageDoctors.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbManageDoctors.FormattingEnabled = true;
            this.cbManageDoctors.Items.AddRange(new object[] {
            "None",
            "DoctorID",
            "Fullname",
            "Gender",
            "Phone",
            "Email",
            "Specialization",
            "Address"});
            this.cbManageDoctors.Location = new System.Drawing.Point(179, 165);
            this.cbManageDoctors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbManageDoctors.Name = "cbManageDoctors";
            this.cbManageDoctors.Size = new System.Drawing.Size(217, 31);
            this.cbManageDoctors.TabIndex = 28;
            this.cbManageDoctors.SelectedIndexChanged += new System.EventHandler(this.cbManageDoctors_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 27);
            this.label3.TabIndex = 27;
            this.label3.Text = "Filter By:";
            // 
            // dgvManageDoctors
            // 
            this.dgvManageDoctors.AllowUserToAddRows = false;
            this.dgvManageDoctors.AllowUserToDeleteRows = false;
            this.dgvManageDoctors.AllowUserToResizeRows = false;
            this.dgvManageDoctors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvManageDoctors.BackgroundColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManageDoctors.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvManageDoctors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManageDoctors.ContextMenuStrip = this.cmsManageDoctors;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvManageDoctors.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvManageDoctors.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvManageDoctors.Location = new System.Drawing.Point(25, 222);
            this.dgvManageDoctors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvManageDoctors.MultiSelect = false;
            this.dgvManageDoctors.Name = "dgvManageDoctors";
            this.dgvManageDoctors.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManageDoctors.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvManageDoctors.RowHeadersWidth = 51;
            this.dgvManageDoctors.RowTemplate.Height = 24;
            this.dgvManageDoctors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManageDoctors.Size = new System.Drawing.Size(1060, 416);
            this.dgvManageDoctors.TabIndex = 26;
            this.dgvManageDoctors.TabStop = false;
            this.dgvManageDoctors.DoubleClick += new System.EventHandler(this.dgvManageDoctors_DoubleClick);
            // 
            // cmsManageDoctors
            // 
            this.cmsManageDoctors.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsManageDoctors.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManageDoctors.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.pickDoctorToolStripMenuItem});
            this.cmsManageDoctors.Name = "cmsManageDoctors";
            this.cmsManageDoctors.Size = new System.Drawing.Size(205, 66);
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
            // pickDoctorToolStripMenuItem
            // 
            this.pickDoctorToolStripMenuItem.Name = "pickDoctorToolStripMenuItem";
            this.pickDoctorToolStripMenuItem.Size = new System.Drawing.Size(204, 28);
            this.pickDoctorToolStripMenuItem.Text = "Pick Doctor";
            this.pickDoctorToolStripMenuItem.Click += new System.EventHandler(this.pickDoctorToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Azure;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(267, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(591, 98);
            this.label1.TabIndex = 25;
            this.label1.Text = "Choose Doctor";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmDoctorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1115, 722);
            this.Controls.Add(this.cbDoctorSpecialization);
            this.Controls.Add(this.btnAddDoctor);
            this.Controls.Add(this.mtxtFilter);
            this.Controls.Add(this.cbManageDoctors);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvManageDoctors);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDoctorPicker";
            this.Text = "Choose Doctor";
            this.Load += new System.EventHandler(this.frmDoctorPicker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageDoctors)).EndInit();
            this.cmsManageDoctors.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cbDoctorSpecialization;
        private System.Windows.Forms.Button btnAddDoctor;
        private System.Windows.Forms.MaskedTextBox mtxtFilter;
        private System.Windows.Forms.ComboBox cbManageDoctors;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvManageDoctors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsManageDoctors;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem pickDoctorToolStripMenuItem;
    }
}