namespace Rent_Items_Test
{
    partial class UpdateItem
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IdNameCb = new System.Windows.Forms.ComboBox();
            this.NameTb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.quantNUD = new System.Windows.Forms.NumericUpDown();
            this.feeNUD = new System.Windows.Forms.NumericUpDown();
            this.AddItemBtn = new System.Windows.Forms.Button();
            this.descTb = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.feeNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox1.Controls.Add(this.IdNameCb);
            this.groupBox1.Controls.Add(this.NameTb);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.quantNUD);
            this.groupBox1.Controls.Add(this.feeNUD);
            this.groupBox1.Controls.Add(this.AddItemBtn);
            this.groupBox1.Controls.Add(this.descTb);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(481, 507);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update product:";
            // 
            // IdNameCb
            // 
            this.IdNameCb.FormattingEnabled = true;
            this.IdNameCb.Location = new System.Drawing.Point(162, 51);
            this.IdNameCb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IdNameCb.Name = "IdNameCb";
            this.IdNameCb.Size = new System.Drawing.Size(294, 37);
            this.IdNameCb.TabIndex = 16;
            this.IdNameCb.SelectedIndexChanged += new System.EventHandler(this.IdNameCb_SelectedIndexChanged);
            // 
            // NameTb
            // 
            this.NameTb.Location = new System.Drawing.Point(162, 104);
            this.NameTb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NameTb.Name = "NameTb";
            this.NameTb.Size = new System.Drawing.Size(294, 34);
            this.NameTb.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(28, 106);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 29);
            this.label6.TabIndex = 14;
            this.label6.Text = "Name:";
            // 
            // quantNUD
            // 
            this.quantNUD.Location = new System.Drawing.Point(140, 451);
            this.quantNUD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.quantNUD.Name = "quantNUD";
            this.quantNUD.Size = new System.Drawing.Size(135, 34);
            this.quantNUD.TabIndex = 13;
            // 
            // feeNUD
            // 
            this.feeNUD.Location = new System.Drawing.Point(140, 388);
            this.feeNUD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.feeNUD.Name = "feeNUD";
            this.feeNUD.Size = new System.Drawing.Size(135, 34);
            this.feeNUD.TabIndex = 12;
            // 
            // AddItemBtn
            // 
            this.AddItemBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddItemBtn.Location = new System.Drawing.Point(310, 423);
            this.AddItemBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddItemBtn.Name = "AddItemBtn";
            this.AddItemBtn.Size = new System.Drawing.Size(145, 55);
            this.AddItemBtn.TabIndex = 11;
            this.AddItemBtn.Text = "Update item";
            this.AddItemBtn.UseVisualStyleBackColor = true;
            this.AddItemBtn.Click += new System.EventHandler(this.AddItemBtn_Click);
            // 
            // descTb
            // 
            this.descTb.Location = new System.Drawing.Point(140, 167);
            this.descTb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.descTb.Name = "descTb";
            this.descTb.Size = new System.Drawing.Size(317, 188);
            this.descTb.TabIndex = 6;
            this.descTb.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(28, 453);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "Quantity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(28, 390);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fee:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(28, 167);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(28, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id and name:";
            // 
            // UpdateItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 530);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UpdateItem";
            this.Text = "Update product";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.feeNUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown quantNUD;
        private System.Windows.Forms.NumericUpDown feeNUD;
        private System.Windows.Forms.Button AddItemBtn;
        private System.Windows.Forms.RichTextBox descTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox NameTb;
        private System.Windows.Forms.ComboBox IdNameCb;
    }
}