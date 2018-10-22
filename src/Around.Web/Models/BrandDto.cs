using Around.Core.Entities;

namespace Around.Web.Models
{
    public class BrandDto
    {
        public BrandDto(Brand brand)
        {
            Id = brand.Id;
            Name = brand.Name;
            Country = brand.Country.CountryName;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }
    }
}
