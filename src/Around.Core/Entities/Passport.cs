using Around.Core.Enums;
using System;

namespace Around.Core.Entities
{
    public class Passport
    {
        public int Id { get; set; }

        public string RecordNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Nationality { get; set; }

        public string BirthPlace { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public Sex Sex { get; set; }

        public string TechnicalCenter { get; set; }

        public string Snapshot { get; set; }

        public virtual Client Client { get; set; }
    }
}
