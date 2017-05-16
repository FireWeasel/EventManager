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
        #endregion
        #region Constructor
        public UpdateItem(RestClient newClient,Loan_Stand stand)
        {
            InitializeComponent();

            client = newClient;
            newStand = stand;

            foreach(Item item in newStand.Items)
            {
                IdNameCb.Items.Add(item.ID + " " + item.Name);
            }
        }
        #endregion
        private void AddItemBtn_Click(object sender, EventArgs e)
        {
            client.UpdateData(IdNameCb.SelectedIndex + 1,NameTb.Text,descTb.Text,Convert.ToDouble(feeNUD.Value),Convert.ToInt32(quantNUD.Value));

            NameTb.Clear();
            descTb.Clear();
            IdNameCb.SelectedIndex = -1;
            feeNUD.Value = 0;
            quantNUD.Value = 0;

            ActiveForm.Refresh();
        }
    }
}
