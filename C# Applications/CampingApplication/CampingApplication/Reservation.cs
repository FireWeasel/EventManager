using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampingApplication
{
    public class Reservation
    {
        private long id;
        private bool paid;

        public Reservation() { }
        public Reservation(long id, bool paid)
        {
            this.id = id;
            this.paid = paid;
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
        public bool Paid
        {
            get
            {
                return paid;
            }

            set
            {
                paid = value;
            }
        }
        public override string ToString()
        {
            return "reservation id: " + this.Id + ". Bool paid - " + this.Paid;
        }
    }
}
