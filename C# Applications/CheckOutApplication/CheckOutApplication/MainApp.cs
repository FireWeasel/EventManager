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

namespace CheckOut
{
    public partial class MainApp : Form
    {
        RestClient client;
        public MainApp(RestClient client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Camera cameraForm = new Camera(this);
            cameraForm.Show();
        }
        private void UserLb(User user)
        {
            LbUsers.Items.Clear();
            LbUsers.Items.Add("User id:" + user.Id);
            LbUsers.Items.Add("Username:" + user.Username);
            LbUsers.Items.Add("E-mail: " + user.Email);
        }

        public void CompleteCheckOut(string text)
        {
            Ticket ticket = client.GetTicket(Convert.ToInt32(text));
            try
            {
                if(ticket.CheckedIn)
                {
                    if(!ticket.CheckedOut)
                    {
                        List<BorrowedItem> notReturnedItems = client.GetTicketItems(Convert.ToInt32(text));
                        User user = client.GetUser(Convert.ToInt32(text));
                        if (notReturnedItems != null)
                        {
                            ShowInfo(user);
                            //List<Item> items = GetAllNotReturnedItems(text);
                            label2.Text = "There are items that are not returned!";
                            //label4.Text = Price(items).ToString();
                            pictureBox2.Visible = true;
                            lblReservationNotPayed.Visible = true;
                            button2.Enabled = true;
                        }
                        else
                        {
                            ShowInfo(user);
                            label2.Text = "Everything is returned";
                            label4.Text = "0";
                            pictureBox1.Visible = true;
                            lblPaidReservation.Visible = true;
                            client.CheckOutTicket(Convert.ToInt32(text));
                            client.GetTicket(Convert.ToInt32(text));
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ticket already checked out!");
                    }
                    
                }
                else
                {
                    MessageBox.Show("User is not checked in!");
                }
            }
            catch(WebException web)
            {
                MessageBox.Show(web.Message);
            }
        }
        public void ShowInfo(User user)
        {
            LbUsers.Items.Clear();
            LbUsers.Items.Add("User ID: " + user.Id);
            LbUsers.Items.Add("Username: " + user.Username);
            LbUsers.Items.Add("E-mail: " + user.Email);
        }
        public List<Item> GetAllNotReturnedItems(string text)
        {
            List<Item> allItems = client.RequestItems();
            List<BorrowedItem> notReturnedItems = client.GetTicketItems(Convert.ToInt32(text));
            List<Item> itemsToBeReturned = null;
            foreach(BorrowedItem item in notReturnedItems)
            {
                int id = item.ItemId;
                itemsToBeReturned.Add(client.GetItem(id));
            }
            return itemsToBeReturned;
        }
        public double Price(List<Item> items)
        {
            double price = 0;
            foreach(Item item in items)
            {
                price += item.Fee;
            }
            return price;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //yet to be implemented

            //client.ReturnBorrowedItems();
        }

        private void MainApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.GetRequest("http://localhost:8080/loglout");
        }
    }
}
