namespace Around.Core.Entities
{
    public abstract class User
    {
        public int Id { get; }

        public string Email { get; }

        public string Password { get; set; }

        public string PhoneNumber { get; }
    }
}
