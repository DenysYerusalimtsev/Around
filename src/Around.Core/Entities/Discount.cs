using System.Collections.Generic;

namespace Around.Core.Entities
{
    public class Discount
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public double Percentage { get; set; }

        public virtual List<Client> Client { get; set; }
    }
}
