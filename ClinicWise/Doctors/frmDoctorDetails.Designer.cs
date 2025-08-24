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
            this.lblMode = new System.Windows.Forms.Label();
            this.gpMedicalInfo = new System.Windows.Forms.GroupBox();
            this.lblSpecialization = new System.Windows.Forms.Label();
            this.lblDoctorID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlPersonCard1 = new ClinicWise.Persons.ctrlPersonCard();
            this.llEditDoctor = new System.Windows.Forms.LinkLabel();
            this.gpMedicalInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblMode.Location = new System.Drawing.Point(290, 9);
            this.lblMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(251, 41);
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
            this.gpMedicalInfo.Location = new System.Drawing.Point(14, 317);
            this.gpMedicalInfo.Name = "gpMedicalInfo";
            this.gpMedicalInfo.Size = new System.Drawing.Size(835, 83);
            this.gpMedicalInfo.TabIndex = 35;
            this.gpMedicalInfo.TabStop = false;
            this.gpMedicalInfo.Text = "Medical Informations";
            // 
            // lblSpecialization
            // 
            this.lblSpecialization.AutoSize = true;
            this.lblSpecialization.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(85)))));
            this.lblSpecialization.Location = new System.Drawing.Point(463, 37);
            this.lblSpecialization.Name = "lblSpecialization";
            this.lblSpecialization.Size = new System.Drawing.Size(50, 18);
            this.lblSpecialization.TabIndex = 15;
            this.lblSpecialization.Text = "[????]";
            // 
            // lblDoctorID
            // 
            this.lblDoctorID.AutoSize = true;
            this.lblDoctorID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(85)))));
            this.lblDoctorID.Location = new System.Drawing.Point(126, 37);
            this.lblDoctorID.Name = "lblDoctorID";
            this.lblDoctorID.Size = new System.Drawing.Size(50, 18);
            this.lblDoctorID.TabIndex = 10;
            this.lblDoctorID.Text = "[????]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(341, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Specialization:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Doctor ID:";
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(733, 417);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 38);
            this.btnClose.TabIndex = 51;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.Location = new System.Drawing.Point(12, 66);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(847, 243);
            this.ctrlPersonCard1.TabIndex = 34;
            // 
            // llEditDoctor
            // 
            this.llEditDoctor.AutoSize = true;
            this.llEditDoctor.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llEditDoctor.Location = new System.Drawing.Point(759, 42);
            this.llEditDoctor.Name = "llEditDoctor";
            this.llEditDoctor.Size = new System.Drawing.Size(98, 21);
            this.llEditDoctor.TabIndex = 52;
            this.llEditDoctor.TabStop = true;
            this.llEditDoctor.Text = "Edit Doctor";
            this.llEditDoctor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llEditDoctor_LinkClicked);
            // 
            // frmDoctorDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(869, 479);
            this.Controls.Add(this.llEditDoctor);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gpMedicalInfo);
            this.Controls.Add(this.ctrlPersonCard1);
            this.Controls.Add(this.lblMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDoctorDetails";
            this.Text = "frmDoctorDetails";
            this.Load += new System.EventHandler(this.frmDoctorDetails_Load);
            this.gpMedicalInfo.ResumeLayout(false);
            this.gpMedicalInfo.PerformLayout();
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
    }
}