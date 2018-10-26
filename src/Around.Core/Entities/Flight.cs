namespace Around.Core.Entities
{
    public class Flight
    {
        public int Id { get; set; }

        public double LiftingSpeed { get; set; }

        public double DescentSpeed { get; set; }

        public double MaximumHeight { get; set; }

        public double MaximumSpeed { get; set; }

        public double MinimumSpeed { get; set; }

        public double FlightTime { get; set; }

        public virtual FullCharacteristics FullCharacteristics { get; set; }
    }
}
