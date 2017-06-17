namespace CheckOut
{
    public enum Role
    {
        USER,
        EMPLOYEE
    }
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Role UserRole { get; set; }
        public User() { }
    }
}
