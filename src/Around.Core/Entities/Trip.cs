using System;
using System.Data;

namespace Around.Core.Entities
{
    public class Trip
    {
        public int Id { get; }

        public int UserId { get; }

        public int CarId { get; }

        public DateTime StartTime { get; }

        public  DateTime FinishTime { get; }
    }
}
