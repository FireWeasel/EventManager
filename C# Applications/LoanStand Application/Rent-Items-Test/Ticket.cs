namespace Rent_Items_Test
{
    public class Ticket
    {
        #region Fields and properties
        public int ID { get; set; }
        public double Balance { get; set; }
        public bool CheckedIn { get; set; }
        public bool CheckedOut { get; set; }
        public int OnerId { get; set; }
        #endregion
        #region Constructor and methods
        public Ticket()
        {

        }
        public string AsString()
        {
            return "ID: " + ID + " checkedIN: " + CheckedIn;
        }
        #endregion
    }
}