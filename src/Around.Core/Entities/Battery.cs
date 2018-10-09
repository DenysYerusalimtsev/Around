namespace Around.Core.Entities
{
    public class Battery
    {
        public int Id { get; }

        public double ChargingSpeed { get; }

        public double Capacity { get; }

        public virtual  Copter Copter { get;set; }
    }
}
