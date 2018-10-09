namespace Around.Core.Entities
{
    public class Equipment
    {
        public int Id { get; set; }

        public bool HasGps { get; set; }

        public int InternalMemory { get; set; }

        public bool HasMemoryCardSupport { get; set; }

        public bool HasGyroscope { get; set; }

        public bool HasMagnetometer { get; set; }

        public bool HasAccelerometer { get; set; }

        public bool HasBarometer { get; set; }

        public virtual Copter Copter { get; set; }
    }
}
