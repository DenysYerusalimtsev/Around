namespace Around.Core.Entities
{
    public class LoadCapacity
    {
        public int Id { get; set; }

        public int LoadMountsCount { get; set; }

        public double MaximumWeight { get; set; }

        public virtual Copter Copter { get; set; }
    }
}
