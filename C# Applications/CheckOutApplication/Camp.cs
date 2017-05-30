namespace CheckOut
{
    public class Camp
    {
        private long id;
        private string name;
        private string description;
        private double price;
        private bool checkedIn;

        public Camp() { }

        public Camp(long id, string name, string description, double price, bool checkedIn)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.price = price;
            this.checkedIn = checkedIn;
        }
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

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public bool CheckedIn
        {
            get
            {
                return checkedIn;
            }

            set
            {
                checkedIn = value;
            }
        }

        
    }
}
