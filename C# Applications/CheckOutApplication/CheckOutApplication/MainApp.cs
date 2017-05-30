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
        Ticket ticket;
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

        public void CompleteCheckOut(string text)
        {
            ticket = client.GetTicket(Convert.ToInt32(text));
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
                            label2.Text = "There are items that are not returned!";
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
                        MessageBox.Show("Ticket already checked out!");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Ticket is not checked in!");
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

        private void button2_Click(object sender, EventArgs e)
        {
            List<BorrowedItem> items = client.GetTicketItems(ticket.ID);
            foreach(BorrowedItem item in items)
            {
                if(item.Returned == false)
                {
                    client.ReturnItems(ticket.ID, item.ID);
                }
            }
            MessageBox.Show("Items returned!");
            client.CheckOutTicket(ticket.ID);
            ticket = client.GetTicket(ticket.ID);
            LbUsers.Items.Add("Checked out: " + ticket.CheckedOut.ToString());
            label2.Text = "Everything is returned";
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            lblPaidReservation.Visible = true;
            lblReservationNotPayed.Visible = false;
        }

        private void MainApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.GetRequest("http://localhost:8080/loglout");
        }
    }
}
