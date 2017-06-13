using System.Collections.Generic;

namespace Rent_Items_Test
{
        public class Loan_Stand
    {
        #region Properties and constructor
        public int Id { get; set; }
        public double Revenue { get; set; }
        public RestClient Client { get; set; }
        public List<Item> Items {get;set;}
        public Loan_Stand()
        {

        }
        #endregion
    }
}

