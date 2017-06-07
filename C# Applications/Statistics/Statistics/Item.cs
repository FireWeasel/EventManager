namespace Statistics
{
    public enum Type
    {
        ELECTRONICS ,
        OTHER 
    }

        public class Item
    {
        public int ID { get; set; }
        public Type Type { get; set; }
        public Item()
        {
        } 
    }
}
