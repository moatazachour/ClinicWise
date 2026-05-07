namespace ClinicWise.Financial.Visit_Fees
{
    partial class frmManageVisitFees
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
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsManageAppointments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbVisitTypes = new System.Windows.Forms.ComboBox();
            this.cbManageVisitFees = new System.Windows.Forms.ComboBox();
            this.dgvManageVisitTypesFees = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddVisitFee = new System.Windows.Forms.Button();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.cmsManageAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageVisitTypesFees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1040, 631);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 42);
            this.btnClose.TabIndex = 59;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.Location = new System.Drawing.Point(135, 631);
            this.lblRecordCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(21, 23);
            this.lblRecordCount.TabIndex = 58;
            this.lblRecordCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 631);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 23);
            this.label2.TabIndex = 57;
            this.label2.Text = "# Records:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Azure;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(385, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(443, 85);
            this.label1.TabIndex = 52;
            this.label1.Text = "Manage Visit Types Fees";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            // 
            // cmsManageAppointments
            // 
            this.cmsManageAppointments.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsManageAppointments.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManageAppointments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.addToolStripMenuItem});
            this.cmsManageAppointments.Name = "cmsManageDoctors";
            this.cmsManageAppointments.Size = new System.Drawing.Size(179, 62);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // cbVisitTypes
            // 
            this.cbVisitTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVisitTypes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVisitTypes.FormattingEnabled = true;
            this.cbVisitTypes.Items.AddRange(new object[] {
            "Consultation",
            "Follow up",
            "Emergency",
            "Routine Check",
            "Vaccination",
            "Lab Test"});
            this.cbVisitTypes.Location = new System.Drawing.Point(279, 231);
            this.cbVisitTypes.Margin = new System.Windows.Forms.Padding(2);
            this.cbVisitTypes.Name = "cbVisitTypes";
            this.cbVisitTypes.Size = new System.Drawing.Size(245, 27);
            this.cbVisitTypes.TabIndex = 61;
            this.cbVisitTypes.SelectedIndexChanged += new System.EventHandler(this.cbVisitTypes_SelectedIndexChanged);
            // 
            // cbManageVisitFees
            // 
            this.cbManageVisitFees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbManageVisitFees.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbManageVisitFees.FormattingEnabled = true;
            this.cbManageVisitFees.Items.AddRange(new object[] {
            "None",
            "Status",
            "Visit Type"});
            this.cbManageVisitFees.Location = new System.Drawing.Point(30, 231);
            this.cbManageVisitFees.Margin = new System.Windows.Forms.Padding(2);
            this.cbManageVisitFees.Name = "cbManageVisitFees";
            this.cbManageVisitFees.Size = new System.Drawing.Size(214, 27);
            this.cbManageVisitFees.TabIndex = 55;
            this.cbManageVisitFees.SelectedIndexChanged += new System.EventHandler(this.cbManageVisitFees_SelectedIndexChanged);
            // 
            // dgvManageVisitTypesFees
            // 
            this.dgvManageVisitTypesFees.AllowUserToAddRows = false;
            this.dgvManageVisitTypesFees.AllowUserToDeleteRows = false;
            this.dgvManageVisitTypesFees.AllowUserToResizeRows = false;
            this.dgvManageVisitTypesFees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvManageVisitTypesFees.BackgroundColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManageVisitTypesFees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvManageVisitTypesFees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManageVisitTypesFees.ContextMenuStrip = this.cmsManageAppointments;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvManageVisitTypesFees.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvManageVisitTypesFees.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvManageVisitTypesFees.Location = new System.Drawing.Point(30, 277);
            this.dgvManageVisitTypesFees.Margin = new System.Windows.Forms.Padding(2);
            this.dgvManageVisitTypesFees.MultiSelect = false;
            this.dgvManageVisitTypesFees.Name = "dgvManageVisitTypesFees";
            this.dgvManageVisitTypesFees.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManageVisitTypesFees.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvManageVisitTypesFees.RowHeadersWidth = 51;
            this.dgvManageVisitTypesFees.RowTemplate.Height = 24;
            this.dgvManageVisitTypesFees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManageVisitTypesFees.Size = new System.Drawing.Size(1132, 338);
            this.dgvManageVisitTypesFees.TabIndex = 54;
            this.dgvManageVisitTypesFees.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Azure;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::ClinicWise.Properties.Resources.visit_type_fees;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1191, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddVisitFee
            // 
            this.btnAddVisitFee.Image = global::ClinicWise.Properties.Resources.Add_Person_40;
            this.btnAddVisitFee.Location = new System.Drawing.Point(1091, 206);
            this.btnAddVisitFee.Name = "btnAddVisitFee";
            this.btnAddVisitFee.Size = new System.Drawing.Size(71, 56);
            this.btnAddVisitFee.TabIndex = 60;
            this.btnAddVisitFee.UseVisualStyleBackColor = true;
            this.btnAddVisitFee.Click += new System.EventHandler(this.btnAddVisitFee_Click);
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "All",
            "Active",
            "InActive"});
            this.cbStatus.Location = new System.Drawing.Point(279, 231);
            this.cbStatus.Margin = new System.Windows.Forms.Padding(2);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(160, 27);
            this.cbStatus.TabIndex = 62;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // frmManageVisitFees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1191, 694);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbVisitTypes);
            this.Controls.Add(this.cbManageVisitFees);
            this.Controls.Add(this.dgvManageVisitTypesFees);
            this.Controls.Add(this.btnAddVisitFee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageVisitFees";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Visit Fees";
            this.Load += new System.EventHandler(this.frmManageVisitFees_Load);
            this.cmsManageAppointments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageVisitTypesFees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsManageAppointments;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbVisitTypes;
        private System.Windows.Forms.ComboBox cbManageVisitFees;
        private System.Windows.Forms.DataGridView dgvManageVisitTypesFees;
        private System.Windows.Forms.Button btnAddVisitFee;
        private System.Windows.Forms.ComboBox cbStatus;
    }
}