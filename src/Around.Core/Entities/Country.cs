namespace Around.Core.Entities
{
    public class Country
    {
        public string Code { get; }

        public string CountryName { get; }

        public virtual Brand Brand { get; set; }
    }
}
