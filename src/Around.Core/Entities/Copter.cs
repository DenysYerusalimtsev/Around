using System.Net.NetworkInformation;
using Around.Core.Enums;

namespace Around.Core.Entities
{
    public class Copter
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BrandId { get; set; }

        public double MaxSpeed { get; set; }

        public double MaxFlightHeight { get; set; }

        public Control Control { get; set; }

        public DroneType DroneType { get; set; }
    }
}
