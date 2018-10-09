using Around.Core.Enums;

namespace Around.Core.Entities
{
    public class Copter
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        public DroneType DroneType { get; set; }

        public int CharacteristicId { get; set; }

        public virtual Characteristics Characteristics { get; set; }

        public virtual int FlightId { get; set; }

        public virtual Flight Flight { get; set; }

        public int EquipmentId { get; set; }

        public virtual Equipment Equipment { get; set; }

        public int CameraId { get; set; }

        public virtual Camera Camera { get; set; }

        public int RemoteControlId { get; set; }

        public virtual RemoteControl RemoteControl { get; set; }

        public int AircraftId { get; set; }

        public virtual Aircraft Aircraft { get; set; }

        public int ModesId { get; set; }

        public virtual Modes Modes { get; set; }

        public int LoadCapacityId { get; set; }

        public virtual LoadCapacity LoadCapacity { get; set; }

        public int TransportCharacteristicsId { get; set; }

        public virtual TransportCharacteristics TransportCharacteristics { get; set; }

        public int BatteryId { get; set; }

        public virtual Battery Battery { get; set; }
    }
}
