namespace Around.Core.Entities
{
    public class LoadCapacity
    {
        public int Id { get; }

        public int LoadMountsCount { get; }

        public double MaximumWeight { get; }

        public virtual Copter Copter { get; set; }
    }
}
