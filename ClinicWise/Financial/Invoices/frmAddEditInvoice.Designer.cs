namespace ClinicWise.Financial.Invoices
{
    partial class frmAddEditInvoice
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnAddInvoiceItem = new System.Windows.Forms.Button();
            this.dgvInvoiceItems = new System.Windows.Forms.DataGridView();
            this.cmsManageInvoiceItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label7 = new System.Windows.Forms.Label();
            this.gbInvoiceInfos = new System.Windows.Forms.GroupBox();
            this.btnResetForm = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbDiscountType = new System.Windows.Forms.ComboBox();
            this.gbDiscount = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nudDiscountAmount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudDiscountPercent = new System.Windows.Forms.NumericUpDown();
            this.cbDiscountMethod = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblAppointmentID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPatient = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblMode = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCheckMedicalRecord = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceItems)).BeginInit();
            this.cmsManageInvoiceItems.SuspendLayout();
            this.gbInvoiceInfos.SuspendLayout();
            this.gbDiscount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscountAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscountPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 176);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 19);
            this.label2.TabIndex = 60;
            this.label2.Text = "Invoice Number:";
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.AutoSize = true;
            this.lblInvoiceNumber.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceNumber.Location = new System.Drawing.Point(183, 176);
            this.lblInvoiceNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(40, 19);
            this.lblInvoiceNumber.TabIndex = 61;
            this.lblInvoiceNumber.Text = "N/A";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // btnDetails
            // 
            this.btnDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDetails.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnDetails.ForeColor = System.Drawing.Color.Black;
            this.btnDetails.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDetails.Location = new System.Drawing.Point(60, 515);
            this.btnDetails.Margin = new System.Windows.Forms.Padding(2);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(106, 31);
            this.btnDetails.TabIndex = 34;
            this.btnDetails.Text = "Details";
            this.btnDetails.UseVisualStyleBackColor = true;
            // 
            // btnAddInvoiceItem
            // 
            this.btnAddInvoiceItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddInvoiceItem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddInvoiceItem.ForeColor = System.Drawing.Color.Black;
            this.btnAddInvoiceItem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAddInvoiceItem.Location = new System.Drawing.Point(60, 474);
            this.btnAddInvoiceItem.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddInvoiceItem.Name = "btnAddInvoiceItem";
            this.btnAddInvoiceItem.Size = new System.Drawing.Size(106, 31);
            this.btnAddInvoiceItem.TabIndex = 32;
            this.btnAddInvoiceItem.Text = "Add";
            this.btnAddInvoiceItem.UseVisualStyleBackColor = true;
            // 
            // dgvInvoiceItems
            // 
            this.dgvInvoiceItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvInvoiceItems.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvInvoiceItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoiceItems.ContextMenuStrip = this.cmsManageInvoiceItems;
            this.dgvInvoiceItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInvoiceItems.Location = new System.Drawing.Point(186, 431);
            this.dgvInvoiceItems.Margin = new System.Windows.Forms.Padding(2);
            this.dgvInvoiceItems.Name = "dgvInvoiceItems";
            this.dgvInvoiceItems.RowHeadersWidth = 51;
            this.dgvInvoiceItems.RowTemplate.Height = 24;
            this.dgvInvoiceItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoiceItems.Size = new System.Drawing.Size(870, 156);
            this.dgvInvoiceItems.TabIndex = 31;
            // 
            // cmsManageInvoiceItems
            // 
            this.cmsManageInvoiceItems.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsManageInvoiceItems.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManageInvoiceItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.addToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsManageInvoiceItems.Name = "cmsManageDoctors";
            this.cmsManageInvoiceItems.Size = new System.Drawing.Size(179, 114);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(15, 431);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 25);
            this.label7.TabIndex = 30;
            this.label7.Text = "Invoice Items:";
            // 
            // gbInvoiceInfos
            // 
            this.gbInvoiceInfos.Controls.Add(this.btnDelete);
            this.gbInvoiceInfos.Controls.Add(this.btnResetForm);
            this.gbInvoiceInfos.Controls.Add(this.lblTotalAmount);
            this.gbInvoiceInfos.Controls.Add(this.label13);
            this.gbInvoiceInfos.Controls.Add(this.cbDiscountType);
            this.gbInvoiceInfos.Controls.Add(this.gbDiscount);
            this.gbInvoiceInfos.Controls.Add(this.label1);
            this.gbInvoiceInfos.Controls.Add(this.lblSubTotal);
            this.gbInvoiceInfos.Controls.Add(this.label10);
            this.gbInvoiceInfos.Controls.Add(this.lblDoctor);
            this.gbInvoiceInfos.Controls.Add(this.label9);
            this.gbInvoiceInfos.Controls.Add(this.lblAppointmentID);
            this.gbInvoiceInfos.Controls.Add(this.label8);
            this.gbInvoiceInfos.Controls.Add(this.btnDetails);
            this.gbInvoiceInfos.Controls.Add(this.btnAddInvoiceItem);
            this.gbInvoiceInfos.Controls.Add(this.dgvInvoiceItems);
            this.gbInvoiceInfos.Controls.Add(this.label7);
            this.gbInvoiceInfos.Controls.Add(this.lblPatient);
            this.gbInvoiceInfos.Controls.Add(this.label4);
            this.gbInvoiceInfos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInvoiceInfos.ForeColor = System.Drawing.Color.DodgerBlue;
            this.gbInvoiceInfos.Location = new System.Drawing.Point(34, 209);
            this.gbInvoiceInfos.Name = "gbInvoiceInfos";
            this.gbInvoiceInfos.Size = new System.Drawing.Size(1079, 697);
            this.gbInvoiceInfos.TabIndex = 64;
            this.gbInvoiceInfos.TabStop = false;
            // 
            // btnResetForm
            // 
            this.btnResetForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnResetForm.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnResetForm.ForeColor = System.Drawing.Color.Black;
            this.btnResetForm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResetForm.Location = new System.Drawing.Point(908, 240);
            this.btnResetForm.Margin = new System.Windows.Forms.Padding(2);
            this.btnResetForm.Name = "btnResetForm";
            this.btnResetForm.Size = new System.Drawing.Size(148, 48);
            this.btnResetForm.TabIndex = 66;
            this.btnResetForm.Text = "Reset Form";
            this.btnResetForm.UseVisualStyleBackColor = true;
            this.btnResetForm.Click += new System.EventHandler(this.btnResetForm_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.BackColor = System.Drawing.Color.Azure;
            this.lblTotalAmount.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTotalAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTotalAmount.Location = new System.Drawing.Point(824, 618);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(51, 56);
            this.lblTotalAmount.TabIndex = 54;
            this.lblTotalAmount.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.ForestGreen;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(500, 631);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(249, 41);
            this.label13.TabIndex = 53;
            this.label13.Text = "Total Amount:";
            // 
            // cbDiscountType
            // 
            this.cbDiscountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDiscountType.FormattingEnabled = true;
            this.cbDiscountType.Items.AddRange(new object[] {
            "None",
            "Loyality",
            "Financial Hardship",
            "Staff",
            "Waiver"});
            this.cbDiscountType.Location = new System.Drawing.Point(212, 173);
            this.cbDiscountType.Name = "cbDiscountType";
            this.cbDiscountType.Size = new System.Drawing.Size(212, 27);
            this.cbDiscountType.TabIndex = 52;
            this.cbDiscountType.SelectedIndexChanged += new System.EventHandler(this.cbDiscountType_SelectedIndexChanged);
            // 
            // gbDiscount
            // 
            this.gbDiscount.Controls.Add(this.label5);
            this.gbDiscount.Controls.Add(this.nudDiscountAmount);
            this.gbDiscount.Controls.Add(this.label3);
            this.gbDiscount.Controls.Add(this.nudDiscountPercent);
            this.gbDiscount.Controls.Add(this.cbDiscountMethod);
            this.gbDiscount.Controls.Add(this.label6);
            this.gbDiscount.Controls.Add(this.label11);
            this.gbDiscount.Enabled = false;
            this.gbDiscount.Location = new System.Drawing.Point(88, 228);
            this.gbDiscount.Name = "gbDiscount";
            this.gbDiscount.Size = new System.Drawing.Size(805, 167);
            this.gbDiscount.TabIndex = 51;
            this.gbDiscount.TabStop = false;
            this.gbDiscount.Text = "Discount Details";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(335, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 28);
            this.label5.TabIndex = 53;
            this.label5.Text = "%";
            // 
            // nudDiscountAmount
            // 
            this.nudDiscountAmount.Enabled = false;
            this.nudDiscountAmount.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDiscountAmount.Location = new System.Drawing.Point(594, 108);
            this.nudDiscountAmount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudDiscountAmount.Name = "nudDiscountAmount";
            this.nudDiscountAmount.Size = new System.Drawing.Size(120, 27);
            this.nudDiscountAmount.TabIndex = 52;
            this.nudDiscountAmount.ValueChanged += new System.EventHandler(this.nudDiscountAmount_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(484, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 23);
            this.label3.TabIndex = 51;
            this.label3.Text = "Amount:";
            // 
            // nudDiscountPercent
            // 
            this.nudDiscountPercent.Enabled = false;
            this.nudDiscountPercent.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudDiscountPercent.Location = new System.Drawing.Point(200, 112);
            this.nudDiscountPercent.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudDiscountPercent.Name = "nudDiscountPercent";
            this.nudDiscountPercent.Size = new System.Drawing.Size(120, 27);
            this.nudDiscountPercent.TabIndex = 48;
            this.nudDiscountPercent.ValueChanged += new System.EventHandler(this.nudDiscountPercent_ValueChanged);
            // 
            // cbDiscountMethod
            // 
            this.cbDiscountMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDiscountMethod.FormattingEnabled = true;
            this.cbDiscountMethod.Items.AddRange(new object[] {
            "By Amount",
            "By Percentage"});
            this.cbDiscountMethod.Location = new System.Drawing.Point(200, 49);
            this.cbDiscountMethod.Name = "cbDiscountMethod";
            this.cbDiscountMethod.Size = new System.Drawing.Size(212, 27);
            this.cbDiscountMethod.TabIndex = 50;
            this.cbDiscountMethod.SelectedIndexChanged += new System.EventHandler(this.cbDiscountMethod_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(20, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 23);
            this.label6.TabIndex = 44;
            this.label6.Text = "Discount Method:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(61, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 23);
            this.label11.TabIndex = 47;
            this.label11.Text = "Percentage:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(56, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 23);
            this.label1.TabIndex = 51;
            this.label1.Text = "Discount Type:";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.BackColor = System.Drawing.Color.Azure;
            this.lblSubTotal.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblSubTotal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSubTotal.Location = new System.Drawing.Point(205, 127);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(59, 23);
            this.lblSubTotal.TabIndex = 43;
            this.lblSubTotal.Text = "[N/A]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(106, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 23);
            this.label10.TabIndex = 42;
            this.label10.Text = "SubTotal:";
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.BackColor = System.Drawing.Color.Azure;
            this.lblDoctor.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoctor.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblDoctor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDoctor.Location = new System.Drawing.Point(205, 80);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(59, 23);
            this.lblDoctor.TabIndex = 41;
            this.lblDoctor.Text = "[N/A]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(123, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 23);
            this.label9.TabIndex = 40;
            this.label9.Text = "Doctor:";
            // 
            // lblAppointmentID
            // 
            this.lblAppointmentID.AutoSize = true;
            this.lblAppointmentID.BackColor = System.Drawing.Color.Azure;
            this.lblAppointmentID.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentID.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblAppointmentID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAppointmentID.Location = new System.Drawing.Point(881, 32);
            this.lblAppointmentID.Name = "lblAppointmentID";
            this.lblAppointmentID.Size = new System.Drawing.Size(59, 23);
            this.lblAppointmentID.TabIndex = 39;
            this.lblAppointmentID.Text = "[N/A]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(716, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 23);
            this.label8.TabIndex = 38;
            this.label8.Text = "Appointment ID:";
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.BackColor = System.Drawing.Color.Azure;
            this.lblPatient.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatient.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPatient.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPatient.Location = new System.Drawing.Point(208, 32);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(59, 23);
            this.lblPatient.TabIndex = 10;
            this.lblPatient.Text = "[N/A]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(123, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Patient:";
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(844, 925);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 47);
            this.btnClose.TabIndex = 63;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblMode.Location = new System.Drawing.Point(442, 90);
            this.lblMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(271, 38);
            this.lblMode.TabIndex = 59;
            this.lblMode.Text = "Manage Invoice";
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(974, 925);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 47);
            this.btnSave.TabIndex = 62;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::ClinicWise.Properties.Resources.invoice_64;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1141, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 65;
            this.pictureBox1.TabStop = false;
            // 
            // btnCheckMedicalRecord
            // 
            this.btnCheckMedicalRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCheckMedicalRecord.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnCheckMedicalRecord.ForeColor = System.Drawing.Color.Black;
            this.btnCheckMedicalRecord.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCheckMedicalRecord.Location = new System.Drawing.Point(918, 170);
            this.btnCheckMedicalRecord.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheckMedicalRecord.Name = "btnCheckMedicalRecord";
            this.btnCheckMedicalRecord.Size = new System.Drawing.Size(195, 34);
            this.btnCheckMedicalRecord.TabIndex = 55;
            this.btnCheckMedicalRecord.Text = "Check Medical Record";
            this.btnCheckMedicalRecord.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete.Location = new System.Drawing.Point(60, 556);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(106, 31);
            this.btnDelete.TabIndex = 67;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // frmAddEditInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1141, 983);
            this.Controls.Add(this.btnCheckMedicalRecord);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblInvoiceNumber);
            this.Controls.Add(this.gbInvoiceInfos);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditInvoice";
            this.Text = "Manage Invoice";
            this.Load += new System.EventHandler(this.frmAddEditInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceItems)).EndInit();
            this.cmsManageInvoiceItems.ResumeLayout(false);
            this.gbInvoiceInfos.ResumeLayout(false);
            this.gbInvoiceInfos.PerformLayout();
            this.gbDiscount.ResumeLayout(false);
            this.gbDiscount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscountAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscountPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.GroupBox gbInvoiceInfos;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnAddInvoiceItem;
        private System.Windows.Forms.DataGridView dgvInvoiceItems;
        private System.Windows.Forms.ContextMenuStrip cmsManageInvoiceItems;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblAppointmentID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudDiscountPercent;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbDiscountMethod;
        private System.Windows.Forms.ComboBox cbDiscountType;
        private System.Windows.Forms.GroupBox gbDiscount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudDiscountAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnCheckMedicalRecord;
        private System.Windows.Forms.Button btnResetForm;
        private System.Windows.Forms.Button btnDelete;
    }
}