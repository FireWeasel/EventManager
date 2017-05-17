using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ShopApplication
{
    public partial class ShopForm : Form
    {
        private List<Product> order;
        private int selectedIndex;
        public static Shop shop;
        public ShopForm()
        {
            InitializeComponent();
            order = new List<Product>();
            shop = LogInForm.rClient.GetShop();
            shop.Products = new List<Product>();

            //MessageBox.Show(LogInForm.rClient.GetRequest("http://localhost:8080/users/current"));

            List<Product> list = LogInForm.rClient.GetAllProducts();
            if (list!=null)
            {
                foreach (Product p in list)
                {
                    shop.Products.Add(p);
                    lbItemName.Items.Add(p);
                }
            }  
        }

        private void ShopForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogInForm.rClient.GetRequest("http://localhost:8080/logout");
        }
        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(OpenAddProductForm);
            thread.Start();            
        }
        private void OpenAddProductForm()
        {
            Application.Run(new AddProductForm());
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            lbOrder.Items.Add(((Product)lbItemName.SelectedItem));
        }

        private void lbItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = lbItemName.SelectedIndex;
            this.lblDescription.Text = shop.Products[selectedIndex].Description;
        }

        //shop class has revenue and id
        //product class has id,description,name,price,quantity,type and (shop_id)

    }
}
