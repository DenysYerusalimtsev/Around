using System.Collections.Generic;
using Around.Core.Enums;

namespace Around.Core.Entities
{
    public class Copter
    {
        public Copter()
        {
        }

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

        public virtual List<Rent> Rents { get; set; }

        public virtual FullCharacteristics FullCharacteristics { get; set; }

        public Copter CreateFromDto(CopterAggregate copter)
        {
            Name = copter.Name;
            Status = (Status)copter.Status;
            Latitude = copter.Latitude;
            Longitude = copter.Longitude;
            CostPerMinute = copter.CostPerMinute;
            BrandId = copter.BrandId;
            MaxSpeed = copter.MaxSpeed;
            MaxFlightHeight = copter.MaxFlightHeight;
            Control = (Control)copter.Control;
            DroneType = (DroneType)copter.DroneType;

            return this;
        }

        public Copter Update(Copter newCopter)
        {
            Name = newCopter.Name;
            Status = newCopter.Status;
            Latitude = newCopter.Latitude;
            Longitude = newCopter.Longitude;
            CostPerMinute = newCopter.CostPerMinute;
            BrandId = newCopter.BrandId;
            MaxSpeed = newCopter.MaxSpeed;
            MaxFlightHeight = newCopter.MaxFlightHeight;
            Control = newCopter.Control;
            DroneType = newCopter.DroneType;

            return this;
        }
    }
}
