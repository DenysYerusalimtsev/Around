using System;

namespace Around.Core.Entities
{
    public class Rent
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int CopterId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime FinishTime { get; set; }

        public virtual Client Client { get; set; }

        public virtual Copter Copter { get; set; }

        public virtual Cheque Cheque { get; set; }
    }
}
