using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckInApplication
{
    public partial class CheckInForm : Form
    {
        private RestClient rClient;
        private Ticket ticket;
        private User owner;
        public CheckInForm(RestClient rClient)
        {
            this.rClient = rClient;
            InitializeComponent();
        }

        private void btnCheckReservation_Click(object sender, EventArgs e)
        {

            CameraScanForm csf = new CameraScanForm(this);
            csf.Show();

        }

        public void CompleteCheckIn(String id)
        {
            HidePictures();

            try
            {
                ticket = this.rClient.GetTicket(Convert.ToInt64(id));
                owner = rClient.GetUser(Convert.ToInt64(id));
                if (ticket.CheckedIn)
                {
                    MessageBox.Show("Ticket already checked in.");
                    pictureBox1.Visible = true;
                    lblPaidReservation.Visible = true;
                }
                else
                {
                    rClient.CheckInTicket(ticket.Id);
                    pictureBox1.Visible = true;
                    lblPaidReservation.Visible = true;
                }
                UpdateListbox(owner);
            }
            catch (WebException we)
            {
                MessageBox.Show("Check in unsuccessful!" + we.Message);
                pictureBox2.Visible = true;
                lblReservationNotPayed.Visible = true;
            }
        }

        public void HidePictures()
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            lblPaidReservation.Visible = false;
            lblReservationNotPayed.Visible = false;
        }

        private void UpdateListbox(User user)
        {
            lbUserInformation.Items.Clear();
            lbUserInformation.Items.Add("User id:" + user.Id);
            lbUserInformation.Items.Add("Username:" + user.Username);
            lbUserInformation.Items.Add("E-mail: "+user.Email);
        }

        private void CampingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            rClient.GetRequest("http://localhost:8080/logout");
        }
    }
}
