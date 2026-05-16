namespace ClinicWise.Financial.Invoices
{
    partial class frmManageInvoices
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
            this.cbInvoiceStatus = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mtxtFilter = new System.Windows.Forms.MaskedTextBox();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsManageAppointments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cbManageInvoices = new System.Windows.Forms.ComboBox();
            this.dgvManageInvoices = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEditInvoice = new System.Windows.Forms.Button();
            this.voidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsManageAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageInvoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbInvoiceStatus
            // 
            this.cbInvoiceStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInvoiceStatus.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbInvoiceStatus.FormattingEnabled = true;
            this.cbInvoiceStatus.Items.AddRange(new object[] {
            "Draft",
            "Issued",
            "Partially Paid",
            "Paid",
            "Waived",
            "Void"});
            this.cbInvoiceStatus.Location = new System.Drawing.Point(228, 222);
            this.cbInvoiceStatus.Margin = new System.Windows.Forms.Padding(2);
            this.cbInvoiceStatus.Name = "cbInvoiceStatus";
            this.cbInvoiceStatus.Size = new System.Drawing.Size(218, 27);
            this.cbInvoiceStatus.TabIndex = 51;
            this.cbInvoiceStatus.SelectedIndexChanged += new System.EventHandler(this.cbInvoiceStatus_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1312, 610);
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
            this.lblRecordCount.Location = new System.Drawing.Point(129, 610);
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
            this.label2.Location = new System.Drawing.Point(20, 610);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 23);
            this.label2.TabIndex = 47;
            this.label2.Text = "# Records:";
            // 
            // mtxtFilter
            // 
            this.mtxtFilter.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtFilter.Location = new System.Drawing.Point(228, 220);
            this.mtxtFilter.Name = "mtxtFilter";
            this.mtxtFilter.Size = new System.Drawing.Size(355, 27);
            this.mtxtFilter.TabIndex = 46;
            this.mtxtFilter.TextChanged += new System.EventHandler(this.mtxtFilter_TextChanged);
            this.mtxtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtFilter_KeyPress);
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
            this.updateToolStripMenuItem,
            this.voidToolStripMenuItem});
            this.cmsManageAppointments.Name = "cmsManageDoctors";
            this.cmsManageAppointments.Size = new System.Drawing.Size(181, 110);
            // 
            // cbManageInvoices
            // 
            this.cbManageInvoices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbManageInvoices.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbManageInvoices.FormattingEnabled = true;
            this.cbManageInvoices.Items.AddRange(new object[] {
            "None",
            "Invoice ID",
            "Invoice Number",
            "Appointment ID",
            "Patient ID",
            "Patient Name",
            "Status"});
            this.cbManageInvoices.Location = new System.Drawing.Point(22, 221);
            this.cbManageInvoices.Margin = new System.Windows.Forms.Padding(2);
            this.cbManageInvoices.Name = "cbManageInvoices";
            this.cbManageInvoices.Size = new System.Drawing.Size(192, 27);
            this.cbManageInvoices.TabIndex = 45;
            this.cbManageInvoices.SelectedIndexChanged += new System.EventHandler(this.cbManageInvoices_SelectedIndexChanged);
            // 
            // dgvManageInvoices
            // 
            this.dgvManageInvoices.AllowUserToAddRows = false;
            this.dgvManageInvoices.AllowUserToDeleteRows = false;
            this.dgvManageInvoices.AllowUserToResizeRows = false;
            this.dgvManageInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvManageInvoices.BackgroundColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManageInvoices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvManageInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManageInvoices.ContextMenuStrip = this.cmsManageAppointments;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvManageInvoices.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvManageInvoices.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvManageInvoices.Location = new System.Drawing.Point(22, 258);
            this.dgvManageInvoices.Margin = new System.Windows.Forms.Padding(2);
            this.dgvManageInvoices.MultiSelect = false;
            this.dgvManageInvoices.Name = "dgvManageInvoices";
            this.dgvManageInvoices.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManageInvoices.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvManageInvoices.RowHeadersWidth = 51;
            this.dgvManageInvoices.RowTemplate.Height = 24;
            this.dgvManageInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManageInvoices.Size = new System.Drawing.Size(1412, 338);
            this.dgvManageInvoices.TabIndex = 44;
            this.dgvManageInvoices.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Azure;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(502, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(443, 80);
            this.label1.TabIndex = 42;
            this.label1.Text = "Manage Invoices";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::ClinicWise.Properties.Resources.invoice2_64;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1456, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // btnEditInvoice
            // 
            this.btnEditInvoice.Image = global::ClinicWise.Properties.Resources.invoice_update_48;
            this.btnEditInvoice.Location = new System.Drawing.Point(1358, 186);
            this.btnEditInvoice.Name = "btnEditInvoice";
            this.btnEditInvoice.Size = new System.Drawing.Size(76, 63);
            this.btnEditInvoice.TabIndex = 50;
            this.btnEditInvoice.UseVisualStyleBackColor = true;
            this.btnEditInvoice.Click += new System.EventHandler(this.btnEditInvoice_Click);
            // 
            // voidToolStripMenuItem
            // 
            this.voidToolStripMenuItem.Name = "voidToolStripMenuItem";
            this.voidToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.voidToolStripMenuItem.Text = "Void";
            this.voidToolStripMenuItem.Click += new System.EventHandler(this.voidToolStripMenuItem_Click);
            // 
            // frmManageInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1456, 679);
            this.Controls.Add(this.cbInvoiceStatus);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mtxtFilter);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbManageInvoices);
            this.Controls.Add(this.dgvManageInvoices);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEditInvoice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageInvoices";
            this.Text = "Manage Invoices";
            this.Load += new System.EventHandler(this.frmManageInvoices_Load);
            this.cmsManageAppointments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageInvoices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbInvoiceStatus;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mtxtFilter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsManageAppointments;
        private System.Windows.Forms.ComboBox cbManageInvoices;
        private System.Windows.Forms.DataGridView dgvManageInvoices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEditInvoice;
        private System.Windows.Forms.ToolStripMenuItem voidToolStripMenuItem;
    }
}