using Around.Core.Enums;

namespace Around.Core.Entities
{
    public class Copter
    {
        public int Id { get; }

        public string Name { get; }

        public int BrandId { get; }

        public virtual Brand Brand { get; }

        public DroneType DroneType { get; }

        public int CharacteristicId { get; }

        public virtual Characteristics Characteristics { get; }

        public int EquipmentId { get; }

        public virtual Equipment Equipment { get; }

        public int CameraId { get; }

        public virtual Camera Camera { get; }

        public int RemoteControlId { get; }

        public virtual RemoteControl RemoteControl { get; }

        public int AircraftId { get; }

        public virtual Aircraft Aircraft { get; }

        public int ModesId { get; }

        public virtual Modes Modes { get; }

        public int LoadCapacityId { get; }

        public virtual LoadCapacity LoadCapacity { get;}

        public int TransportCharacteristicsId { get; }

        public virtual TransportCharacteristics TransportCharacteristics { get; }

        public int BatteryId { get; }

        public virtual Battery Battery { get; }
    }
}
