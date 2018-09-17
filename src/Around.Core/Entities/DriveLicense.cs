using System;

namespace Around.Core.Entities
{
    public class DriveLicense
    {
        public int Id { get; }

        public string FirstName { get; }

        public string LastNane { get; }

        public string City { get; }

        public DateTime FromDate { get; }

        public DateTime ToDate { get; }

        public string TechnicalCenter { get; }

        public string Snapshot { get; }
    }
}
