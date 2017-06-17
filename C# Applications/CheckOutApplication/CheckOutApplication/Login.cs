using System;
using System.Windows.Forms;
using System.Threading;

namespace CheckOut
{
    public partial class Login : Form
    {
        RestClient client;
        Thread thread;
        User user;
        public Login()
        {
            InitializeComponent();
            client = new RestClient();
        }
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (client.LogIn("http://localhost:8080/login", tbUsername.Text, tbPassword.Text))
                {
                    user = client.GetLoggedUser("http://localhost:8080/users/current");
                    if (user.UserRole.ToString() != "EMPLOYEE")
                    {
                        MessageBox.Show("You cannot use that application with that account!");
                        tbUsername.Clear();
                        tbPassword.Clear();
                    }
                    else
                    {
                        tbUsername.Clear();
                        tbPassword.Clear();
                        this.Close();
                        thread = new Thread(openNewForm);
                        thread.Start();
                    }
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("Please input a valid value in the boxes!");
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Please input a valid value in the boxes!");
            }
        }
        private void openNewForm()
        {
            try
            {
                Application.Run(new MainApp(client));
            }
            catch(ArgumentException)
            {
                MessageBox.Show("Invalid user!");
            }
        }
    }
}
