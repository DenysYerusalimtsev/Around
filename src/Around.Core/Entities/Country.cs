using System.Collections.Generic;

namespace Around.Core.Entities
{
    public class Country
    {
        public string Code { get; set; }

        public string CountryName { get; set; }

        public virtual List<Brand> Brands { get; set; }
    }
}
