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
        public UpdateItemForm(RestClient rClient, Product product)
        {
            InitializeComponent();
            lbUpdateType.Items.Add("FOODS");
            lbUpdateType.Items.Add("DRINKS");
            lbUpdateType.Items.Add("OTHERS");
            UpdateInfo(product);
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {

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
                case "OTHERS": lbUpdateType.SelectedItem = lbUpdateType.Items[2];
                    break;
                default:
                    break;
            }
            

        }
    }
}
