namespace Around.Core.Entities
{
    public class CopterAggregate
    {
        public string Name { get; set; }

        public int Status { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double CostPerMinute { get; set; }

        public int BrandId { get; set; }

        public double MaxSpeed { get; set; }

        public double MaxFlightHeight { get; set; }

        public int Control { get; set; }

        public int DroneType { get; set; }
    }
}
