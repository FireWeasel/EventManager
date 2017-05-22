namespace Rent_Items_Test
{
    partial class MainApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainApplication));
            this.ItemCb = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.StockNUD = new System.Windows.Forms.NumericUpDown();
            this.LoanBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CategoryCb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ListItems = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StockNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemCb
            // 
            this.ItemCb.Enabled = false;
            this.ItemCb.FormattingEnabled = true;
            this.ItemCb.Location = new System.Drawing.Point(235, 125);
            this.ItemCb.Name = "ItemCb";
            this.ItemCb.Size = new System.Drawing.Size(272, 36);
            this.ItemCb.TabIndex = 1;
            this.ItemCb.SelectedIndexChanged += new System.EventHandler(this.ItemCb_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(36, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 303);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.CadetBlue;
            this.groupBox1.Controls.Add(this.UpdateBtn);
            this.groupBox1.Controls.Add(this.AddBtn);
            this.groupBox1.Controls.Add(this.StockNUD);
            this.groupBox1.Controls.Add(this.LoanBtn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CategoryCb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ItemCb);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(981, 276);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Items in stock";
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdateBtn.Location = new System.Drawing.Point(743, 141);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(181, 56);
            this.UpdateBtn.TabIndex = 40;
            this.UpdateBtn.Text = "Update product";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddBtn.Location = new System.Drawing.Point(743, 83);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(181, 52);
            this.AddBtn.TabIndex = 39;
            this.AddBtn.Text = "Add product";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // StockNUD
            // 
            this.StockNUD.Enabled = false;
            this.StockNUD.Location = new System.Drawing.Point(235, 179);
            this.StockNUD.Name = "StockNUD";
            this.StockNUD.Size = new System.Drawing.Size(272, 35);
            this.StockNUD.TabIndex = 38;
            // 
            // LoanBtn
            // 
            this.LoanBtn.Enabled = false;
            this.LoanBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoanBtn.Location = new System.Drawing.Point(541, 109);
            this.LoanBtn.Name = "LoanBtn";
            this.LoanBtn.Size = new System.Drawing.Size(179, 52);
            this.LoanBtn.TabIndex = 34;
            this.LoanBtn.Text = "Loan";
            this.LoanBtn.UseVisualStyleBackColor = true;
            this.LoanBtn.Click += new System.EventHandler(this.LoanBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(52, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 26);
            this.label3.TabIndex = 8;
            this.label3.Text = "Category:";
            // 
            // CategoryCb
            // 
            this.CategoryCb.FormattingEnabled = true;
            this.CategoryCb.Location = new System.Drawing.Point(235, 70);
            this.CategoryCb.Name = "CategoryCb";
            this.CategoryCb.Size = new System.Drawing.Size(272, 36);
            this.CategoryCb.TabIndex = 31;
            this.CategoryCb.SelectedIndexChanged += new System.EventHandler(this.CategoryCb_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(50, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Item name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(44, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 26);
            this.label5.TabIndex = 10;
            this.label5.Text = "Left in stock:";
            // 
            // ListItems
            // 
            this.ListItems.BackColor = System.Drawing.SystemColors.Menu;
            this.ListItems.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListItems.FormattingEnabled = true;
            this.ListItems.ItemHeight = 26;
            this.ListItems.Location = new System.Drawing.Point(36, 377);
            this.ListItems.Name = "ListItems";
            this.ListItems.Size = new System.Drawing.Size(1009, 420);
            this.ListItems.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(31, 329);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(221, 29);
            this.label13.TabIndex = 4;
            this.label13.Text = "List of all items:";
            // 
            // MainApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1088, 824);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.ListItems);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainApplication";
            this.Text = "Loan Items";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StockNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox ItemCb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox ListItems;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox CategoryCb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button LoanBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.NumericUpDown StockNUD;
        private System.Windows.Forms.Button UpdateBtn;
    }
}

