namespace ShopApplication
{
    partial class UpdateItemForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.tbUpdateName = new System.Windows.Forms.TextBox();
            this.nudUpdatePrice = new System.Windows.Forms.NumericUpDown();
            this.nudUpdateQuantity = new System.Windows.Forms.NumericUpDown();
            this.lbUpdateType = new System.Windows.Forms.ListBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpdatePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpdateQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Salmon;
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.lbUpdateType);
            this.groupBox1.Controls.Add(this.nudUpdateQuantity);
            this.groupBox1.Controls.Add(this.nudUpdatePrice);
            this.groupBox1.Controls.Add(this.tbUpdateName);
            this.groupBox1.Controls.Add(this.btnUpdateProduct);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(801, 382);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update product:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Price:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quantity:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(366, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Description:";
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.Location = new System.Drawing.Point(351, 205);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(425, 115);
            this.btnUpdateProduct.TabIndex = 5;
            this.btnUpdateProduct.Text = "Update product";
            this.btnUpdateProduct.UseVisualStyleBackColor = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // tbUpdateName
            // 
            this.tbUpdateName.Location = new System.Drawing.Point(98, 41);
            this.tbUpdateName.Name = "tbUpdateName";
            this.tbUpdateName.Size = new System.Drawing.Size(191, 24);
            this.tbUpdateName.TabIndex = 6;
            // 
            // nudUpdatePrice
            // 
            this.nudUpdatePrice.Location = new System.Drawing.Point(98, 98);
            this.nudUpdatePrice.Name = "nudUpdatePrice";
            this.nudUpdatePrice.Size = new System.Drawing.Size(120, 24);
            this.nudUpdatePrice.TabIndex = 7;
            // 
            // nudUpdateQuantity
            // 
            this.nudUpdateQuantity.Location = new System.Drawing.Point(98, 179);
            this.nudUpdateQuantity.Name = "nudUpdateQuantity";
            this.nudUpdateQuantity.Size = new System.Drawing.Size(120, 24);
            this.nudUpdateQuantity.TabIndex = 8;
            // 
            // lbUpdateType
            // 
            this.lbUpdateType.FormattingEnabled = true;
            this.lbUpdateType.ItemHeight = 18;
            this.lbUpdateType.Location = new System.Drawing.Point(82, 244);
            this.lbUpdateType.Name = "lbUpdateType";
            this.lbUpdateType.Size = new System.Drawing.Size(183, 76);
            this.lbUpdateType.TabIndex = 9;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(478, 38);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(242, 116);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // UpdateItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 408);
            this.Controls.Add(this.groupBox1);
            this.Name = "UpdateItemForm";
            this.Text = "UpdateItemForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpdatePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpdateQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ListBox lbUpdateType;
        private System.Windows.Forms.NumericUpDown nudUpdateQuantity;
        private System.Windows.Forms.NumericUpDown nudUpdatePrice;
        private System.Windows.Forms.TextBox tbUpdateName;
        private System.Windows.Forms.Button btnUpdateProduct;
    }
}