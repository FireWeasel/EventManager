using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Statistics
{
    public partial class Statistics : Form
    {
        RestClient client;
        Loan_Stand stand;
        List<Shop> shop;
        public Statistics(RestClient client)
        {
            InitializeComponent();
            this.client = client;
            stand = client.GetLoanStand();
            shop = client.GetShop();

            #region First time initializing statistics
            itemLoanedLabel.Text = CountItems().ToString();
            totalCampsLabel.Text = CountVisitors().ToString();
            itemSoldLabel.Text = CountProducts().ToString();
            loanStandProfitLb.Text = LoanStandRevenue().ToString();
            profitLabel.Text = ShopRevenue().ToString();
            totalCamps.Text = CountCamps().ToString();
            checkedLabel.Text = CheckedIn().ToString();
            campingSitesLabel.Text = client.RequestFreeCamps().Count.ToString();
            #endregion
            #region Setting timer
            timer1.Enabled = true;
            timer1.Interval = 5000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            #endregion
        }
        #region Form methods
        private void timer1_Tick(object sender, EventArgs e)
        {
            itemLoanedLabel.Text = CountItems().ToString();
            totalCampsLabel.Text = CountVisitors().ToString();
            itemSoldLabel.Text = CountProducts().ToString();
            loanStandProfitLb.Text = LoanStandRevenue().ToString();
            profitLabel.Text = ShopRevenue().ToString();
            totalCamps.Text = CountCamps().ToString();
            checkedLabel.Text = CheckedIn().ToString();
            campingSitesLabel.Text = CounteFreeCamps().ToString();
        }
        #endregion
        #region Client methods
        private int CheckedIn()
        {
            int counter = 0;
            foreach(Ticket ticket in client.GetTickets())
            {
                if(ticket.CheckedIn)
                {
                    counter++;
                }
            }
            return counter;
        }
        private double ShopRevenue()
        {
            double price = 0;
            foreach(Shop shop in client.GetShop())
            {
                price += shop.Revenue;
            }
            return price;
        }
        private double LoanStandRevenue()
        {
            return client.GetLoanStand().Revenue    ;
        }
        private int CountCamps()
        {
            int counter = 0;
            foreach (Camp camp in client.RequestCamps())
            {
                counter++;
            }
            return counter;
        }
        private int CounteFreeCamps()
        {
            int counter = 0;
            foreach(Camp freeCamp in client.RequestFreeCamps())
            {
                counter++;
            }
            return counter;
        }
        private int CountItems()
        {
            int counter = 0;
            foreach(Item item in client.LoanedItem())
            {
                counter++;
            }
            return counter;
        }
        private int CountVisitors()
        {
            int counter = 0;
            foreach(Ticket ticket in client.GetTickets())
            {
                counter++;
            }
            return counter;
        }
        private int CountProducts()
        {
            int counter = 0;
            foreach(Classes product in client.GetSoldProduct())
            {
                counter++;
            }
            return counter;
        }
        #endregion
        #region Closing form and logging out
        private void Statistics_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.GetRequest("http://localhost:8080/logout");
        }
        #endregion
    }
}
