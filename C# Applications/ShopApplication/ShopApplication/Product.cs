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
        private String type;
        private Shop shop;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public String Description
        {
            get { return description; }
            set { description = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if (value<0)
                {
                    quantity = 0;
                }
                else
                {
                    quantity = value;
                }
            }
        } // can't get below 0
        public int NrInOrder { get; set; }
        public String Type
        {
            get { return type; }
            set { type = value; }
        }

        public Shop Shop
        {
            get { return shop; }
            set { shop = value; }
        }


        public Product() { }

        public Product(String name, String description, double price, int quantity, ProductType type)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Quantity = quantity;
            this.Type = type.ToString();
        }

        public override string ToString()
        {
            return this.Name;
        }
        public String AsString()
        {
            return this.Name + " --- Price for one: " + this.Price + " euros --- Quantity : ";
        }
    }
}
