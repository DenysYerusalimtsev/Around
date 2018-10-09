namespace Around.Core.Entities
{
    public class TransportCharacteristics
    {
        public int Id { get; set; }

        public bool HasAutopilot { get; set; }

        public int SeatCount { get; set; }

        public bool HasAirbag { get; set; }

        public virtual Copter Copter { get; set; }
    }
}
