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
        RestClient rClient;
        Product productToUpdate;
        ShopForm sForm;
        public UpdateItemForm(RestClient rClient, Product product, ShopForm sForm)
        {
            InitializeComponent();

            this.rClient = rClient;
            this.productToUpdate = product;
            this.sForm = sForm;

            lbUpdateType.Items.Add("FOODS");
            lbUpdateType.Items.Add("DRINKS");
            lbUpdateType.Items.Add("OTHER");
            UpdateInfo(product);
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (rClient.UpdateProduct(GetUpdatedProduct(), GetUpdatedProduct().Id))
            {
                if (sForm.selectedType == this.productToUpdate.Type)
                {
                    sForm.UpdateLabels(productToUpdate);
                }
                sForm.ClearLabels();
                sForm.LoadProductsByType(ShopForm.shop.Products, sForm.selectedType);
                MessageBox.Show("Update successful!");
                
            }
            this.Close();
        }

        private void UpdateInfo(Product p)
        {
            tbUpdateName.Text = p.Name;
            nudUpdatePrice.Value = (decimal)p.Price;
            nudUpdateQuantity.Value = (decimal)p.Quantity;
            richTextBox1.Text = p.Description;
            switch (p.Type)
            {
                case "FOODS": lbUpdateType.SelectedItem = lbUpdateType.Items[0];
                    break;
                case "DRINKS": lbUpdateType.SelectedItem = lbUpdateType.Items[1];
                    break;
                case "OTHER": lbUpdateType.SelectedItem = lbUpdateType.Items[2];
                    break;
                default:
                    break;
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
    }
}
