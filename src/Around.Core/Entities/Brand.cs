using System.Collections.Generic;

namespace Around.Core.Entities
{
    public class Brand
    {
        public Brand(string name, string countryCode)
        {
            Name = name;
            CountryCode = countryCode;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string CountryCode { get; set; }

        public virtual Country Country { get; set; }

        public virtual List<Copter> Copters { get; set; }
    }
}
