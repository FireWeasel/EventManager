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
