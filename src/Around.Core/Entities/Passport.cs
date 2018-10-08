using System;

namespace Around.Core.Entities
{
    public class Passport
    {
        public int Id { get; }

        public int RecordNumber { get; }

        public string FirstName { get; }

        public string LastNane { get; }

        public string Nationality { get; }

        public string BirthPlace { get; }

        public DateTime FromDate { get; }

        public DateTime ToDate { get; }

        public string TechnicalCenter { get; }

        public string Snapshot { get; }
    }
}
