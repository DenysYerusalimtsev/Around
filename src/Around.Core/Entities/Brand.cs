namespace Around.Core.Entities
{
    public class Brand
    {
        public int Id { get; }

        public string Name { get; }

        public int CountryId { get; }

        public virtual Country Country { get; }

        public virtual Copter Copter { get; set; }
    }
}
