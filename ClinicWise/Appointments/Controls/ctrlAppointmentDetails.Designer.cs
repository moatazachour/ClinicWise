namespace ClinicWise.Appointments.Controls
{
    partial class ctrlAppointmentDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbAppointmentInformations = new System.Windows.Forms.GroupBox();
            this.btnPatient = new System.Windows.Forms.Button();
            this.btnDoctorDetails = new System.Windows.Forms.Button();
            this.lblScheduledBy = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblPatient = new System.Windows.Forms.Label();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.lblAppointmentID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbAppointmentInformations.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAppointmentInformations
            // 
            this.gbAppointmentInformations.Controls.Add(this.btnPatient);
            this.gbAppointmentInformations.Controls.Add(this.btnDoctorDetails);
            this.gbAppointmentInformations.Controls.Add(this.lblScheduledBy);
            this.gbAppointmentInformations.Controls.Add(this.label6);
            this.gbAppointmentInformations.Controls.Add(this.lblStatus);
            this.gbAppointmentInformations.Controls.Add(this.lblDate);
            this.gbAppointmentInformations.Controls.Add(this.lblPatient);
            this.gbAppointmentInformations.Controls.Add(this.lblDoctor);
            this.gbAppointmentInformations.Controls.Add(this.lblAppointmentID);
            this.gbAppointmentInformations.Controls.Add(this.label7);
            this.gbAppointmentInformations.Controls.Add(this.label4);
            this.gbAppointmentInformations.Controls.Add(this.label3);
            this.gbAppointmentInformations.Controls.Add(this.label2);
            this.gbAppointmentInformations.Controls.Add(this.label1);
            this.gbAppointmentInformations.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAppointmentInformations.ForeColor = System.Drawing.Color.DodgerBlue;
            this.gbAppointmentInformations.Location = new System.Drawing.Point(0, 0);
            this.gbAppointmentInformations.Margin = new System.Windows.Forms.Padding(4);
            this.gbAppointmentInformations.Name = "gbAppointmentInformations";
            this.gbAppointmentInformations.Padding = new System.Windows.Forms.Padding(4);
            this.gbAppointmentInformations.Size = new System.Drawing.Size(771, 298);
            this.gbAppointmentInformations.TabIndex = 1;
            this.gbAppointmentInformations.TabStop = false;
            this.gbAppointmentInformations.Text = "Appointment Informations";
            // 
            // btnPatient
            // 
            this.btnPatient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPatient.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatient.ForeColor = System.Drawing.Color.Black;
            this.btnPatient.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPatient.Location = new System.Drawing.Point(622, 120);
            this.btnPatient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPatient.Name = "btnPatient";
            this.btnPatient.Size = new System.Drawing.Size(86, 34);
            this.btnPatient.TabIndex = 18;
            this.btnPatient.Text = "Details";
            this.btnPatient.UseVisualStyleBackColor = true;
            this.btnPatient.Click += new System.EventHandler(this.btnPatient_Click);
            // 
            // btnDoctorDetails
            // 
            this.btnDoctorDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDoctorDetails.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoctorDetails.ForeColor = System.Drawing.Color.Black;
            this.btnDoctorDetails.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDoctorDetails.Location = new System.Drawing.Point(622, 80);
            this.btnDoctorDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDoctorDetails.Name = "btnDoctorDetails";
            this.btnDoctorDetails.Size = new System.Drawing.Size(86, 34);
            this.btnDoctorDetails.TabIndex = 17;
            this.btnDoctorDetails.Text = "Details";
            this.btnDoctorDetails.UseVisualStyleBackColor = true;
            this.btnDoctorDetails.Click += new System.EventHandler(this.btnDoctorDetails_Click);
            // 
            // lblScheduledBy
            // 
            this.lblScheduledBy.AutoSize = true;
            this.lblScheduledBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(85)))));
            this.lblScheduledBy.Location = new System.Drawing.Point(222, 245);
            this.lblScheduledBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScheduledBy.Name = "lblScheduledBy";
            this.lblScheduledBy.Size = new System.Drawing.Size(66, 23);
            this.lblScheduledBy.TabIndex = 16;
            this.lblScheduledBy.Text = "[????]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 245);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 23);
            this.label6.TabIndex = 15;
            this.label6.Text = "Scheduled By:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(85)))));
            this.lblStatus.Location = new System.Drawing.Point(222, 205);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(66, 23);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "[????]";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(85)))));
            this.lblDate.Location = new System.Drawing.Point(222, 165);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(66, 23);
            this.lblDate.TabIndex = 13;
            this.lblDate.Text = "[????]";
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(85)))));
            this.lblPatient.Location = new System.Drawing.Point(222, 125);
            this.lblPatient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(66, 23);
            this.lblPatient.TabIndex = 12;
            this.lblPatient.Text = "[????]";
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(85)))));
            this.lblDoctor.Location = new System.Drawing.Point(222, 85);
            this.lblDoctor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(66, 23);
            this.lblDoctor.TabIndex = 11;
            this.lblDoctor.Text = "[????]";
            // 
            // lblAppointmentID
            // 
            this.lblAppointmentID.AutoSize = true;
            this.lblAppointmentID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(85)))));
            this.lblAppointmentID.Location = new System.Drawing.Point(222, 45);
            this.lblAppointmentID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAppointmentID.Name = "lblAppointmentID";
            this.lblAppointmentID.Size = new System.Drawing.Size(66, 23);
            this.lblAppointmentID.TabIndex = 10;
            this.lblAppointmentID.Text = "[????]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(136, 205);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "Status:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(146, 165);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Doctor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 125);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Patient:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Appointment ID:";
            // 
            // ctrlAppointmentDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbAppointmentInformations);
            this.Name = "ctrlAppointmentDetails";
            this.Size = new System.Drawing.Size(777, 307);
            this.gbAppointmentInformations.ResumeLayout(false);
            this.gbAppointmentInformations.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAppointmentInformations;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.Label lblAppointmentID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblScheduledBy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPatient;
        private System.Windows.Forms.Button btnDoctorDetails;
    }
}
