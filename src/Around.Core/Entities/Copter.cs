using System.Net.NetworkInformation;
using Around.Core.Enums;

namespace Around.Core.Entities
{
    public class Copter
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Status Status { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double CostPerMinute { get; set; }

        public int BrandId { get; set; }

        public double MaxSpeed { get; set; }

        public double MaxFlightHeight { get; set; }

        public Control Control { get; set; }

        public DroneType DroneType { get; set; }

        public int? FullCharacteristicsId { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual FullCharacteristics FullCharacteristics { get; set; }
    }
}
