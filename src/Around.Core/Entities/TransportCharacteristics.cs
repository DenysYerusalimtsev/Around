namespace Around.Core.Entities
{
    public class TransportCharacteristics
    {
        public int Id { get; }

        public bool HasAutopilot { get; }

        public int SeatCount { get; }

        public bool HasAirbag { get; }

        public virtual Copter Copter { get; set; }
    }
}
