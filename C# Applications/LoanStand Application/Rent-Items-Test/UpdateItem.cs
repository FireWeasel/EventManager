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
    public partial class UpdateItem : Form
    {
        #region Setting objects of class RestClient and Loan_Stand
        RestClient client;
        Loan_Stand newStand;
        MainApplication mainApp;
        #endregion
        #region Constructor
        public UpdateItem(RestClient newClient,Loan_Stand stand,MainApplication app)
        {
            InitializeComponent();
            

            client = newClient;
            newStand = stand;
            mainApp = app;

            newStand.Items = client.RequestItems();

            foreach (Item item in stand.Items)
            {
                IdNameCb.Items.Add(item.ID + " " + item.Name);
            }
        }
        #endregion
        #region Form methods
        private void AddItemBtn_Click(object sender, EventArgs e)
        {
            client.UpdateData(IdNameCb.SelectedIndex + 1,NameTb.Text,descTb.Text,Convert.ToDouble(feeNUD.Value),Convert.ToInt32(quantNUD.Value));
            newStand.Items = client.RequestItems();
            mainApp.UpdateListMethod();
            newStand.Items = client.RequestItems();
            IdNameCb.Items.Clear();


            foreach (Item item in newStand.Items)
            {
                IdNameCb.Items.Add(item.ID + " " + item.Name);
            }

            NameTb.Clear();
            descTb.Clear();
            IdNameCb.SelectedIndex = -1;
            feeNUD.Value = 0;
            quantNUD.Value = 0;

            mainApp.ClearGUI();

        }

        private void IdNameCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = IdNameCb.SelectedIndex;
            NameTb.Clear();
            descTb.Clear();
            feeNUD.Value = 0;
            quantNUD.Value = 0;

            foreach(Item ite in newStand.Items)
            {
                if(ite.ID == index + 1)
                {
                    NameTb.Text = ite.Name;
                    descTb.Text = ite.Description;
                    feeNUD.Value = Convert.ToDecimal(ite.Fee);
                    quantNUD.Value = Convert.ToDecimal(ite.Quantity);
                }
            }
        }
        #endregion
    }
}
