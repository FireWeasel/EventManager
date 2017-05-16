namespace Rent_Items_Test
{
    partial class AddProduct
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
            this.quantNUD = new System.Windows.Forms.NumericUpDown();
            this.feeNUD = new System.Windows.Forms.NumericUpDown();
            this.AddItemBtn = new System.Windows.Forms.Button();
            this.typeCb = new System.Windows.Forms.ComboBox();
            this.nameTb = new System.Windows.Forms.TextBox();
            this.descTb = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.groupBox1.Controls.Add(this.quantNUD);
            this.groupBox1.Controls.Add(this.feeNUD);
            this.groupBox1.Controls.Add(this.AddItemBtn);
            this.groupBox1.Controls.Add(this.typeCb);
            this.groupBox1.Controls.Add(this.nameTb);
            this.groupBox1.Controls.Add(this.descTb);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 459);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add product:";
            // 
            // quantNUD
            // 
            this.quantNUD.Location = new System.Drawing.Point(345, 311);
            this.quantNUD.Name = "quantNUD";
            this.quantNUD.Size = new System.Drawing.Size(121, 22);
            this.quantNUD.TabIndex = 13;
            // 
            // feeNUD
            // 
            this.feeNUD.Location = new System.Drawing.Point(109, 311);
            this.feeNUD.Name = "feeNUD";
            this.feeNUD.Size = new System.Drawing.Size(121, 22);
            this.feeNUD.TabIndex = 12;
            // 
            // AddItemBtn
            // 
            this.AddItemBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddItemBtn.Location = new System.Drawing.Point(267, 374);
            this.AddItemBtn.Name = "AddItemBtn";
            this.AddItemBtn.Size = new System.Drawing.Size(199, 46);
            this.AddItemBtn.TabIndex = 11;
            this.AddItemBtn.Text = "Add item";
            this.AddItemBtn.UseVisualStyleBackColor = true;
            this.AddItemBtn.Click += new System.EventHandler(this.AddItemBtn_Click);
            // 
            // typeCb
            // 
            this.typeCb.FormattingEnabled = true;
            this.typeCb.Location = new System.Drawing.Point(109, 385);
            this.typeCb.Name = "typeCb";
            this.typeCb.Size = new System.Drawing.Size(121, 24);
            this.typeCb.TabIndex = 10;
            // 
            // nameTb
            // 
            this.nameTb.Location = new System.Drawing.Point(154, 61);
            this.nameTb.Name = "nameTb";
            this.nameTb.Size = new System.Drawing.Size(301, 22);
            this.nameTb.TabIndex = 7;
            // 
            // descTb
            // 
            this.descTb.Location = new System.Drawing.Point(154, 128);
            this.descTb.Name = "descTb";
            this.descTb.Size = new System.Drawing.Size(301, 142);
            this.descTb.TabIndex = 6;
            this.descTb.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(38, 388);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(263, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Quantity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(38, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fee:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(37, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(37, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 480);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddProduct";
            this.Text = "Add product";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.feeNUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox typeCb;
        private System.Windows.Forms.TextBox nameTb;
        private System.Windows.Forms.RichTextBox descTb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddItemBtn;
        private System.Windows.Forms.NumericUpDown quantNUD;
        private System.Windows.Forms.NumericUpDown feeNUD;
    }
}