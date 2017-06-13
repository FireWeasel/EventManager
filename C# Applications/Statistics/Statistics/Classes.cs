using System;
using System.Collections.Generic;
namespace Statistics
{
    public enum ProductType
    {
        FOODS,
        DRINKS,
        OTHER
    }
    public enum Type
    {
        ELECTRONICS,
        OTHER
    }
    public enum Role
    {
        USER,
        EMPLOYEE
    }
    public class Classes
    {
        #region Fields and properties
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
        #endregion
        #region Constructor and methods
        public Classes() { }

        public override string ToString()
        {
            return this.Name;
        }
        public String AsString()
        {
            return this.Name + " --- Price for one: " + this.Price + " euros --- Quantity : ";
        }
        #endregion
    }
    public class Loan_Stand
    {
        #region Properties and constructor
        public int Id { get; set; }
        public double Revenue { get; set; }
        public Loan_Stand()
        {

        }
        #endregion
    }
    public class Item
    {
        public int ID { get; set; }
        public Type Type { get; set; }
        public Item()
        {
        }
    }
    public class Shop
    {
        private long id;
        private double revenue;
        private List<Classes> products;

        public long Id { get { return id; } set { id = value; } }

        public double Revenue { get { return revenue; } set { revenue = value; } }

        public List<Classes> Products { get { return products; } set { products = value; } }

        public Shop() { }

    }
    public class Camp
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public double Price { get; set; }
        public bool CheckedIn { get; set; }
        public int ReservationId { get; set; }

        public Camp() { }
    }
    public class User
    {
        private long id;
        private string username;
        private string email;
        public Role UserRole { get; set; }
        public User() { }
        public long Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }
    }
    public class Ticket
    {
        public int ID { get; set; }
        public double Balance { get; set; }
        public bool CheckedIn { get; set; }
        public bool CheckedOut { get; set; }
        public int OnerId { get; set; }
        public Ticket()
        {

        }
    }
}
