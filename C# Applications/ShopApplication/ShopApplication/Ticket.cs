using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication
{
    public class Ticket
    {
        private long id;
        private bool checkedIn;
        private bool checkedOut;
        private double balance;
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

        public bool CheckedOut
        {
            get
            {
                return checkedOut;
            }

            set
            {
                checkedOut = value;
            }
        }

        public double Balance
        {
            get
            {
                return balance;
            }

            set
            {
                balance = value;
            }
        }

        public Ticket() { }
        public Ticket(long id, bool checkedIn, bool checkedOut, double balance)
        {
            this.id = id;
            this.checkedIn = checkedIn;
            this.checkedOut = checkedOut;
            this.balance = balance;
        }
        public override string ToString()
        {
            return this.balance.ToString();
        }
    }
}
