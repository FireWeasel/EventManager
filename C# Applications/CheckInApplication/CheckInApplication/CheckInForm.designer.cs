namespace CheckInApplication
{
    partial class CheckInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckInForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblReservationNotPayed = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblPaidReservation = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbUserInformation = new System.Windows.Forms.ListBox();
            this.btnCheckInTicket = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblReservationNotPayed);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.lblPaidReservation);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(26, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(581, 219);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // lblReservationNotPayed
            // 
            this.lblReservationNotPayed.AutoSize = true;
            this.lblReservationNotPayed.Location = new System.Drawing.Point(352, 188);
            this.lblReservationNotPayed.Name = "lblReservationNotPayed";
            this.lblReservationNotPayed.Size = new System.Drawing.Size(160, 18);
            this.lblReservationNotPayed.TabIndex = 3;
            this.lblReservationNotPayed.Text = "Check in unsuccessful!";
            this.lblReservationNotPayed.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(340, 23);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(175, 162);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // lblPaidReservation
            // 
            this.lblPaidReservation.AutoSize = true;
            this.lblPaidReservation.Location = new System.Drawing.Point(47, 188);
            this.lblPaidReservation.Name = "lblPaidReservation";
            this.lblPaidReservation.Size = new System.Drawing.Size(144, 18);
            this.lblPaidReservation.TabIndex = 1;
            this.lblPaidReservation.Text = "Check in successful!";
            this.lblPaidReservation.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(38, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbUserInformation);
            this.groupBox3.Location = new System.Drawing.Point(624, 23);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(251, 305);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Client information: ";
            // 
            // lbUserInformation
            // 
            this.lbUserInformation.FormattingEnabled = true;
            this.lbUserInformation.ItemHeight = 18;
            this.lbUserInformation.Location = new System.Drawing.Point(13, 35);
            this.lbUserInformation.Name = "lbUserInformation";
            this.lbUserInformation.Size = new System.Drawing.Size(227, 256);
            this.lbUserInformation.TabIndex = 0;
            // 
            // btnCheckInTicket
            // 
            this.btnCheckInTicket.Location = new System.Drawing.Point(7, 20);
            this.btnCheckInTicket.Name = "btnCheckInTicket";
            this.btnCheckInTicket.Size = new System.Drawing.Size(562, 47);
            this.btnCheckInTicket.TabIndex = 2;
            this.btnCheckInTicket.Text = "Click to scan QR code";
            this.btnCheckInTicket.UseVisualStyleBackColor = true;
            this.btnCheckInTicket.Click += new System.EventHandler(this.btnCheckReservation_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCheckInTicket);
            this.groupBox1.Location = new System.Drawing.Point(22, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(585, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // CampingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(889, 349);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CampingForm";
            this.Text = "Check in application";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CampingForm_FormClosed);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblReservationNotPayed;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblPaidReservation;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lbUserInformation;
        private System.Windows.Forms.Button btnCheckInTicket;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

