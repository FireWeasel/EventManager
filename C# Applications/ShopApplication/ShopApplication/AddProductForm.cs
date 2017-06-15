using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApplication
{
    public partial class AddProductForm : Form
    {
        private List<ProductType> typesList;
        private RestClient rClient;
        private ShopForm sForm;
        private Shop shop;
        private Product p;
        private int countdown;
        public AddProductForm(RestClient rClient, ShopForm sForm, Shop shop)
        {
            InitializeComponent();
            this.sForm = sForm;
            this.rClient = rClient;
            this.shop = shop;
            #region Putting enums in a list and into the combobox.
            typesList = Enum.GetValues(typeof(ProductType)).Cast<ProductType>().ToList();
            foreach (ProductType pt in typesList)
            {
                cbType.Items.Add(pt);
            }
            #endregion
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbNewProdName.Text == "" || rtbNewDescription.Text == "" || nudNewQuantity.Value == 0 || nudNewPrice.Value == 0)
                {
                    throw new Exception("Error! Enter valid information in the fields.");
                }
                string type = typesList[cbType.SelectedIndex].ToString();

                p = new Product(tbNewProdName.Text, rtbNewDescription.Text, Convert.ToDouble(nudNewPrice.Value),
                    Convert.ToInt32(nudNewQuantity.Value), type);

                if (rClient.AddProduct(p,shop))
                {
                    if (p.Type == sForm.selectedType )
                    {
                        sForm.LoadProductsByType(shop.Products, p.Type);
                    }
                    this.Close();
                }
                else
                {
                    this.lblErrorMessage.Text = "Error! Could not add this product.";
                    errorTimer.Start();
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
                errorTimer.Start();
            }
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
