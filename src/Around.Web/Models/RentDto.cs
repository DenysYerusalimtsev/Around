using System;
using Around.Core.Entities;

namespace Around.Web.Models
{
    public class RentDto
    {
        public RentDto(Rent rent)
        {
            Id = rent.Id;
            ClientName = $"{rent.Client.FirstName} " +
                         $"{rent.Client.LastName}";
            CopterBrand = rent.Copter.Brand.Name;
            CopterName = rent.Copter.Name;
            StartTime = rent.StartTime;
        }

        public int Id { get; set; }

        public string ClientName { get; set; }

        public string CopterBrand { get; set; }

        public string CopterName { get; set; }

        public DateTime StartTime { get; set; }
    }
}
