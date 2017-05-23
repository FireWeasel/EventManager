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
        #endregion
        public LoginForm()
        {
            InitializeComponent();
            client = new RestClient();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        { 
            client.LogIn("http://localhost:8080/login", textBox1.Text, textBox2.Text);
            textBox2.Clear();
            textBox1.Clear();
            this.Close();
            thread = new Thread(openNewForm);
            thread.Start();
        }

        private void openNewForm()
        {
            Application.Run(new Statistics(client));
        }
    }
}
