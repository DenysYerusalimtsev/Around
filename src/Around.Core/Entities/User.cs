using System.Collections.Generic;

namespace Around.Core.Entities
{
    public abstract class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string PhoneNumber { get; set; }
    }
}
