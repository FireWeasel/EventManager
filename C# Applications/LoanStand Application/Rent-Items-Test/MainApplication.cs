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

namespace Rent_Items_Test
{
    public partial class MainApplication : Form
    {
        #region Setting objects of class Thread, RestClient, Load_Stand and list of type Item
        Thread thread;
        RestClient newClient;
        Loan_Stand stand;
        List<Item> type;
        Action myDelegate;
        #endregion
        #region Constructor
        public MainApplication(RestClient client)
        {
            InitializeComponent();

            newClient = client;
            stand = newClient.GetLoanStand();
            type = new List<Item>();
            myDelegate = new Action(UpdateListMethod);
            UpdateListMethod();

            

            CategoryCb.Items.Add(Type.ELECTRONICS.ToString());
            CategoryCb.Items.Add(Type.OTHER.ToString());
            
        }
        #endregion
        #region New form (Add and Update)
        private void AddBtn_Click(object sender, EventArgs e)
        {
            AddProduct form = new AddProduct(newClient, stand, this);
            form.Show();
        }
        public void openNewForm()
        {
            Application.Run(new AddProduct(newClient,stand,this));
        }
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateItem form2 = new UpdateItem(newClient, stand, this);
            form2.Show();
        }
        public void openUpdateForm()
        {
            Application.Run(new UpdateItem(newClient,stand,this));
        }
        #endregion
        #region Methods
        public void LoadItemByType(int index)
        {
            ListItems.Items.Clear();
            ItemCb.Items.Clear();

            ItemCb.Enabled = true;

            stand.GetAllItems(newClient);
            
            foreach (Item item in stand.Items)
            {
                if (Convert.ToInt32(item.Type) == index)
                {
                    type.Add(item);
                }
            }
            foreach(Item items in type)
            {
                ListItems.Items.Add(items.AsString());
                ItemCb.Items.Add(items.Name);
            }
        }
        public void LoadQuantityByItem(int id)
        {
            StockNUD.Enabled = true;
            LoanBtn.Enabled = true;
            stand.GetAllItems(newClient);
            StockNUD.Maximum = type[id].Quantity;
        }
        public void UpdateListMethod()
        {
            ListItems.Items.Clear();
            foreach (Item item in newClient.RequestItems())
            {
                ListItems.Items.Add(item.AsString());
            }
        }
        #endregion
        private void CategoryCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItemByType(CategoryCb.SelectedIndex);
        }

        private void ItemCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = ItemCb.SelectedIndex;
            LoadQuantityByItem(id);
        }
        
        private void LoanBtn_Click(object sender, EventArgs e)
        {
            //yet to be implemented
        } 
    }
}
