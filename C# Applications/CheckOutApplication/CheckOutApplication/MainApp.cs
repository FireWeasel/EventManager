using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using ZXing;
using AForge.Video;
using AForge.Video.DirectShow;

namespace CheckOut
{
    public partial class MainApp : Form
    {
        #region Fields and objects
        RestClient client;
        Ticket ticket;
        IVideoSource videoSource;
        FilterInfoCollection videoDeviceList;
        private volatile object _locker = new object();
        private int counter;
        #endregion
        #region Constructor
        public MainApp(RestClient client)
        {
            InitializeComponent();
            this.client = client;

            #region Set up video settings
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
            #endregion
        }
        #endregion
        #region Camera properties
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap map = (Bitmap)eventArgs.Frame.Clone();
            pbCamera.Image = map;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DecodeQr();
        }
        private void DecodeQr()
        {
            try
            {
                Bitmap map = new Bitmap(pbCamera.Image);
                BarcodeReader reader = new BarcodeReader { AutoRotate = true, TryHarder = true };
                Result result = reader.Decode(map);
                string decoded = result.ToString().Trim();
                timer1.Stop();
                videoSource.SignalToStop();
                CompleteCheckOut(decoded);
                button1.Text = "Click to scan ticket";
                pbCamera.Image = null;
            }
            catch { }
        }
        #endregion
        #region Form methods
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            lblPaidReservation.Visible = false;
            lblReservationNotPayed.Visible = false;
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                pbCamera.Image = null;
                button1.Text = "Click to scan ticket";
            }
            else
            {
                button1.Text = "Stop scanning";
                videoSource.Start();
                timer1.Start();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            List<BorrowedItem> items = client.GetTicketItems(ticket.ID);
            foreach (BorrowedItem item in items)
            {
                if (item.Returned == false)
                {
                    client.ReturnItems(ticket.ID, item.ID);
                }
            }
            MessageBox.Show("Items returned!");
            client.CheckOutTicket(ticket.ID);
            ticket = client.GetTicket(ticket.ID);
            LbUsers.Items.Add("Checked out: " + ticket.CheckedOut.ToString());
            label2.Text = "Everything is returned";
            listBox1.Items.Clear();
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            lblPaidReservation.Visible = true;
            lblReservationNotPayed.Visible = false;
        }
        private void MainApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.GetRequest("http://localhost:8080/loglout");
        }
        #endregion
        #region CheckOutMethods
        public void CompleteCheckOut(string text)
        {
            ticket = client.GetTicket(Convert.ToInt32(text));
            try
            {
                if (ticket.CheckedIn)
                {
                    if (!ticket.CheckedOut)
                    {
                        List<BorrowedItem> notReturnedItems = client.GetTicketItems(Convert.ToInt32(text));
                        User user = client.GetUser(Convert.ToInt32(text));
                        if (notReturnedItems != null)
                        {
                            ShowInfo(user);
                            label2.Text = "There are items that are not returned!";
                            listBox1.Items.Clear();
                            CountItemsToBeReturned(notReturnedItems);
                            pictureBox2.Visible = true;
                            lblReservationNotPayed.Visible = true;
                            button2.Enabled = true;
                        }
                        else
                        {
                            ShowInfo(user);
                            label2.Text = "Everything is returned";
                            pictureBox1.Visible = true;
                            lblPaidReservation.Visible = true;
                            client.CheckOutTicket(Convert.ToInt32(text));
                            client.GetTicket(Convert.ToInt32(text));
                        }
                    }
                    else
                    {
                        lblErrorMessage.Text = "Ticked is already checked out!";
                        timer2.Start();
                    }

                }
                else
                {
                    lblErrorMessage.Text = "Ticket is not checked in!";
                    timer2.Start();
                }
            }
            catch (Exception)
            {
                lblErrorMessage.Text = "Check out unsuccessful!";
                timer2.Start();
                pictureBox2.Visible = true;
                lblReservationNotPayed.Visible = true;
            }
        }

        private void CountItemsToBeReturned(List<BorrowedItem> items)
        {
            string[] names = new string[items.Count];
            for (int i = 0; i < items.Count; i++)
            {
                names[i] = items[i].Item.Name;
            }
            Dictionary<string, int> counts = names.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            foreach (KeyValuePair<string, int> name in counts)
            {
                listBox1.Items.Add("Item: " + name.Key + " Nr to be returned: " + name.Value);
            }
        }
        public void ShowInfo(User user)
        {
            LbUsers.Items.Clear();
            LbUsers.Items.Add("User ID: " + user.Id);
            LbUsers.Items.Add("Username: " + user.Username);
            LbUsers.Items.Add("E-mail: " + user.Email);
        }
        #endregion

        private void lblErrorMessage_Click(object sender, EventArgs e)
        {
            counter = 5;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0) { timer2.Stop();lblErrorMessage.Text = ""; }
        }
    }
}
