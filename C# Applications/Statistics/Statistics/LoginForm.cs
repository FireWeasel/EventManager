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

namespace Statistics
{
    public partial class LoginForm : Form
    {
        #region Setting objects of class RestClient and Thread
        RestClient client;
        Thread thread;
        User user;
        #endregion
        public LoginForm()
        {
            InitializeComponent();
            client = new RestClient();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (client.LogIn("http://localhost:8080/login", textBox1.Text, textBox2.Text))
            {
                user = client.GetLoggedUser("http://localhost:8080/users/current");
                if (user.UserRole.ToString() != "EMPLOYEE")
                {
                    MessageBox.Show("You cannot use that application with that account!");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                else
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    this.Close();
                    thread = new Thread(openNewForm);
                    thread.Start();
                }
            }
        }

        private void openNewForm()
        {
            Application.Run(new Statistics(client));
        }
    }
}
