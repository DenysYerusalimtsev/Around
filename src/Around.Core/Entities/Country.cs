namespace Around.Core.Entities
{
    public class Country
    {
        public string Code { get; set; }

        public string CountryName { get; set; }

        public virtual int Id { get; set; }

        public virtual Brand Brand { get; set; }
    }
}
