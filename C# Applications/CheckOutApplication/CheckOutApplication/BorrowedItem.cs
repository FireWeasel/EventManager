using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut
{
    public class BorrowedItem
    {
        public int ID { get; set; }
        public bool Returned { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public BorrowedItem()
        {

        }
    }
}
