namespace Around.Core.Entities
{
    public class Flight
    {
        public int Id { get; }

        public double LiftingSpeed { get; }

        public double DescentSpeed { get; }

        public double MaximumSpeed { get; }

        public double MinimumSpeed { get; }

        public double FlightTime { get; }

        public virtual Copter Copter { get; set; }
    }
}
