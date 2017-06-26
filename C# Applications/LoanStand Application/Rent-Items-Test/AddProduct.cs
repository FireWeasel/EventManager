using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rent_Items_Test
{
    public partial class AddProduct : Form
    {
        #region Setting objects of class RestClient and Loan_Stand
        RestClient client;
        Loan_Stand newStand;
        MainApplication mainApp;
        private int counter;
        #endregion
        #region Constructor
        public AddProduct(RestClient newClient, Loan_Stand stand, MainApplication main)
        {
            InitializeComponent();

            newStand = stand;
            client = newClient;
            mainApp = main;

            typeCb.Items.Add(Type.ELECTRONICS);
            typeCb.Items.Add(Type.OTHER);
        }
        #endregion
        #region Form methods
        private void AddItemBtn_Click(object sender, EventArgs e)
        {
            if (nameTb.Text == null || descTb.Text == null || quantNUD.Value == 0 || typeCb.SelectedIndex == -1 || feeNUD.Value == 0)
            {
                timer1.Start();
                label6.Text = "Values for item cannot be empty, please fill every box";
            }
            else
            {
                string name = nameTb.Text;
                string desciption = descTb.Text;
                double fee = Convert.ToDouble(feeNUD.Value);
                int quantity = Convert.ToInt32(quantNUD.Value);
                string type = typeCb.Text;

                client.AddData(newStand.Id, name, desciption, fee, quantity, type);
                mainApp.UpdateListMethod();
                ActiveForm.Refresh();
                nameTb.Clear();
                descTb.Clear();
                typeCb.SelectedIndex = -1;
                feeNUD.Value = 0;
                quantNUD.Value = 0;
                mainApp.ClearGUI();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0) { label5.Text = ""; timer1.Stop(); }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            counter = 5;
        }
        #endregion

        private void AddProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainApp.ClearGUI();
        }
    }
}
