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
    public partial class CampingForm : Form
    {
        private RestClient rClient;
        private Ticket ticket;
        public CampingForm(RestClient rClient)
        {
            this.rClient = rClient;
            InitializeComponent();
        }

        private void btnCheckReservation_Click(object sender, EventArgs e)
        {
            HidePictures();

            try
            {
                ticket = this.rClient.GetTicket(Convert.ToInt64(textBox1.Text));
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
            }
            catch (WebException we)
            {
                MessageBox.Show("Check in unsuccessful!" + we.Message);
                pictureBox2.Visible = true;
                lblReservationNotPayed.Visible = true;
            }
            
        
        }

        private void HidePictures()
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            lblPaidReservation.Visible = false;
            lblReservationNotPayed.Visible = false;
        }

        private void UpdateListbox(User user)
        {
            #region clearing listbox and hiding picture boxes
            this.lbUserInformation.Items.Clear();
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            lblPaidReservation.Visible = false;
            lblReservationNotPayed.Visible = false;
            #endregion

            lbUserInformation.Items.Add("User id:" + user.Id);
            lbUserInformation.Items.Add("Username:" + user.Username);
            lbUserInformation.Items.Add("E-mail: "+user.Email);

            //if (user.Reservation.Paid)
            //{
            //    pictureBox1.Show();
            //    lblPaidReservation.Show();
            //}
            //else
            //{
            //    pictureBox2.Show();
            //    lblReservationNotPayed.Show();
            //}
        }

        private void CampingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            rClient.GetRequest("http://localhost:8080/logout");
        }
    }
}
