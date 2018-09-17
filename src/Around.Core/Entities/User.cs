using System;

namespace Around.Core.Entities
{
    public abstract class User
    {
        public int Id { get; }

        public string FirstName { get; }

        public string LastNane { get; }

        public int Age { get; }

        public Enum Sex { get; }

        public DateTime DateOfBirth { get; }

        public string Email { get; }

        public string PhoneNumber { get; }
    }
}
