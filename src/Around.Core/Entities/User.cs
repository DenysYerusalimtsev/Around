using System.Collections.Generic;

namespace Around.Core.Entities
{
    public abstract class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public int PassportId { get; set; }

        public virtual Passport Passport { get; set; }
    }
}
