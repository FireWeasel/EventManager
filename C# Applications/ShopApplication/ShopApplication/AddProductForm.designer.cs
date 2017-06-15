namespace ShopApplication
{
    partial class AddProductForm
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.nudNewQuantity = new System.Windows.Forms.NumericUpDown();
            this.nudNewPrice = new System.Windows.Forms.NumericUpDown();
            this.rtbNewDescription = new System.Windows.Forms.RichTextBox();
            this.tbNewProdName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.errorTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewPrice)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.CadetBlue;
            this.groupBox1.Controls.Add(this.btnAddProduct);
            this.groupBox1.Controls.Add(this.cbType);
            this.groupBox1.Controls.Add(this.nudNewQuantity);
            this.groupBox1.Controls.Add(this.nudNewPrice);
            this.groupBox1.Controls.Add(this.rtbNewDescription);
            this.groupBox1.Controls.Add(this.tbNewProdName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(889, 357);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add product:";
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(370, 186);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(488, 142);
            this.btnAddProduct.TabIndex = 10;
            this.btnAddProduct.Text = "Add product";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(109, 290);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(136, 26);
            this.cbType.TabIndex = 9;
            // 
            // nudNewQuantity
            // 
            this.nudNewQuantity.Location = new System.Drawing.Point(109, 234);
            this.nudNewQuantity.Name = "nudNewQuantity";
            this.nudNewQuantity.Size = new System.Drawing.Size(135, 24);
            this.nudNewQuantity.TabIndex = 8;
            // 
            // nudNewPrice
            // 
            this.nudNewPrice.Location = new System.Drawing.Point(109, 183);
            this.nudNewPrice.Name = "nudNewPrice";
            this.nudNewPrice.Size = new System.Drawing.Size(135, 24);
            this.nudNewPrice.TabIndex = 7;
            // 
            // rtbNewDescription
            // 
            this.rtbNewDescription.Location = new System.Drawing.Point(501, 25);
            this.rtbNewDescription.Name = "rtbNewDescription";
            this.rtbNewDescription.Size = new System.Drawing.Size(281, 112);
            this.rtbNewDescription.TabIndex = 6;
            this.rtbNewDescription.Text = "";
            // 
            // tbNewProdName
            // 
            this.tbNewProdName.Location = new System.Drawing.Point(109, 76);
            this.tbNewProdName.Name = "tbNewProdName";
            this.tbNewProdName.Size = new System.Drawing.Size(260, 24);
            this.tbNewProdName.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Quantity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Price:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMessage.Location = new System.Drawing.Point(14, 20);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(0, 25);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.TextChanged += new System.EventHandler(this.lblErrorMessage_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.DarkRed;
            this.groupBox2.Controls.Add(this.lblErrorMessage);
            this.groupBox2.Location = new System.Drawing.Point(15, 379);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(889, 70);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // errorTimer
            // 
            this.errorTimer.Interval = 1000;
            this.errorTimer.Tick += new System.EventHandler(this.errorTimer_Tick);
            // 
            // AddProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(922, 453);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddProductForm";
            this.Text = "Add product";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewPrice)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.NumericUpDown nudNewQuantity;
        private System.Windows.Forms.NumericUpDown nudNewPrice;
        private System.Windows.Forms.RichTextBox rtbNewDescription;
        private System.Windows.Forms.TextBox tbNewProdName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.Timer errorTimer;
    }
}

