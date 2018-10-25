namespace Around.Core.Entities
{
    public class Battery
    {
        public int Id { get; set; }

        public double ChargingSpeed { get; set; }

        public double Capacity { get; set; }

        public virtual FullCharacteristics FullCharacteristics { get;set; }
    }
}
