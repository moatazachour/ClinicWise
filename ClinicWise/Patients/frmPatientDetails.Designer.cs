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
            this.gbGuardianInfo = new System.Windows.Forms.GroupBox();
            this.lblRelationship = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNationalNo = new System.Windows.Forms.Label();
            this.lblGuardianID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.llEditPatient = new System.Windows.Forms.LinkLabel();
            this.lblPatient = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbGuardianInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblMode.Location = new System.Drawing.Point(401, 23);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(321, 51);
            this.lblMode.TabIndex = 34;
            this.lblMode.Text = "Patient Details";
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.Location = new System.Drawing.Point(11, 154);
            this.ctrlPersonCard1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(1128, 298);
            this.ctrlPersonCard1.TabIndex = 35;
            // 
            // gbGuardianInfo
            // 
            this.gbGuardianInfo.Controls.Add(this.lblRelationship);
            this.gbGuardianInfo.Controls.Add(this.label6);
            this.gbGuardianInfo.Controls.Add(this.lblPhone);
            this.gbGuardianInfo.Controls.Add(this.label3);
            this.gbGuardianInfo.Controls.Add(this.lblNationalNo);
            this.gbGuardianInfo.Controls.Add(this.lblGuardianID);
            this.gbGuardianInfo.Controls.Add(this.label5);
            this.gbGuardianInfo.Controls.Add(this.label1);
            this.gbGuardianInfo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbGuardianInfo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.gbGuardianInfo.Location = new System.Drawing.Point(16, 471);
            this.gbGuardianInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbGuardianInfo.Name = "gbGuardianInfo";
            this.gbGuardianInfo.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbGuardianInfo.Size = new System.Drawing.Size(1113, 160);
            this.gbGuardianInfo.TabIndex = 36;
            this.gbGuardianInfo.TabStop = false;
            this.gbGuardianInfo.Text = "Guardian Informations";
            // 
            // lblRelationship
            // 
            this.lblRelationship.AutoSize = true;
            this.lblRelationship.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(85)))));
            this.lblRelationship.Location = new System.Drawing.Point(589, 97);
            this.lblRelationship.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRelationship.Name = "lblRelationship";
            this.lblRelationship.Size = new System.Drawing.Size(66, 23);
            this.lblRelationship.TabIndex = 19;
            this.lblRelationship.Text = "[????]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(447, 97);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 23);
            this.label6.TabIndex = 18;
            this.label6.Text = "Relationship:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(85)))));
            this.lblPhone.Location = new System.Drawing.Point(197, 97);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(66, 23);
            this.lblPhone.TabIndex = 17;
            this.lblPhone.Text = "[????]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 97);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 16;
            this.label3.Text = "Phone:";
            // 
            // lblNationalNo
            // 
            this.lblNationalNo.AutoSize = true;
            this.lblNationalNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(85)))));
            this.lblNationalNo.Location = new System.Drawing.Point(589, 46);
            this.lblNationalNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNationalNo.Name = "lblNationalNo";
            this.lblNationalNo.Size = new System.Drawing.Size(66, 23);
            this.lblNationalNo.TabIndex = 15;
            this.lblNationalNo.Text = "[????]";
            // 
            // lblGuardianID
            // 
            this.lblGuardianID.AutoSize = true;
            this.lblGuardianID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(85)))));
            this.lblGuardianID.Location = new System.Drawing.Point(197, 46);
            this.lblGuardianID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGuardianID.Name = "lblGuardianID";
            this.lblGuardianID.Size = new System.Drawing.Size(66, 23);
            this.lblGuardianID.TabIndex = 10;
            this.lblGuardianID.Text = "[????]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(455, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "NationalNo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Guardian ID:";
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(975, 650);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(155, 47);
            this.btnClose.TabIndex = 52;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // llEditPatient
            // 
            this.llEditPatient.AutoSize = true;
            this.llEditPatient.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llEditPatient.Location = new System.Drawing.Point(995, 124);
            this.llEditPatient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llEditPatient.Name = "llEditPatient";
            this.llEditPatient.Size = new System.Drawing.Size(119, 23);
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
            this.lblPatient.Location = new System.Drawing.Point(185, 107);
            this.lblPatient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(66, 23);
            this.lblPatient.TabIndex = 55;
            this.lblPatient.Text = "[????]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label4.Location = new System.Drawing.Point(71, 107);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 23);
            this.label4.TabIndex = 54;
            this.label4.Text = "Patient ID:";
            // 
            // frmPatientDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1155, 718);
            this.Controls.Add(this.lblPatient);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.llEditPatient);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbGuardianInfo);
            this.Controls.Add(this.ctrlPersonCard1);
            this.Controls.Add(this.lblMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmPatientDetails";
            this.Text = "Patient Details";
            this.Load += new System.EventHandler(this.frmPatientDetails_Load);
            this.gbGuardianInfo.ResumeLayout(false);
            this.gbGuardianInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMode;
        private Persons.ctrlPersonCard ctrlPersonCard1;
        private System.Windows.Forms.GroupBox gbGuardianInfo;
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