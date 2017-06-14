using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using System.Net;

namespace CampingApplication
{
    public partial class CampingForm : Form
    {
        private RestClient rClient;
        private User user;
        private IVideoSource videoSource;
        private FilterInfoCollection videoDeviceList;
        private volatile object _locker = new object();
        private int countdown;

        public CampingForm(RestClient rClient)
        {
            this.rClient = rClient;
            InitializeComponent();

            #region Populate combobox with available cameras and subscribing to NewFrame Event
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

        private void btnCheckReservation_Click(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning) // click twice = turn off camera
            {
                videoSource.SignalToStop();
                pbCamera.Image = null;
                timer1.Stop();
                btnCheckReservation.Text = "Click to scan ticket";
                HidePictures();
            }
            else
            {
                btnCheckReservation.Text = "Stop scanning";
                videoSource.Start();
                timer1.Start();
            }


        }
        private void HidePictures()
        {
            this.lbUserInformation.Items.Clear();
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            lblPaidReservation.Visible = false;
        }

        private void UpdateListbox(User user)
        {
            lbUserInformation.Items.Add("User id:" + user.Id);
            lbUserInformation.Items.Add("Username:" + user.Username);
            lbUserInformation.Items.Add("E-mail: "+user.Email);
            lbUserInformation.Items.Add("Reservation ID:  " + user.Reservation.Id);

            lblPaidReservation.Visible = true;

            if (user.Reservation.Paid)
            {
                pictureBox1.Show();
                
                lblPaidReservation.Text = "Reservation payed!";
            }
            else
            {
                pictureBox2.Show();
                lblPaidReservation.Text = "Reservation not payed!";
            }
        }

        private void CampingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            rClient.GetLogOut("http://localhost:8080/logout");
        }




        #region camera functionality
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
                timer1.Stop();
                videoSource.SignalToStop();
                GetUser(decoded);


                btnCheckReservation.Text = "Start scanning";
                pbCamera.Image = null;
                
            }
            catch
            {
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            decode_QRtag();
        }
        #endregion

        private void GetUser(String decoded)
        {
            try
            {
                user = this.rClient.GetOwnerOfTicket(Convert.ToInt64(decoded));
                UpdateListbox(user);
            }
            catch (Exception)
            {
                lblErrorMessage.Text = "No such reservation found. Try again!";
                errorTimer.Start();
            }
        }


        private void CampingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
            }
        }

        private void errorTimer_Tick(object sender, EventArgs e)
        {
            countdown--;
            if (countdown == 0)
            {
                errorTimer.Stop();
                lblErrorMessage.Text = "";
            }
        }

        private void lblErrorMessage_TextChanged(object sender, EventArgs e)
        {
            countdown = 5;
        }
    }
}
