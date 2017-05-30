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

namespace CheckOut
{
    public partial class Login : Form
    {
        RestClient client;
        Thread thread;
        public Login()
        {
            InitializeComponent();
            client = new RestClient();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            client.LogIn("http://localhost:8080/login", tbUsername.Text, tbPassword.Text);
            tbUsername.Clear();
            tbPassword.Clear();
            this.Close();
            thread = new Thread(openNewForm);
            thread.Start();
        }
        private void openNewForm()
        {
            Application.Run(new MainApp(client));
        }
    }
}
