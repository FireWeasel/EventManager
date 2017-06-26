using System;
using System.Windows.Forms;
using System.Threading;

namespace Rent_Items_Test
{
    public partial class LoginForm : Form
    {
        #region Setting objects of class RestClient and Thread
        RestClient client;
        Thread thread;
        #endregion
        #region Constructor and methods
        public LoginForm()
        {
            InitializeComponent();
            client = new RestClient();
        }
        private void LoginBtn_Click(object sender, EventArgs e)
        { 
            if(client.LogIn("http://localhost:8080/login", textBox1.Text, textBox2.Text))
            {
                textBox2.Clear();
                textBox1.Clear();
                if(client.GetUser().UserRole.ToString()!="EMPLOYEE")
                {
                    MessageBox.Show("You cannot use that application with that account!");
                }
                else
                {
                    this.Close();
                    thread = new Thread(openNewForm);
                    thread.Start();
                }
            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
            }
        }
        private void openNewForm()
        {
            Application.Run(new MainApplication(client));
        }
        #endregion
    }
}
