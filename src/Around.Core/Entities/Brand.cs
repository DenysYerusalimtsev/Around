namespace Around.Core.Entities
{
    public class Brand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual Copter Copter { get; set; }
    }
}
