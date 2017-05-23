using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics
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
        public List<Type> GetElectronics()
        {
            List<Type> electronics = new List<Type>();
            foreach(Item item in Items)
            {
                if(item.Type == Type.ELECTRONICS)
                {
                    electronics.Add(item.Type);
                }
            }
            return electronics;
        }
        public List<int> GetItemId(RestClient client)
        {
            Items = GetAllItems(client);
            List<int> ItemId = new List<int>();
            foreach(Item item in Items)
            {
                ItemId.Add(item.ID);
            }
            return ItemId;
        }
    }
}

