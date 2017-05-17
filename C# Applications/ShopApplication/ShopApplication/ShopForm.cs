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
using System.Reflection;

namespace ShopApplication
{
    public partial class ShopForm : Form
    {
        private delegate void PopulatingListBoxHandler(List<Product> list);
        private List<Product> order;

        //private List<Product> foods;
        //private List<Product> drinks;
        //private List<Product> other;

        private String selected;
        public static Shop shop;
        private RestClient rClient;
        private double price = 0;

        public ShopForm(RestClient rClient)
        {
            InitializeComponent();
            this.rClient = rClient;
            order = new List<Product>(); // adding items to order.
            shop = rClient.GetShop();
            shop.Products = rClient.GetAllProducts();
            //Populate(shop.Products);
            //MessageBox.Show(rClient.GetRequest("http://localhost:8080/users/current"));
        }

        private void ShopForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            rClient.GetRequest("http://localhost:8080/logout");
        }
        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(OpenAddProductForm);
            thread.Start();
        }
        private void OpenAddProductForm()
        {
            AddProductForm addProductForm = new AddProductForm(rClient, this);
            Application.Run(addProductForm);
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            //add an item in the order listbox and then if you add an item with the same name
            //it should just update the quantity in order.
            try
            {
                Product temp = (Product)lbItemName.SelectedItem;
                
                if (order.Contains(temp))
                {
                    this.order.Remove(temp);
                    temp.NrInOrder += (int)nudQuantity.Value;
                }
                else
                {
                    temp.NrInOrder = (int)nudQuantity.Value;
                }

                #region checking for invalid input
                if (temp.Quantity == 0)
                {
                    MessageBox.Show("Currently not in stock!");
                    return;
                }
                else if (temp.NrInOrder == 0)
                {
                    MessageBox.Show("Select a quantity first!");
                    return;
                }
                #endregion

                lbOrder.Items.Clear();
                if (temp.Quantity   <   (int)nudQuantity.Value)
                {
                    MessageBox.Show("Not enough items in stock.");
                    return;
                }
                temp.Quantity -= (int)nudQuantity.Value;

                if (this.order.Count != 0)
                {

                }
                else
                {
                    price = 0;
                }
                

                UpdateLabels(temp);
                this.order.Add(temp);
                this.lblTotalPrice.Text = CalculatePrice(order).ToString();

                foreach (Product p in order)
                {
                    lbOrder.Items.Add(p.AsString() + p.NrInOrder);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Select an item from the listbox first!");
            }
        }

        public double CalculatePrice(List<Product> list)
        {
            double price = 0;
            foreach (Product p in list)
            {
                price += p.Price * p.NrInOrder;
            }
            return price;
        }

        //shop class has revenue and id
        //product class has id,description,name,price,quantity,type and (shop_id)


        private void lbItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.nudQuantity.Value = 0;
            selected = lbItemName.SelectedItem.ToString();
            foreach (Product p in shop.Products)
            {
                if (p.ToString()==selected)
                {
                    UpdateLabels(p);
                }
            }
            
        }

        public void UpdateLabels(Product p)
        {
            this.lblDescription.Text = p.Description;
            this.lblCurrentInStock.Text = p.Quantity.ToString();
            this.nudQuantity.Maximum = p.Quantity;
            this.lblPriceSingleItem.Text = p.Price + " euros.";

        }

        public void LoadProductsByType(List<Product> list, ProductType pt)
        {
            if (list != null)
            {
                foreach (Product p in list)
                {
                    if (p.Type == pt.ToString())
                    {
                        lbItemName.Items.Add(p);     
                    }
                }
            }
        }

        private void rbFood_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFood.Checked)
            {
                lbItemName.Items.Clear();
                LoadProductsByType(shop.Products, ProductType.FOODS);
            }
        }

        private void rbDrinks_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDrinks.Checked)
            {
                lbItemName.Items.Clear();
                LoadProductsByType(shop.Products, ProductType.DRINKS);
            }
        }

        private void rbOthers_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOthers.Checked)
            {
                lbItemName.Items.Clear();
                LoadProductsByType(shop.Products, ProductType.OTHER);
            }
        }
    }
}
