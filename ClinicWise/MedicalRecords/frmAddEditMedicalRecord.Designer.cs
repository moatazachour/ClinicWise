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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblMode = new System.Windows.Forms.Label();
            this.gbAppointmentInfos = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
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
            this.btnDoctorDetails = new System.Windows.Forms.Button();
            this.btnPickDoctor = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAppointment = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPatientID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbAppointmentInfos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptionItems)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(788, 764);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.btnSave.Location = new System.Drawing.Point(919, 764);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 38);
            this.btnSave.TabIndex = 56;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
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
            this.gbAppointmentInfos.Controls.Add(this.button1);
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
            this.gbAppointmentInfos.Controls.Add(this.btnDoctorDetails);
            this.gbAppointmentInfos.Controls.Add(this.btnPickDoctor);
            this.gbAppointmentInfos.Controls.Add(this.label6);
            this.gbAppointmentInfos.Controls.Add(this.lblAppointment);
            this.gbAppointmentInfos.Controls.Add(this.label4);
            this.gbAppointmentInfos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAppointmentInfos.ForeColor = System.Drawing.Color.DodgerBlue;
            this.gbAppointmentInfos.Location = new System.Drawing.Point(28, 118);
            this.gbAppointmentInfos.Name = "gbAppointmentInfos";
            this.gbAppointmentInfos.Size = new System.Drawing.Size(1006, 630);
            this.gbAppointmentInfos.TabIndex = 58;
            this.gbAppointmentInfos.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(879, 514);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 39);
            this.button1.TabIndex = 33;
            this.button1.Text = "Details";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnAddPrescription
            // 
            this.btnAddPrescription.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddPrescription.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddPrescription.ForeColor = System.Drawing.Color.Black;
            this.btnAddPrescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAddPrescription.Location = new System.Drawing.Point(879, 460);
            this.btnAddPrescription.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddPrescription.Name = "btnAddPrescription";
            this.btnAddPrescription.Size = new System.Drawing.Size(106, 39);
            this.btnAddPrescription.TabIndex = 32;
            this.btnAddPrescription.Text = "Add";
            this.btnAddPrescription.UseVisualStyleBackColor = true;
            // 
            // dgvPrescriptionItems
            // 
            this.dgvPrescriptionItems.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPrescriptionItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrescriptionItems.Location = new System.Drawing.Point(224, 460);
            this.dgvPrescriptionItems.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvPrescriptionItems.Name = "dgvPrescriptionItems";
            this.dgvPrescriptionItems.RowHeadersWidth = 51;
            this.dgvPrescriptionItems.RowTemplate.Height = 24;
            this.dgvPrescriptionItems.Size = new System.Drawing.Size(635, 137);
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
            this.txtAdditionalNotes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAdditionalNotes.Multiline = true;
            this.txtAdditionalNotes.Name = "txtAdditionalNotes";
            this.txtAdditionalNotes.Size = new System.Drawing.Size(762, 65);
            this.txtAdditionalNotes.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(25, 359);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 25);
            this.label5.TabIndex = 28;
            this.label5.Text = "Visit Description:";
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.Location = new System.Drawing.Point(224, 303);
            this.txtDiagnosis.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.Size = new System.Drawing.Size(762, 27);
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
            this.txtVisitDescription.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtVisitDescription.Multiline = true;
            this.txtVisitDescription.Name = "txtVisitDescription";
            this.txtVisitDescription.Size = new System.Drawing.Size(762, 84);
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
            this.cmbVisitType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbVisitType.Name = "cmbVisitType";
            this.cmbVisitType.Size = new System.Drawing.Size(284, 30);
            this.cmbVisitType.TabIndex = 24;
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
            // btnDoctorDetails
            // 
            this.btnDoctorDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDoctorDetails.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnDoctorDetails.ForeColor = System.Drawing.Color.Black;
            this.btnDoctorDetails.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDoctorDetails.Location = new System.Drawing.Point(316, 47);
            this.btnDoctorDetails.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDoctorDetails.Name = "btnDoctorDetails";
            this.btnDoctorDetails.Size = new System.Drawing.Size(70, 39);
            this.btnDoctorDetails.TabIndex = 2;
            this.btnDoctorDetails.Text = "Details";
            this.btnDoctorDetails.UseVisualStyleBackColor = true;
            // 
            // btnPickDoctor
            // 
            this.btnPickDoctor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPickDoctor.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnPickDoctor.ForeColor = System.Drawing.Color.Black;
            this.btnPickDoctor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPickDoctor.Location = new System.Drawing.Point(224, 47);
            this.btnPickDoctor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPickDoctor.Name = "btnPickDoctor";
            this.btnPickDoctor.Size = new System.Drawing.Size(69, 39);
            this.btnPickDoctor.TabIndex = 1;
            this.btnPickDoctor.Text = "Pick";
            this.btnPickDoctor.UseVisualStyleBackColor = true;
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
            // lblPatientID
            // 
            this.lblPatientID.AutoSize = true;
            this.lblPatientID.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientID.Location = new System.Drawing.Point(176, 84);
            this.lblPatientID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Size = new System.Drawing.Size(37, 18);
            this.lblPatientID.TabIndex = 53;
            this.lblPatientID.Text = "N/A";
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
            // frmAddEditMedicalRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1066, 818);
            this.Controls.Add(this.gbAppointmentInfos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPatientID);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmAddEditMedicalRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddEditMedicalRecord";
            this.Load += new System.EventHandler(this.frmAddEditMedicalRecord_Load);
            this.gbAppointmentInfos.ResumeLayout(false);
            this.gbAppointmentInfos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptionItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.GroupBox gbAppointmentInfos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDoctorDetails;
        private System.Windows.Forms.Button btnPickDoctor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAppointment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPatientID;
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
        private System.Windows.Forms.Button button1;
    }
}