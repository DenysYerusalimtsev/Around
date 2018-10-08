using System;

namespace Around.Core.Entities
{
    public class Rent
    {
        public int Id { get; }

        public int UserId { get; }

        public int DroneId { get; }

        public DateTime StartTime { get; }

        public  DateTime FinishTime { get; }
    }
}
