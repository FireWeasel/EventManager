using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication
{
    public class User
    {
        private long id;
        private string username;
        private string email;
        private string userRole;
        public User() { }
        public User(long id, string username, string email, string userRole)
        {
            this.id = id;
            this.username = username;
            this.email = email;
            this.userRole = userRole;
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
