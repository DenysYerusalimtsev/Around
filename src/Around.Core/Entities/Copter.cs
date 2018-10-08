using Around.Core.Enums;

namespace Around.Core.Entities
{
    public class Copter
    {
        public int Id { get; }

        public string Name { get; }

        public Brand Brand { get; }

        public DroneType DroneType { get; }

        public Characteristics Characteristics { get; }

        public Equipment Equipment { get; }

        public Camera Camera { get; }

        public RemoteControl RemoteControl { get; }

        public Aircraft Aircraft { get; }

        public Modes Modes { get; }

        public LoadCapacity LoadCapacity { get;}

        public TransportCharacteristics TransportCharacteristics { get; }

        public Battery Battery { get; }
    }
}
