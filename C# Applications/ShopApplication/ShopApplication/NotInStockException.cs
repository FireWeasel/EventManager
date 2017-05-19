using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication
{
    class NotInStockException : Exception
    {
        public NotInStockException() { }
        public NotInStockException(string message): base(message) { }

    }
}
