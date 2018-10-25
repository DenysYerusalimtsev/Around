namespace Around.Core.Entities
{
    public class Modes
    {
        public virtual int Id { get; set; }

        public bool HasTracking { get; set; }

        public bool HasTrick { get; set; }

        public bool HasReturnBase { get; set; }

        public bool HasCfmPositioning { get; set; }

        public bool HasFirstPersonView { get; set; }

        public virtual FullCharacteristics FullCharacteristics { get; set; }
    }
}
