using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication
{
    public class Product
    {
        //todo tickets and list of tickets
        private long id;
        private String name;
        private String description;
        private double price;
        private int quantity;
        private ProductType type;
        private Shop shop;

        public long Id { get { return id; } }
        public String Name { get { return name; } }
        public String Description { get { return description; } }
        public double Price { get { return price; } }
        public ProductType Type { get { return type; } }

        public Shop Shop { get { return shop; } }


        public Product() { }

        public Product(long id, String name, String description, double price, int quantity, ProductType type, Shop shop)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.price = price;
            this.quantity = quantity;
            this.type = type;
            this.shop = shop;
        }
    }
}
