namespace Around.Core.Entities
{
    public class Equipment
    {
        public int Id { get; }

        public bool HasGps { get; }

        public int InternalMemory { get; }

        public bool HasMemoryCardSupport { get; }

        public bool HasGyroscope { get; }

        public bool HasMagnetometer { get; }

        public bool HasAccelerometer { get; }

        public bool HasBarometer { get; }

        public virtual Copter Copter { get; set; }
    }
}
