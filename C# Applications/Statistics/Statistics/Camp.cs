using System;

namespace Statistics
{
    public class Camp
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public double Price { get; set; }
        public bool CheckedIn { get; set; }
        public int ReservationId { get; set; }

        public Camp() { }
    }
}
