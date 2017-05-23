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
        RestClient newClient;
        Loan_Stand stand;
        List<Item> type;
        #endregion
        #region Constructor
        public MainApplication(RestClient client)
        {
            InitializeComponent();

            newClient = client;
            stand = newClient.GetLoanStand();

            foreach(Item item in stand.GetAllItems(newClient))
            {
                ListItems.Items.Add(item.AsString());
            }

            

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
            type = new List<Item>();
            ItemCb.Enabled = true;

            ListItems.Items.Clear();
            ItemCb.Items.Clear();

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
            double value = Convert.ToDouble(StockNUD.Value);
            double a = 0;
            try
            {
                Item item = type[ItemCb.SelectedIndex];
                foreach (Item it in stand.Items)
                {
                    if (it.Name == item.Name)
                    {
                        item = it;
                    }
                }

                while (a < value)
                {
                    newClient.BorrowItem(item.ID);
                    a++;
                }
                MessageBox.Show("The item has been processed!");
            }
            catch(Exception)
            {
                MessageBox.Show("Item not in stock");
            }
            UpdateListMethod();
            ItemCb.SelectedIndex = -1;
            CategoryCb.SelectedIndex = -1;
            StockNUD.Value = 0;
            
        } 
    }
}
