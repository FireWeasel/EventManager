﻿namespace Statistics
{
    public class Ticket
    {
        public int ID { get; set; }
        public double Balance { get; set; }
        public bool CheckedIn { get; set; }
        public bool CheckedOut { get; set; }
        public int OnerId { get; set; }
        public Ticket()
        {

        }
    }
}