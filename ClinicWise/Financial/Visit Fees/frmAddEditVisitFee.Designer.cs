namespace ClinicWise.Financial.Visit_Fees
{
    partial class frmAddEditVisitFee
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
            this.gbVisitTypeInformations = new System.Windows.Forms.GroupBox();
            this.dtpEffectiveFrom = new System.Windows.Forms.DateTimePicker();
            this.nudBaseAmount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbVisitType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblVisitTypeFeeID = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.gbVisitTypeInformations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaseAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // gbVisitTypeInformations
            // 
            this.gbVisitTypeInformations.Controls.Add(this.dtpEffectiveFrom);
            this.gbVisitTypeInformations.Controls.Add(this.nudBaseAmount);
            this.gbVisitTypeInformations.Controls.Add(this.label3);
            this.gbVisitTypeInformations.Controls.Add(this.cmbVisitType);
            this.gbVisitTypeInformations.Controls.Add(this.label1);
            this.gbVisitTypeInformations.Controls.Add(this.label6);
            this.gbVisitTypeInformations.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbVisitTypeInformations.ForeColor = System.Drawing.Color.DodgerBlue;
            this.gbVisitTypeInformations.Location = new System.Drawing.Point(16, 143);
            this.gbVisitTypeInformations.Name = "gbVisitTypeInformations";
            this.gbVisitTypeInformations.Size = new System.Drawing.Size(476, 227);
            this.gbVisitTypeInformations.TabIndex = 59;
            this.gbVisitTypeInformations.TabStop = false;
            // 
            // dtpEffectiveFrom
            // 
            this.dtpEffectiveFrom.CalendarFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEffectiveFrom.Location = new System.Drawing.Point(160, 173);
            this.dtpEffectiveFrom.Margin = new System.Windows.Forms.Padding(2);
            this.dtpEffectiveFrom.Name = "dtpEffectiveFrom";
            this.dtpEffectiveFrom.Size = new System.Drawing.Size(268, 23);
            this.dtpEffectiveFrom.TabIndex = 4;
            // 
            // nudBaseAmount
            // 
            this.nudBaseAmount.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudBaseAmount.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudBaseAmount.Location = new System.Drawing.Point(160, 101);
            this.nudBaseAmount.Margin = new System.Windows.Forms.Padding(2);
            this.nudBaseAmount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudBaseAmount.Name = "nudBaseAmount";
            this.nudBaseAmount.Size = new System.Drawing.Size(90, 26);
            this.nudBaseAmount.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(19, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 19);
            this.label3.TabIndex = 26;
            this.label3.Text = "Effective From:";
            // 
            // cmbVisitType
            // 
            this.cmbVisitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVisitType.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVisitType.FormattingEnabled = true;
            this.cmbVisitType.Items.AddRange(new object[] {
            "Consultation",
            "Follow up",
            "Emergency",
            "Routine Check",
            "Vaccination",
            "Lab Test"});
            this.cmbVisitType.Location = new System.Drawing.Point(160, 38);
            this.cmbVisitType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbVisitType.Name = "cmbVisitType";
            this.cmbVisitType.Size = new System.Drawing.Size(268, 26);
            this.cmbVisitType.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(23, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 19);
            this.label1.TabIndex = 22;
            this.label1.Text = "Base Amount:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(50, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 19);
            this.label6.TabIndex = 19;
            this.label6.Text = "Visit Type:";
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(252, 398);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 34);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(356, 398);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 34);
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 18);
            this.label2.TabIndex = 61;
            this.label2.Text = "Visit Type Fee ID:";
            // 
            // lblVisitTypeFeeID
            // 
            this.lblVisitTypeFeeID.AutoSize = true;
            this.lblVisitTypeFeeID.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVisitTypeFeeID.Location = new System.Drawing.Point(162, 115);
            this.lblVisitTypeFeeID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVisitTypeFeeID.Name = "lblVisitTypeFeeID";
            this.lblVisitTypeFeeID.Size = new System.Drawing.Size(37, 18);
            this.lblVisitTypeFeeID.TabIndex = 62;
            this.lblVisitTypeFeeID.Text = "N/A";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblMode.Location = new System.Drawing.Point(116, 22);
            this.lblMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(269, 36);
            this.lblMode.TabIndex = 60;
            this.lblMode.Text = "Add New Visit Fee";
            // 
            // frmAddEditVisitFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(524, 470);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblVisitTypeFeeID);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbVisitTypeInformations);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmAddEditVisitFee";
            this.Text = "Add Visit Fee";
            this.Load += new System.EventHandler(this.frmAddEditVisitFee_Load);
            this.gbVisitTypeInformations.ResumeLayout(false);
            this.gbVisitTypeInformations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaseAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbVisitTypeInformations;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbVisitType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpEffectiveFrom;
        private System.Windows.Forms.NumericUpDown nudBaseAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblVisitTypeFeeID;
        private System.Windows.Forms.Label lblMode;
    }
}