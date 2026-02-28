namespace ClinicWise.MedicalRecords
{
    partial class frmAddEditMedicalRecord
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblMode = new System.Windows.Forms.Label();
            this.gbAppointmentInfos = new System.Windows.Forms.GroupBox();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAddPrescription = new System.Windows.Forms.Button();
            this.dgvPrescriptionItems = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAdditionalNotes = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiagnosis = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVisitDescription = new System.Windows.Forms.TextBox();
            this.cmbVisitType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAppointmentDatails = new System.Windows.Forms.Button();
            this.btnPickAppointment = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAppointment = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMedicalRecordID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbAppointmentInfos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptionItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(823, 780);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 38);
            this.btnClose.TabIndex = 57;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(953, 780);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 38);
            this.btnSave.TabIndex = 56;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblMode.Location = new System.Drawing.Point(312, 7);
            this.lblMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(463, 41);
            this.lblMode.TabIndex = 51;
            this.lblMode.Text = "Add New Medical  Record";
            // 
            // gbAppointmentInfos
            // 
            this.gbAppointmentInfos.Controls.Add(this.btnDetails);
            this.gbAppointmentInfos.Controls.Add(this.btnUpdate);
            this.gbAppointmentInfos.Controls.Add(this.btnAddPrescription);
            this.gbAppointmentInfos.Controls.Add(this.dgvPrescriptionItems);
            this.gbAppointmentInfos.Controls.Add(this.label7);
            this.gbAppointmentInfos.Controls.Add(this.txtAdditionalNotes);
            this.gbAppointmentInfos.Controls.Add(this.label5);
            this.gbAppointmentInfos.Controls.Add(this.txtDiagnosis);
            this.gbAppointmentInfos.Controls.Add(this.label3);
            this.gbAppointmentInfos.Controls.Add(this.txtVisitDescription);
            this.gbAppointmentInfos.Controls.Add(this.cmbVisitType);
            this.gbAppointmentInfos.Controls.Add(this.label1);
            this.gbAppointmentInfos.Controls.Add(this.btnAppointmentDatails);
            this.gbAppointmentInfos.Controls.Add(this.btnPickAppointment);
            this.gbAppointmentInfos.Controls.Add(this.label6);
            this.gbAppointmentInfos.Controls.Add(this.lblAppointment);
            this.gbAppointmentInfos.Controls.Add(this.label4);
            this.gbAppointmentInfos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAppointmentInfos.ForeColor = System.Drawing.Color.DodgerBlue;
            this.gbAppointmentInfos.Location = new System.Drawing.Point(28, 118);
            this.gbAppointmentInfos.Name = "gbAppointmentInfos";
            this.gbAppointmentInfos.Size = new System.Drawing.Size(1049, 644);
            this.gbAppointmentInfos.TabIndex = 58;
            this.gbAppointmentInfos.TabStop = false;
            // 
            // btnDetails
            // 
            this.btnDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDetails.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnDetails.ForeColor = System.Drawing.Color.Black;
            this.btnDetails.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDetails.Location = new System.Drawing.Point(925, 577);
            this.btnDetails.Margin = new System.Windows.Forms.Padding(2);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(106, 39);
            this.btnDetails.TabIndex = 34;
            this.btnDetails.Text = "Details";
            this.btnDetails.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUpdate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUpdate.Location = new System.Drawing.Point(925, 516);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(106, 39);
            this.btnUpdate.TabIndex = 33;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnAddPrescription
            // 
            this.btnAddPrescription.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddPrescription.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddPrescription.ForeColor = System.Drawing.Color.Black;
            this.btnAddPrescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAddPrescription.Location = new System.Drawing.Point(925, 460);
            this.btnAddPrescription.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddPrescription.Name = "btnAddPrescription";
            this.btnAddPrescription.Size = new System.Drawing.Size(106, 39);
            this.btnAddPrescription.TabIndex = 32;
            this.btnAddPrescription.Text = "Add";
            this.btnAddPrescription.UseVisualStyleBackColor = true;
            this.btnAddPrescription.Click += new System.EventHandler(this.btnAddPrescription_Click);
            // 
            // dgvPrescriptionItems
            // 
            this.dgvPrescriptionItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPrescriptionItems.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPrescriptionItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrescriptionItems.Location = new System.Drawing.Point(224, 460);
            this.dgvPrescriptionItems.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPrescriptionItems.Name = "dgvPrescriptionItems";
            this.dgvPrescriptionItems.RowHeadersWidth = 51;
            this.dgvPrescriptionItems.RowTemplate.Height = 24;
            this.dgvPrescriptionItems.Size = new System.Drawing.Size(687, 156);
            this.dgvPrescriptionItems.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(65, 469);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 25);
            this.label7.TabIndex = 30;
            this.label7.Text = "Prescription:";
            // 
            // txtAdditionalNotes
            // 
            this.txtAdditionalNotes.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdditionalNotes.Location = new System.Drawing.Point(224, 359);
            this.txtAdditionalNotes.Margin = new System.Windows.Forms.Padding(2);
            this.txtAdditionalNotes.Multiline = true;
            this.txtAdditionalNotes.Name = "txtAdditionalNotes";
            this.txtAdditionalNotes.Size = new System.Drawing.Size(807, 65);
            this.txtAdditionalNotes.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(16, 359);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 25);
            this.label5.TabIndex = 28;
            this.label5.Text = "Additional Notes:";
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.Location = new System.Drawing.Point(224, 303);
            this.txtDiagnosis.Margin = new System.Windows.Forms.Padding(2);
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.Size = new System.Drawing.Size(807, 27);
            this.txtDiagnosis.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(85, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 25);
            this.label3.TabIndex = 26;
            this.label3.Text = "Diagnosis:";
            // 
            // txtVisitDescription
            // 
            this.txtVisitDescription.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVisitDescription.Location = new System.Drawing.Point(224, 188);
            this.txtVisitDescription.Margin = new System.Windows.Forms.Padding(2);
            this.txtVisitDescription.Multiline = true;
            this.txtVisitDescription.Name = "txtVisitDescription";
            this.txtVisitDescription.Size = new System.Drawing.Size(807, 84);
            this.txtVisitDescription.TabIndex = 25;
            // 
            // cmbVisitType
            // 
            this.cmbVisitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVisitType.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVisitType.FormattingEnabled = true;
            this.cmbVisitType.Items.AddRange(new object[] {
            "Consultation",
            "Follow up",
            "Emergency",
            "Routine Check",
            "Vaccination",
            "Lab Test"});
            this.cmbVisitType.Location = new System.Drawing.Point(224, 121);
            this.cmbVisitType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbVisitType.Name = "cmbVisitType";
            this.cmbVisitType.Size = new System.Drawing.Size(284, 30);
            this.cmbVisitType.TabIndex = 24;
            this.cmbVisitType.Validating += new System.ComponentModel.CancelEventHandler(this.cmbVisitType_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(25, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 25);
            this.label1.TabIndex = 22;
            this.label1.Text = "Visit Description:";
            // 
            // btnAppointmentDatails
            // 
            this.btnAppointmentDatails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAppointmentDatails.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnAppointmentDatails.ForeColor = System.Drawing.Color.Black;
            this.btnAppointmentDatails.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAppointmentDatails.Location = new System.Drawing.Point(316, 47);
            this.btnAppointmentDatails.Margin = new System.Windows.Forms.Padding(2);
            this.btnAppointmentDatails.Name = "btnAppointmentDatails";
            this.btnAppointmentDatails.Size = new System.Drawing.Size(70, 39);
            this.btnAppointmentDatails.TabIndex = 2;
            this.btnAppointmentDatails.Text = "Details";
            this.btnAppointmentDatails.UseVisualStyleBackColor = true;
            this.btnAppointmentDatails.Click += new System.EventHandler(this.btnAppointmentDatails_Click);
            // 
            // btnPickAppointment
            // 
            this.btnPickAppointment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPickAppointment.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnPickAppointment.ForeColor = System.Drawing.Color.Black;
            this.btnPickAppointment.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPickAppointment.Location = new System.Drawing.Point(224, 47);
            this.btnPickAppointment.Margin = new System.Windows.Forms.Padding(2);
            this.btnPickAppointment.Name = "btnPickAppointment";
            this.btnPickAppointment.Size = new System.Drawing.Size(69, 39);
            this.btnPickAppointment.TabIndex = 1;
            this.btnPickAppointment.Text = "Pick";
            this.btnPickAppointment.UseVisualStyleBackColor = true;
            this.btnPickAppointment.Click += new System.EventHandler(this.btnPickAppointment_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(87, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 25);
            this.label6.TabIndex = 19;
            this.label6.Text = "Visit Type:";
            // 
            // lblAppointment
            // 
            this.lblAppointment.AutoSize = true;
            this.lblAppointment.BackColor = System.Drawing.Color.Azure;
            this.lblAppointment.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblAppointment.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblAppointment.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAppointment.Location = new System.Drawing.Point(414, 53);
            this.lblAppointment.Name = "lblAppointment";
            this.lblAppointment.Size = new System.Drawing.Size(190, 25);
            this.lblAppointment.TabIndex = 10;
            this.lblAppointment.Text = "[Not selected yet]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(51, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Appointment:";
            // 
            // lblMedicalRecordID
            // 
            this.lblMedicalRecordID.AutoSize = true;
            this.lblMedicalRecordID.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedicalRecordID.Location = new System.Drawing.Point(176, 84);
            this.lblMedicalRecordID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMedicalRecordID.Name = "lblMedicalRecordID";
            this.lblMedicalRecordID.Size = new System.Drawing.Size(37, 18);
            this.lblMedicalRecordID.TabIndex = 53;
            this.lblMedicalRecordID.Text = "N/A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 18);
            this.label2.TabIndex = 52;
            this.label2.Text = "Medical Record ID:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddEditMedicalRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1102, 840);
            this.Controls.Add(this.gbAppointmentInfos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMedicalRecordID);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmAddEditMedicalRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddEditMedicalRecord";
            this.Load += new System.EventHandler(this.frmAddEditMedicalRecord_Load);
            this.gbAppointmentInfos.ResumeLayout(false);
            this.gbAppointmentInfos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptionItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.GroupBox gbAppointmentInfos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAppointmentDatails;
        private System.Windows.Forms.Button btnPickAppointment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAppointment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMedicalRecordID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVisitDescription;
        private System.Windows.Forms.ComboBox cmbVisitType;
        private System.Windows.Forms.TextBox txtDiagnosis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAdditionalNotes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddPrescription;
        private System.Windows.Forms.DataGridView dgvPrescriptionItems;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnDetails;
    }
}