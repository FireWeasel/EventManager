using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampingApplication
{
    public class Ticket
    {
        private long ticketId;
        private bool checkedIn;
        private double balance;
        private long ownerId;

        public Ticket() { }
        public Ticket(long ticketId, bool checkedIn, double balance, long ownerId)
        {
            this.ticketId = ticketId;
            this.checkedIn = checkedIn;
            this.balance = balance;
            this.ownerId = ownerId;
        }

        public long TicketId
        {
            get
            {
                return ticketId;
            }

            set
            {
                ticketId = value;
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


        public override string ToString()
        {
            return "Ticket id : " + this.TicketId + ". Checked in - " + this.CheckedIn;
        }

    }
}
