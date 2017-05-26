using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;

namespace CheckInApplication
{
    public partial class LogInForm : Form
    {
        private  RestClient rClient;
        Thread thread;

        public LogInForm()
        {
            InitializeComponent();
            rClient = new RestClient();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (rClient.LogIn("http://localhost:8080/login", tbUsername.Text, tbPassword.Text))
            {
                tbUsername.Clear();
                tbPassword.Clear();

                this.Close();
                thread = new Thread(OpenNewForm);
                thread.Start();
            }
        }

        private void OpenNewForm()
        {
            Application.Run(new CheckInForm(rClient));
        }
    }
}
