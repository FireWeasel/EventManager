namespace Statistics
{
    public enum Role
    {
        USER,
        EMPLOYEE
    }
    public class User
    {
        private long id;
        private string username;
        private string email;
        public Role UserRole { get; set; }



        public User() { }
        public User(long id,string username, string email)
        {
            this.id = id;
            this.username = username;
            this.email = email;
        }

        public long Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }
    }
}
