using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics
{
    public class Shop
    {
        private long id;
        private double revenue;
        private List<Product> products;

        public long Id { get { return id; } set { id = value; } }

        public double Revenue { get { return revenue; } set { revenue = value; } }

        public List<Product> Products { get { return products; } set { products = value; } }

        public Shop() { }
        
        public Shop(long id, double revenue)
        {
            this.id = id;
            this.revenue = revenue;
        }



    }
}
