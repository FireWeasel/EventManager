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

namespace CheckOut
{
    public partial class Camera : Form
    {
        MainApp mainApp;
        IVideoSource source;
        FilterInfoCollection deviceLIst;
        private volatile object _locker = new object();
        public Camera(MainApp mainapplication)
        {
            mainApp = mainapplication;

            InitializeComponent();
            
            deviceLIst = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach(FilterInfo device in deviceLIst)
            {
                cbDevices.Items.Add(device.Name);
            }
            if(cbDevices.Items.Count > 0)
            {
                cbDevices.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No video sources found");
            }
            FormClosing += Form1_FormClosing;
            source = new VideoCaptureDevice(deviceLIst[cbDevices.SelectedIndex].MonikerString);
            source.NewFrame += new NewFrameEventHandler(video_Frame);
            source.Start();
            timer1.Enabled = true;
            timer1.Start();
        }

        private void video_Frame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap map = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = map;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (source != null && source.IsRunning)
            {
                source.SignalToStop();
            }
        }

        private void DecodeQR()
        {
            try
            {
                Bitmap map = new Bitmap(pictureBox1.Image);
                BarcodeReader reader = new BarcodeReader { AutoRotate = true, TryHarder = true };
                Result result = reader.Decode(map);
                string decoded = result.ToString().Trim();
                textBox1.Text = decoded;
            }
            catch { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DecodeQR();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            source.SignalToStop();
            if(pictureBox1.Image!=null)
            {
                pictureBox1.Image.Dispose();
            }
            timer1.Stop();

            this.Close();
        }

        private void Camera_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainApp.CompleteCheckOut(textBox1.Text.ToString());
        }
    }
}
