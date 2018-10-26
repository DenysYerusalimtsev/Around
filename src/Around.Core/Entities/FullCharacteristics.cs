namespace Around.Core.Entities
{
    public class FullCharacteristics
    {
        public int Id { get; set; }

        public int CharacteristicId { get; set; }

        public virtual int FlightId { get; set; }

        public int EquipmentId { get; set; }

        public int CameraId { get; set; }

        public int RemoteControlId { get; set; }

        public int AircraftId { get; set; }

        public int ModesId { get; set; }

        public int LoadCapacityId { get; set; }

        public int TransportCharacteristicsId { get; set; }

        public int BatteryId { get; set; }

        public virtual Flight Flight { get; set; }

        public virtual Characteristics Characteristics { get; set; }

        public virtual Camera Camera { get; set; }

        public virtual Equipment Equipment { get; set; }

        public virtual LoadCapacity LoadCapacity { get; set; }

        public virtual TransportCharacteristics TransportCharacteristics { get; set; }

        public virtual Modes Modes { get; set; }

        public virtual Aircraft Aircraft { get; set; }

        public virtual Battery Battery { get; set; }

        public virtual Copter Copter { get; set; }
    }
}
