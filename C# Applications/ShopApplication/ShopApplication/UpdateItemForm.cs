using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApplication
{
    public partial class UpdateItemForm : Form
    {
        private RestClient rClient;
        private Product productToUpdate;
        private ShopForm sForm;
        private Shop shop;
        private int countdown;

        public UpdateItemForm(RestClient rClient, Product product, ShopForm sForm, Shop shop)
        {
            InitializeComponent();

            this.rClient = rClient;
            this.productToUpdate = product;
            this.sForm = sForm;
            this.shop = shop;

            lbUpdateType.Items.Add("FOODS");
            lbUpdateType.Items.Add("DRINKS");
            lbUpdateType.Items.Add("OTHER");
            UpdateInfo(product);
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (rClient.UpdateProduct(GetUpdatedProduct(), shop)) 
            {
                if (sForm.selectedType == this.productToUpdate.Type)
                {
                    sForm.UpdateLabels(productToUpdate);
                }
                sForm.ClearLabels();
                sForm.LoadProductsByType(shop.Products, sForm.selectedType);
                MessageBox.Show("Update successful!");
                this.Close();
            }
            else
            {
                this.lblErrorMessage.Text = "Update unsuccessful!";
                errorTimer.Start();
            }
        }

        private void UpdateInfo(Product p)
        {
            if (tbUpdateName.Text != "" || nudUpdatePrice.Value < 0 || nudUpdateQuantity.Value < 0 || richTextBox1.Text != "" || lbUpdateType.SelectedIndex < 0)
            {
                tbUpdateName.Text = p.Name;
                nudUpdatePrice.Value = (decimal)p.Price;
                nudUpdateQuantity.Value = (decimal)p.Quantity;
                richTextBox1.Text = p.Description;
                switch (p.Type)
                {
                    case "FOODS":
                        lbUpdateType.SelectedItem = lbUpdateType.Items[0];
                        break;
                    case "DRINKS":
                        lbUpdateType.SelectedItem = lbUpdateType.Items[1];
                        break;
                    case "OTHER":
                        lbUpdateType.SelectedItem = lbUpdateType.Items[2];
                        break;
                }
            }
            else
            {
                lblErrorMessage.Text = "Make sure to fill in with correct information.";
                errorTimer.Start();
            }
        }

        private Product GetUpdatedProduct()
        {
            this.productToUpdate.Name = tbUpdateName.Text;
            this.productToUpdate.Description = richTextBox1.Text;
            this.productToUpdate.Price = (double)nudUpdatePrice.Value;
            this.productToUpdate.Quantity = (int)nudUpdateQuantity.Value ;
            this.productToUpdate.Type = lbUpdateType.SelectedItem.ToString();
            return productToUpdate;
        }

        private void errorTimer_Tick(object sender, EventArgs e)
        {
            countdown--;
            if (countdown == 0)
            {
                errorTimer.Stop();
                lblErrorMessage.Text = "";
            }
        }

        private void lblErrorMessage_TextChanged(object sender, EventArgs e)
        {
            countdown = 5;
        }
    }
}
