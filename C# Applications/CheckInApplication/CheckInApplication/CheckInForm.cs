using AForge.Video;
using AForge.Video.DirectShow;
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
using ZXing;

namespace CheckInApplication
{
    public partial class CheckInForm : Form
    {
        private RestClient rClient;
        private Ticket ticket;
        private User owner;
        private IVideoSource videoSource;
        private FilterInfoCollection videoDeviceList;
        private volatile object _locker = new object();
        public CheckInForm(RestClient rClient)
        {
            this.rClient = rClient;
            InitializeComponent();

            #region Populate combobox with available cameras and assigning NewFrame Event
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
            HidePictures();
            if (videoSource != null && videoSource.IsRunning) // click twice = turn off camera
            {
                videoSource.SignalToStop();
                pbCamera.Image = null;
                btnCheckInTicket.Text = "Click to scan ticket";
            }
            else
            {
                #region Start video and timer
                btnCheckInTicket.Text = "Stop scanning";
                videoSource.Start();
                timer1.Start();

                #endregion
            }
        }
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap  bitmap = (Bitmap)eventArgs.Frame.Clone();
            //bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //bitmap.SetResolution(pbCamera.Width, pbCamera.Height);
            pbCamera.Image = bitmap;
        }

        private void decode_QRtag()
        {
            try
            {
                //pictureBox1 shows the web cam video
                Bitmap bitmap = new Bitmap(pbCamera.Image);
                BarcodeReader reader = new BarcodeReader { AutoRotate = true, TryHarder = true };
                Result result = reader.Decode(bitmap);
                string decoded = result.ToString().Trim();
                timer1.Stop();
                videoSource.SignalToStop();
                CompleteCheckIn(decoded);
                btnCheckInTicket.Text = "Click to scan ticket";
                pbCamera.Image = null;
            }
            catch
            {
            }
        }

        public void CompleteCheckIn(String id)
        {
            HidePictures();
            try
            {
                ticket = this.rClient.GetTicket(Convert.ToInt64(id));
                owner = rClient.GetUser(Convert.ToInt64(id));
                if (ticket.CheckedIn)
                { //if it was already checked in
                    MessageBox.Show("Ticket already checked in.");
                    pictureBox1.Visible = true;
                    lblPaidReservation.Text = "Check in successful!";
                    lblPaidReservation.Visible = true;
                }
                else
                {
                    //checking in for the first time
                    rClient.CheckInTicket(ticket.Id);
                    pictureBox1.Visible = true;
                    lblPaidReservation.Text = "Check in successful!";
                    lblPaidReservation.Visible = true;
                }
                UpdateListbox(owner);
            }
            catch (Exception) //web,format,argument
            {
                MessageBox.Show("Check in unsuccessful!");
                pictureBox2.Visible = true;
                lblPaidReservation.Text = "Check in unsuccessful!";
                lblPaidReservation.Visible = true;
            }
        }

        public void HidePictures()
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            lblPaidReservation.Visible = false;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            decode_QRtag();
        }

        private void CheckInForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
            }
        }
    }
}
