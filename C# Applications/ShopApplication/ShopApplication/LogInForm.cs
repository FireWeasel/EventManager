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

namespace ShopApplication
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

                User currentUser = rClient.GetCurrentUser("http://localhost:8080/users/current");
                if (currentUser.UserRole != "EMPLOYEE")
                {
                    MessageBox.Show("You cannot use that application with that account!");
                }
                else
                {
                    this.Close();
                    thread = new Thread(OpenNewForm);
                    thread.Start();
                }
            }
            tbUsername.Clear();
            tbPassword.Clear();
        }

        private void OpenNewForm()
        {
            Application.Run(new ShopForm(rClient));
        }
    }
}
