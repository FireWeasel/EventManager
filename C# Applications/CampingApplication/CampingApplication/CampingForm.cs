using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampingApplication
{
    public partial class CampingForm : Form
    {
        private RestClient rClient;
        private User user;
        public CampingForm(RestClient rClient)
        {
            this.rClient = rClient;
            InitializeComponent();
        }

        private void btnCheckReservation_Click(object sender, EventArgs e)
        {
            try
            {
                user = this.rClient.GetTicket(Convert.ToInt64(textBox1.Text));
                UpdateListbox(user);
            }
            catch (FormatException)
            {
                MessageBox.Show("Incorrect input information.");
            }
            

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
            lbUserInformation.Items.Add("Reservation ID:  " + user.Reservation.Id);

            if (user.Reservation.Paid)
            {
                pictureBox1.Show();
                lblPaidReservation.Show();
            }
            else
            {
                pictureBox2.Show();
                lblReservationNotPayed.Show();
            }
        }

        private void CampingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            rClient.GetRequest("http://localhost:8080/logout");
        }
    }
}
