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
using ZXing;
using AForge.Video;
using AForge.Video.DirectShow;

namespace ShopApplication
{
    public partial class ShopForm : Form
    {
        private List<Product> order;

        private String selected = "";
        private int selectedIndexOrder = -1;
        private static Shop shop;
        private RestClient rClient;
        private Ticket ticket;

        public String selectedType = "FOODS";

        private IVideoSource videoSource;
        private FilterInfoCollection videoDeviceList;
        private volatile object _locker = new object();


        public ShopForm(RestClient rClient)
        {
            InitializeComponent();
            this.rClient = rClient;
            order = new List<Product>();
            shop = rClient.GetShop();
            shop.Products = rClient.GetAllProducts();
            PopulateVideoSources();
        }

        private void ShopForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            rClient.GetRequest("http://localhost:8080/logout");
        } 
        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            if (!(videoSource != null && videoSource.IsRunning))
            {
                if (order.Count == 0)
                {
                    AddProductForm apf = new AddProductForm(this.rClient, this, shop);
                    apf.Show();
                }
                else
                {
                    MessageBox.Show("Order isn't empty. Empty it before adding a new product.");
                }
            }
            else
            {
                MessageBox.Show("You are currently scanning.");
            }
                
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            try
            {
                Product temp = (Product)lbItemName.SelectedItem;
                selectedIndexOrder = -1; //so that it doesn't keep the previous 
                if (temp.Quantity == 0)
                {
                    throw new NotInStockException("Currently not in stock!");
                }
                else if (videoSource != null && videoSource.IsRunning)
                {
                   throw new Exception("You are currently scanning.");
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
                if (videoSource != null && videoSource.IsRunning)
                {
                    throw new Exception("You are currently scanning.");
                }
                else if (order.Count == 0)
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
                    UpdateNrInStock(order[selectedIndexOrder]);
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
        private void UpdateNrInStock(Product p)
        {
                p.NrInOrder = 0;
        }
        private void OrderListBoxUpdate()
        {
            lbOrder.Items.Clear();
            foreach (Product p in order)
            {
                lbOrder.Items.Add(p.AsString() + p.NrInOrder);
            }
        }
        private double CalculatePrice(List<Product> order)
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
        }

        public void UpdateLabels(Product p)
        {
            this.lblDescription.Text = p.Description;
            this.lblCurrentInStock.Text = p.Quantity.ToString();
            this.nudQuantity.Maximum = p.Quantity;
            this.lblPriceSingleItem.Text = p.Price + " euros.";
        }

        public void LoadProductsByType(List<Product> list, string type)
        {
            if (list != null)
            {
                lbItemName.Items.Clear();
                foreach (Product p in list)
                {
                    if (p.Type == type)
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
                LoadProductsByType(shop.Products, "FOODS");
                this.nudQuantity.Value = 0;
                ClearLabels();
                selectedType = "FOODS";
            }
        }

        private void rbDrinks_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDrinks.Checked)
            {
                lbItemName.Items.Clear();
                LoadProductsByType(shop.Products, "DRINKS");
                this.nudQuantity.Value = 0;
                ClearLabels();
                selectedType = "DRINKS";
            }
        }

        private void rbOthers_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOthers.Checked)
            {
                lbItemName.Items.Clear();
                LoadProductsByType(shop.Products,"OTHER");
                this.nudQuantity.Value = 0;
                ClearLabels();
                selectedType = "OTHER";
            }
        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (selected == "")
                {
                    throw new Exception("Select an item from the listbox first.");
                }
                if (videoSource != null && videoSource.IsRunning)
                {
                   throw new Exception("You are currently scanning.");
                }
                if (order.Count == 0)
                {
                    UpdateItemForm uif = new UpdateItemForm(rClient, GetSelectedProduct(selected), this, shop);
                    uif.Show();
                }
                else
                {
                    MessageBox.Show("Order isn't empty. Empty it before updating a product.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Product GetSelectedProduct(string name)
        {
            foreach (Product p in shop.Products)
            {
                if (p.Name == selected)
                {
                    return p;
                }
            }
            return null;
        }

        public void ClearLabels()
        {
            selected = "";
            this.lblCurrentInStock.Text = "";
            this.lblDescription.Text = "";
            this.lblPriceSingleItem.Text = "";
        }

        private void btnCompleteOrder_Click(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                MessageBox.Show("You are already scanning.");
            }
            else if (order.Count == 0)
            {
                MessageBox.Show("Order is empty!");
            }
            else
            {
                btnStopCamera.Enabled = true;
                btnStopCamera.Visible = true;
                //completing the order!
                videoSource.Start();
                timer1.Start();
            }
        }

        #region camera stuffs
        private void PopulateVideoSources() //populates combobox and assigns new frame event
        {
            videoDeviceList = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo videoDevice in videoDeviceList)
            {
                cmbVideoSource.Items.Add(videoDevice.Name);
            }
            if (cmbVideoSource.Items.Count > 0)
            {
                cmbVideoSource.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No video sources found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            videoSource = new VideoCaptureDevice(videoDeviceList[cmbVideoSource.SelectedIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
        }
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            pbCamera.Image = bitmap;
        }
        private void decode_QRtag()
        {
            try
            {
                Bitmap bitmap = new Bitmap(pbCamera.Image);
                BarcodeReader reader = new BarcodeReader { AutoRotate = true, TryHarder = true };
                Result result = reader.Decode(bitmap);
                string decoded = result.ToString().Trim();
                long ticketId = Convert.ToInt64(decoded);

                ticket = rClient.GetTicket(ticketId);

                timer1.Stop();
                videoSource.SignalToStop();
                pbCamera.Image = null;
                btnStopCamera.Enabled = false;
                btnStopCamera.Visible = false;

                if (ticket.Balance >= CalculatePrice(order))
                {
                    foreach (Product p in order)
                    {
                        for (int i = 0; i < p.NrInOrder; i++)
                        {
                            rClient.BuyProduct(ticketId, p.Id);
                        }
                    }
                    MessageBox.Show("Purchase successful.");

                }
                else
                {
                    MessageBox.Show("Balance too low");
                }

                ClearOrder();

            }
            catch
            {
            }
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            decode_QRtag();
        }

        private void ShopForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
            }
        }

        private void btnStopCamera_Click(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                timer1.Stop();
                btnStopCamera.Visible = false;
                btnStopCamera.Enabled = false;
                pbCamera.Image = null;
            }
        }
        private void ClearOrder()
        {
            order.Clear();
            lbOrder.Items.Clear();
            ClearLabels();
            nudQuantity.Value = 0;
            selectedIndexOrder = -1;
            lblTotalPrice.Text = "N/A";
        }
    }
}
