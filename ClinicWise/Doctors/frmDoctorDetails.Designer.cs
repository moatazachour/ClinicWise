namespace ClinicWise.Doctors
{
    partial class frmDoctorDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblMode = new System.Windows.Forms.Label();
            this.gpMedicalInfo = new System.Windows.Forms.GroupBox();
            this.lblSpecialization = new System.Windows.Forms.Label();
            this.lblDoctorID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.llEditDoctor = new System.Windows.Forms.LinkLabel();
            this.dgvNextAppointments = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlPersonCard1 = new ClinicWise.Persons.ctrlPersonCard();
            this.gpMedicalInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNextAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblMode.Location = new System.Drawing.Point(387, 11);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(318, 51);
            this.lblMode.TabIndex = 33;
            this.lblMode.Text = "Doctor Details";
            // 
            // gpMedicalInfo
            // 
            this.gpMedicalInfo.Controls.Add(this.lblSpecialization);
            this.gpMedicalInfo.Controls.Add(this.lblDoctorID);
            this.gpMedicalInfo.Controls.Add(this.label5);
            this.gpMedicalInfo.Controls.Add(this.label1);
            this.gpMedicalInfo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpMedicalInfo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.gpMedicalInfo.Location = new System.Drawing.Point(19, 390);
            this.gpMedicalInfo.Margin = new System.Windows.Forms.Padding(4);
            this.gpMedicalInfo.Name = "gpMedicalInfo";
            this.gpMedicalInfo.Padding = new System.Windows.Forms.Padding(4);
            this.gpMedicalInfo.Size = new System.Drawing.Size(1113, 102);
            this.gpMedicalInfo.TabIndex = 35;
            this.gpMedicalInfo.TabStop = false;
            this.gpMedicalInfo.Text = "Medical Informations";
            // 
            // lblSpecialization
            // 
            this.lblSpecialization.AutoSize = true;
            this.lblSpecialization.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(85)))));
            this.lblSpecialization.Location = new System.Drawing.Point(617, 46);
            this.lblSpecialization.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpecialization.Name = "lblSpecialization";
            this.lblSpecialization.Size = new System.Drawing.Size(66, 23);
            this.lblSpecialization.TabIndex = 15;
            this.lblSpecialization.Text = "[????]";
            // 
            // lblDoctorID
            // 
            this.lblDoctorID.AutoSize = true;
            this.lblDoctorID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(85)))));
            this.lblDoctorID.Location = new System.Drawing.Point(168, 46);
            this.lblDoctorID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDoctorID.Name = "lblDoctorID";
            this.lblDoctorID.Size = new System.Drawing.Size(66, 23);
            this.lblDoctorID.TabIndex = 10;
            this.lblDoctorID.Text = "[????]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(455, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Specialization:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Doctor ID:";
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(975, 961);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(155, 47);
            this.btnClose.TabIndex = 51;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // llEditDoctor
            // 
            this.llEditDoctor.AutoSize = true;
            this.llEditDoctor.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llEditDoctor.Location = new System.Drawing.Point(1012, 52);
            this.llEditDoctor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llEditDoctor.Name = "llEditDoctor";
            this.llEditDoctor.Size = new System.Drawing.Size(118, 23);
            this.llEditDoctor.TabIndex = 52;
            this.llEditDoctor.TabStop = true;
            this.llEditDoctor.Text = "Edit Doctor";
            this.llEditDoctor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llEditDoctor_LinkClicked);
            // 
            // dgvNextAppointments
            // 
            this.dgvNextAppointments.AllowUserToAddRows = false;
            this.dgvNextAppointments.AllowUserToDeleteRows = false;
            this.dgvNextAppointments.AllowUserToResizeRows = false;
            this.dgvNextAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvNextAppointments.BackgroundColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNextAppointments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNextAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNextAppointments.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNextAppointments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvNextAppointments.Location = new System.Drawing.Point(21, 572);
            this.dgvNextAppointments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvNextAppointments.MultiSelect = false;
            this.dgvNextAppointments.Name = "dgvNextAppointments";
            this.dgvNextAppointments.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNextAppointments.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNextAppointments.RowHeadersWidth = 51;
            this.dgvNextAppointments.RowTemplate.Height = 24;
            this.dgvNextAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNextAppointments.Size = new System.Drawing.Size(1109, 365);
            this.dgvNextAppointments.TabIndex = 53;
            this.dgvNextAppointments.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(21, 535);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 23);
            this.label2.TabIndex = 16;
            this.label2.Text = "Next Appointments:";
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.Location = new System.Drawing.Point(16, 81);
            this.ctrlPersonCard1.Margin = new System.Windows.Forms.Padding(5);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(1129, 299);
            this.ctrlPersonCard1.TabIndex = 34;
            // 
            // frmDoctorDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1159, 1029);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvNextAppointments);
            this.Controls.Add(this.llEditDoctor);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gpMedicalInfo);
            this.Controls.Add(this.ctrlPersonCard1);
            this.Controls.Add(this.lblMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDoctorDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doctor Details";
            this.Load += new System.EventHandler(this.frmDoctorDetails_Load);
            this.gpMedicalInfo.ResumeLayout(false);
            this.gpMedicalInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNextAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMode;
        private Persons.ctrlPersonCard ctrlPersonCard1;
        private System.Windows.Forms.GroupBox gpMedicalInfo;
        private System.Windows.Forms.Label lblSpecialization;
        private System.Windows.Forms.Label lblDoctorID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel llEditDoctor;
        private System.Windows.Forms.DataGridView dgvNextAppointments;
        private System.Windows.Forms.Label label2;
    }
}