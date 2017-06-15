using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckInApplication
{
    public class Ticket
    {
        private long id;
        private bool checkedIn;
        private double balance;
        private long ownerId;

        public Ticket() { }
        public Ticket(long ticketId, bool checkedIn, double balance, long ownerId)
        {
            this.id = ticketId;
            this.checkedIn = checkedIn;
            this.balance = balance;
            this.ownerId = ownerId;
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
        public long OwnerId
        {
            get
            {
                return ownerId;
            }

            set
            {
                ownerId = value;
            }
        }
    }
}
