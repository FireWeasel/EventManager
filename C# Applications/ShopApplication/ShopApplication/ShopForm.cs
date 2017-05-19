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

        private String selected = "";
        private int selectedIndexOrder = -1;
        public static Shop shop;
        private RestClient rClient;


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
            //it should just update the quantity.
            try
            {
                Product temp = (Product)lbItemName.SelectedItem;
                selectedIndexOrder = -1; //so that it doesn't keep the previous 
                this.nudAddNrInStock.Value = 0;
                if (temp.Quantity == 0)
                {
                    throw new NotInStockException("Currently not in stock!");
                }
                else if (order.Contains(temp))
                {
                    this.order.Remove(temp);
                    temp.NrInOrder += (int)nudQuantity.Value;
                }
                else
                {
                    if (nudQuantity.Value == 0)
                    {
                        throw new Exception("Select a quantity first!");
                    }
                    temp.NrInOrder = (int)nudQuantity.Value;
                }

                lbOrder.Items.Clear();
                temp.Quantity -= (int)nudQuantity.Value;

                UpdateLabels(temp);
                this.order.Add(temp);
                this.lblTotalPrice.Text = CalculatePrice(order).ToString();
                OrderListBoxUpdate();
            }
            catch (NotInStockException nse)
            {
                MessageBox.Show(nse.Message);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No item selected from the listbox.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnRemoveFromOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (order.Count == 0)
                {
                    throw new Exception("Order is empty.Nothing to remove.");
                }
                else if (selectedIndexOrder < 0)
                {
                    throw new Exception("Select an item from the order listbox first.");
                }
                else if (selectedIndexOrder >= 0)
                {
                    order[selectedIndexOrder].Quantity += order[selectedIndexOrder].NrInOrder; //reverting quantity
                    UpdateLabels(order[selectedIndexOrder]);

                    order.RemoveAt(selectedIndexOrder);
                    lblTotalPrice.Text = CalculatePrice(order).ToString();

                    OrderListBoxUpdate();
                    this.nudQuantity.Value = 0;

                    selected = "";
                    ClearLabels();
                    this.lbItemName.ClearSelected();
                    selectedIndexOrder = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OrderListBoxUpdate()
        {
            lbOrder.Items.Clear();
            foreach (Product p in order)
            {
                lbOrder.Items.Add(p.AsString() + p.NrInOrder);
            }
        }
        public double CalculatePrice(List<Product> order)
        {
            double price = 0;
            foreach (Product p in order)
            {
                price += p.Price * p.NrInOrder;
            }
            return price;
        }


        private void lbItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbItemName.SelectedIndex != -1) 
            {
                this.nudQuantity.Value = 0;
                MessageBox.Show(this.lbItemName.SelectedIndex.ToString());
                selected = lbItemName.SelectedItem.ToString(); 
                foreach (Product p in shop.Products)
                {
                    if (p.ToString() == selected)
                    {
                        UpdateLabels(p);
                        return;
                    }
                }
            }
            
        }
        private void lbOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndexOrder = lbOrder.SelectedIndex;
            this.nudAddNrInStock.Value = 0;
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
                this.nudQuantity.Value = 0;
                this.nudAddNrInStock.Value = 0;
                ClearLabels();
            }
        }

        private void rbDrinks_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDrinks.Checked)
            {
                lbItemName.Items.Clear();
                LoadProductsByType(shop.Products, ProductType.DRINKS);
                this.nudQuantity.Value = 0;
                this.nudAddNrInStock.Value = 0;
                ClearLabels();
            }
        }

        private void rbOthers_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOthers.Checked)
            {
                lbItemName.Items.Clear();
                LoadProductsByType(shop.Products, ProductType.OTHER);
                this.nudQuantity.Value = 0;
                this.nudAddNrInStock.Value = 0;
                ClearLabels();
            }
        }

        private void btnUpdateNrInStock_Click(object sender, EventArgs e)
        {
            try
            {
                if (selected == "")
                {
                    throw new Exception("Select an item from the listbox first.");
                }

                foreach (Product p in shop.Products)
                {
                    if (p.Name == selected)
                    {
                        if (nudAddNrInStock.Value == 0)
                        {
                            throw new Exception("Choose valid quantity.");
                        }
                        p.Quantity += (int)nudAddNrInStock.Value;
                        UpdateLabels(p);
                        break;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.nudAddNrInStock.Value = 0;
            }

        }

        private void ClearLabels()
        {
            selected = "";
            this.lblCurrentInStock.Text = "";
            this.lblDescription.Text = "";
            this.lblPriceSingleItem.Text = "";
        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            this.nudAddNrInStock.Value = 0;
        }
    }
}
