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
        public List<Item> GetAllItems(RestClient client)
        {
            Items = client.RequestItems();
            return Items;
        }
        public int GetId()
        {
            return Id;
        }
    }
}

