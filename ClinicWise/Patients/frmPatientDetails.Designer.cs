namespace ClinicWise.Patients
{
    partial class frmPatientDetails
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
            this.ctrlPersonCard1 = new ClinicWise.Persons.ctrlPersonCard();
            this.gpGuardianInfo = new System.Windows.Forms.GroupBox();
            this.lblNationalNo = new System.Windows.Forms.Label();
            this.lblGuardianID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRelationship = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.llEditPatient = new System.Windows.Forms.LinkLabel();
            this.lblPatient = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gpGuardianInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblMode.Location = new System.Drawing.Point(301, 19);
            this.lblMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(253, 41);
            this.lblMode.TabIndex = 34;
            this.lblMode.Text = "Patient Details";
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.Location = new System.Drawing.Point(8, 125);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(846, 242);
            this.ctrlPersonCard1.TabIndex = 35;
            // 
            // gpGuardianInfo
            // 
            this.gpGuardianInfo.Controls.Add(this.lblRelationship);
            this.gpGuardianInfo.Controls.Add(this.label6);
            this.gpGuardianInfo.Controls.Add(this.lblPhone);
            this.gpGuardianInfo.Controls.Add(this.label3);
            this.gpGuardianInfo.Controls.Add(this.lblNationalNo);
            this.gpGuardianInfo.Controls.Add(this.lblGuardianID);
            this.gpGuardianInfo.Controls.Add(this.label5);
            this.gpGuardianInfo.Controls.Add(this.label1);
            this.gpGuardianInfo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpGuardianInfo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.gpGuardianInfo.Location = new System.Drawing.Point(12, 383);
            this.gpGuardianInfo.Name = "gpGuardianInfo";
            this.gpGuardianInfo.Size = new System.Drawing.Size(835, 130);
            this.gpGuardianInfo.TabIndex = 36;
            this.gpGuardianInfo.TabStop = false;
            this.gpGuardianInfo.Text = "Guardian Informations";
            // 
            // lblNationalNo
            // 
            this.lblNationalNo.AutoSize = true;
            this.lblNationalNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(85)))));
            this.lblNationalNo.Location = new System.Drawing.Point(442, 37);
            this.lblNationalNo.Name = "lblNationalNo";
            this.lblNationalNo.Size = new System.Drawing.Size(50, 18);
            this.lblNationalNo.TabIndex = 15;
            this.lblNationalNo.Text = "[????]";
            // 
            // lblGuardianID
            // 
            this.lblGuardianID.AutoSize = true;
            this.lblGuardianID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(85)))));
            this.lblGuardianID.Location = new System.Drawing.Point(148, 37);
            this.lblGuardianID.Name = "lblGuardianID";
            this.lblGuardianID.Size = new System.Drawing.Size(50, 18);
            this.lblGuardianID.TabIndex = 10;
            this.lblGuardianID.Text = "[????]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(341, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "NationalNo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Guardian ID:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(85)))));
            this.lblPhone.Location = new System.Drawing.Point(148, 79);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(50, 18);
            this.lblPhone.TabIndex = 17;
            this.lblPhone.Text = "[????]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "Phone:";
            // 
            // lblRelationship
            // 
            this.lblRelationship.AutoSize = true;
            this.lblRelationship.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(85)))));
            this.lblRelationship.Location = new System.Drawing.Point(442, 79);
            this.lblRelationship.Name = "lblRelationship";
            this.lblRelationship.Size = new System.Drawing.Size(50, 18);
            this.lblRelationship.TabIndex = 19;
            this.lblRelationship.Text = "[????]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(335, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 18);
            this.label6.TabIndex = 18;
            this.label6.Text = "Relationship:";
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(731, 528);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 38);
            this.btnClose.TabIndex = 52;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // llEditPatient
            // 
            this.llEditPatient.AutoSize = true;
            this.llEditPatient.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llEditPatient.Location = new System.Drawing.Point(746, 101);
            this.llEditPatient.Name = "llEditPatient";
            this.llEditPatient.Size = new System.Drawing.Size(101, 21);
            this.llEditPatient.TabIndex = 53;
            this.llEditPatient.TabStop = true;
            this.llEditPatient.Text = "Edit Patient";
            this.llEditPatient.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llEditPatient_LinkClicked);
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(85)))));
            this.lblPatient.Location = new System.Drawing.Point(139, 87);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(50, 18);
            this.lblPatient.TabIndex = 55;
            this.lblPatient.Text = "[????]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label4.Location = new System.Drawing.Point(53, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 54;
            this.label4.Text = "Patient ID:";
            // 
            // frmPatientDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(866, 583);
            this.Controls.Add(this.lblPatient);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.llEditPatient);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gpGuardianInfo);
            this.Controls.Add(this.ctrlPersonCard1);
            this.Controls.Add(this.lblMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPatientDetails";
            this.Text = "Patient Details";
            this.Load += new System.EventHandler(this.frmPatientDetails_Load);
            this.gpGuardianInfo.ResumeLayout(false);
            this.gpGuardianInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMode;
        private Persons.ctrlPersonCard ctrlPersonCard1;
        private System.Windows.Forms.GroupBox gpGuardianInfo;
        private System.Windows.Forms.Label lblNationalNo;
        private System.Windows.Forms.Label lblGuardianID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRelationship;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel llEditPatient;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Label label4;
    }
}