using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampingApplication
{
    public class User
    {
        private long id;
        private string username;
        private string email;
        private string userRole;
        private Reservation reservation;


        public User() { }
        public User(long id,string username, string email,string userRole, Reservation reservation)
        {
            this.id = id;
            this.username = username;
            this.email = email;
            this.userRole = userRole;
            this.reservation = reservation;
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
        public Reservation Reservation
        {
            get
            {
                return reservation;
            }

            set
            {
                reservation = value;
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

        public string UserRole
        {
            get
            {
                return userRole;
            }

            set
            {
                userRole = value;
            }
        }
    }
}
