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
        #endregion
        #region Constructor
        public AddProduct(RestClient newClient, Loan_Stand stand)
        {
            InitializeComponent();

            newStand = stand;
            client = newClient;

            typeCb.Items.Add(Type.ELECTRONICS);
            typeCb.Items.Add(Type.OTHER);
        }
        #endregion
        private void AddItemBtn_Click(object sender, EventArgs e)
        {
            string name = nameTb.Text;
            string desciption = descTb.Text;
            double fee = Convert.ToDouble(feeNUD.Value);
            int quantity = Convert.ToInt32(quantNUD.Value);
            string type = typeCb.Text;

            client.AddData(newStand.Id,name, desciption, fee, quantity, type);

            ActiveForm.Refresh();
            nameTb.Clear();
            descTb.Clear();
            typeCb.SelectedIndex = -1;
            feeNUD.Value = 0;
            quantNUD.Value = 0;
        }
    }
}
