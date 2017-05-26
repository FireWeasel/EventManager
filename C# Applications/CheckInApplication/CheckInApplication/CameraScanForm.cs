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

namespace CheckInApplication
{
    public partial class CameraScanForm : Form
    {
        private CheckInForm checkInForm;

        private FilterInfoCollection videoDeviceList;
        private IVideoSource videoSource;
        private volatile object _locker = new object();
        public CameraScanForm(CheckInForm form)
        {
            this.checkInForm = form;

            InitializeComponent();
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
            }
            this.FormClosing += Form1_FormClosing;
            #region Start video and timer
            videoSource = new VideoCaptureDevice(videoDeviceList[cmbVideoSource.SelectedIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            videoSource.Start();
            timer1.Start();
            #endregion

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource!=null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
            }

        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bitmap;
            
        }

        private void decode_QRtag()
        {
            try
            {
                //pictureBox1 shows the web cam video
                Bitmap bitmap = new Bitmap(pictureBox1.Image);

                BarcodeReader reader = new BarcodeReader { AutoRotate = true, TryHarder = true };
                Result result = reader.Decode(bitmap);
                string decoded = result.ToString().Trim();
                //capture a snapshot if there is a match
                textBox1.Text = decoded;
            }
            catch
            {
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            decode_QRtag();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            videoSource.SignalToStop();
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            timer1.Stop();

            this.Close();
        }

        private void CameraScanForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            checkInForm.CompleteCheckIn(textBox1.Text);
        }
    }
}
