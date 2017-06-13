namespace Rent_Items_Test
{
    public enum Role
    {
        USER,
        EMPLOYEE
    }
    public class User
    {
        #region Properties and constructor
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public int ReservationID { get; set; }
        public Role UserRole { get; set; }
        public User()
        {

        }
        #endregion
    }
}
