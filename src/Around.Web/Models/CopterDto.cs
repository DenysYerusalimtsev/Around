using Around.Core.Entities;

namespace Around.Web.Models
{
    public class CopterDto
    {
        public CopterDto(Copter copter)
        {
            Id = copter.Id;
            Name = copter.Name;
            Status = copter.Status.ToString();
            Latitude = copter.Latitude;
            Longitude = copter.Longitude;
            CostPerMinute = copter.CostPerMinute;
            BrandName = copter.Brand.Name;
            MaxSpeed = copter.MaxSpeed;
            MaxFlightHeight = copter.MaxFlightHeight;
            DroneType = copter.DroneType.ToString();
            Control = copter.Control.ToString();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double CostPerMinute { get; set; }

        public string BrandName { get; set; }

        public string DroneType { get; set; }

        public double MaxSpeed { get; set; }

        public double MaxFlightHeight { get; set; }

        public string Control { get; set; }
    }
}
