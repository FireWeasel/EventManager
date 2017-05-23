using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_Items_Test
{
    class User
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public int ReservationID { get; set; }
        public int UserRole { get; set; }
        public User()
        {

        }
    }
}
