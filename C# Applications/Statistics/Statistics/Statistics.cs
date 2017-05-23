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
        Shop shop;
        public Statistics(RestClient client)
        {
            InitializeComponent();

            this.client = client;
            stand = client.GetLoanStand();
            shop = client.GetShop();

            itemLoanedLabel.Text = CountItems().ToString();
            totalCampsLabel.Text = CountVisitors().ToString();
            itemSoldLabel.Text = CountProducts().ToString();
            loanStandProfitLb.Text = LoanStandRevenue().ToString();
            profitLabel.Text = ShopRevenue().ToString();
            totalCamps.Text = CountCamps().ToString();
            checkedLabel.Text = CheckedIn().ToString();
            campingSitesLabel.Text = client.RequestFreeCamps().Count.ToString();

            timer1.Enabled = true;
            timer1.Interval = 5000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            itemLoanedLabel.Text = CountItems().ToString();
            totalCampsLabel.Text = CountVisitors().ToString();
            itemSoldLabel.Text = CountProducts().ToString();
            loanStandProfitLb.Text = LoanStandRevenue().ToString();
            profitLabel.Text = ShopRevenue().ToString();
            totalCamps.Text = CountCamps().ToString();
            checkedLabel.Text = CheckedIn().ToString();
            campingSitesLabel.Text = client.RequestFreeCamps().Count.ToString();
        }
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
        private int CountCamps()
        {
            int counter = 0;
            foreach(Camp camp in client.RequestCamps())
            {
                counter++;
            }
            return counter;
        }
        private double ShopRevenue()
        {
            return shop.Revenue;
        }
        private double LoanStandRevenue()
        {
            return stand.Revenue;
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
            foreach(Product product in client.GetSoldProduct())
            {
                counter++;
            }
            return counter;
        }
       
    }
}
