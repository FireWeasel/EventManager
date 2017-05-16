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

namespace ShopApplication
{
    public partial class ShopForm : Form
    {
        Thread t;
        public ShopForm()
        {
            InitializeComponent();
            
            MessageBox.Show(LogInForm.rClient.GetRequest("http://localhost:8080/users/current"));
            List<Product> list = LogInForm.rClient.GetAllProducts();
            //foreach (Product p in list)
            //{
            //    lbOrder.Items.Add(p.Name);
            //}
        }



        private void ShopForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogInForm.rClient.GetRequest("http://localhost:8080/logout");
        }
        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(OpenAddProductForm);
            thread.Start();            
        }
        private void OpenAddProductForm()
        {
            Application.Run(new AddProductForm());
        }

        //shop class has revenue and id
        //product class has id,description,name,price,quantity,type and (shop_id)

    }
}
