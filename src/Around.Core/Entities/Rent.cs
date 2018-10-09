using System;

namespace Around.Core.Entities
{
    public class Rent
    {
        public int Id { get; }

        public int ClientId { get; }

        public int CopterId { get; }

        public DateTime StartTime { get; }

        public DateTime FinishTime { get; }

        public virtual Client Client { get; }

        public virtual Copter Copter { get; }

        public virtual Cheque Cheque { get; set; }
    }
}
