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
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace Rent_Items_Test
{
    public partial class MainApplication : Form
    {
        #region Setting objects of class Thread, RestClient, Load_Stand and list of type Item
        RestClient newClient;
        Loan_Stand stand;
        List<Item> type;
        Ticket ticket;
        IVideoSource videoSource;
        FilterInfoCollection videoDeviceList;
        private volatile object _locker = new object();
        #endregion
        #region Constructor
        public MainApplication(RestClient client)
        {
            InitializeComponent();
            this.newClient = client;
            stand = newClient.GetLoanStand();
            radioButton1.Text = Type.ELECTRONICS.ToString();
            radioButton2.Text = Type.OTHER.ToString();
            SetUpVideoSources();
            
        }
        #endregion
        #region Camera settings
        public void SetUpVideoSources()
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
            pictureBox1.Image = bitmap;
        }
        private void DecodeQRtag()
        {
            try
            {
                Bitmap bitmap = new Bitmap(pictureBox1.Image);
                BarcodeReader reader = new BarcodeReader { AutoRotate = true, TryHarder = true };
                Result result = reader.Decode(bitmap);
                string decoded = result.ToString().Trim();
                long ticketId = Convert.ToInt64(decoded);
                double value = Convert.ToDouble(StockNUD.Value);
                Item item = type[ItemCb.SelectedIndex];
                ticket = newClient.GetTicket(ticketId);
                timer1.Stop();
                videoSource.SignalToStop();
                pictureBox1.Image = null;
                btnStopCamera.Enabled = false;
                btnStopCamera.Visible = false;

                if (item.Quantity != 0)
                {
                    if(ticket.Balance >= (value * item.Fee))
                    {
                        foreach(Item it in stand.Items)
                        {
                            if(it.Name == item.Name)
                            {
                                for(int i = 0; i < value; i++)
                                {
                                    newClient.BorrowItem(ticketId, it.ID);
                                }
                            }
                        }
                        MessageBox.Show("Item loaned successfully");
                    }
                    else
                    {
                        MessageBox.Show("Balance too low");
                    }
                }
                else
                {
                    MessageBox.Show("Item not in stock!");
                }
                UpdateListMethod();
                StockNUD.Value = 0;
                label4.Text = "0";
                label7.Text = "0";
            }
            catch
            {
            }
        }
        #endregion
        #region New form (Add and Update)
        private void AddBtn_Click(object sender, EventArgs e)
        {
            AddProduct form = new AddProduct(newClient, stand, this);
            form.Show();
        }
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateItem form2 = new UpdateItem(newClient, stand, this);
            form2.Show();
        }
        #endregion
        #region Methods loan stand
        public void LoadItemByType(string name)
        {
            type = new List<Item>();
            ItemCb.Enabled = true;

            ListItems.Items.Clear();
            ItemCb.Items.Clear();

            stand.GetAllItems(newClient);

            foreach (Item item in stand.Items)
            {
                if (item.Type.ToString() == name)
                {
                    type.Add(item);
                }
            }
            foreach(Item items in type)
            {
                ListItems.Items.Add(items.AsString());
                ItemCb.Items.Add(items.Name);
            }
        }
        public void LoadQuantityByItem(int id)
        {
            StockNUD.Enabled = true;
            LoanBtn.Enabled = true;
            stand.GetAllItems(newClient);
            

            if (id== -1)
            {
                StockNUD.Maximum = type[id + 1].Quantity;
                label4.Text = type[id + 1].Fee.ToString();
            }
            else
            {
                StockNUD.Maximum = type[id].Quantity;
                label4.Text = type[id].Fee.ToString();
            }
        }
        public void UpdateListMethod()
        {
            ListItems.Items.Clear();
            foreach (Item item in newClient.RequestItems())
            {
                ListItems.Items.Add(item.AsString());
            }
        }
        #endregion
        #region Form methods
        private void ItemCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = ItemCb.SelectedIndex;
            LoadQuantityByItem(id);
        }
        
        private void LoanBtn_Click(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                MessageBox.Show("You are already scanning.");
            }
            else
            {
                btnStopCamera.Enabled = true;
                btnStopCamera.Visible = true;
                videoSource.Start();
                timer1.Start();
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            LoadItemByType(radioButton1.Text);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            LoadItemByType(radioButton2.Text);
        }

        private void StockNUD_ValueChanged(object sender, EventArgs e)
        {
            decimal value = StockNUD.Value;
            Item item = type[ItemCb.SelectedIndex];
            label7.Text = (value * (Convert.ToDecimal(item.Fee))).ToString();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DecodeQRtag();
        }

        private void btnStopCamera_Click(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                timer1.Stop();
                btnStopCamera.Visible = false;
                btnStopCamera.Enabled = false;
                pictureBox1.Image = null;
            }
        }
        #endregion
    }
}
