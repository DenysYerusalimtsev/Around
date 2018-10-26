using Around.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Around.Web.Models
{
    public class CopterDto
    {
        public CopterDto(Copter copter)
        {
            Id = copter.Id;
            Name = copter.Name;
            BrandName = copter.Brand.Name;
            MaxSpeed = copter.FullCharacteristics.Flight.MaximumSpeed;
            MaxFlightHeight = copter.MaxFlightHeight;
            DroneType = copter.DroneType.ToString();
            Control = copter.Control.ToString();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string BrandName { get; set; }

        public string DroneType { get; set; }

        public double MaxSpeed { get; set; }

        public double MaxFlightHeight { get; set; }

        public string Control { get; set; }
    }
}
