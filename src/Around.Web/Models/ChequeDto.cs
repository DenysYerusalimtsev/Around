using System;
using Around.Core.Entities;

namespace Around.Web.Models
{
    public class ChequeDto
    {
        public ChequeDto(Cheque cheque)
        {
            Id = cheque.Id;
            ClientName = $"{cheque.Rent.Client.Passport.FirstName} " +
                         $"{cheque.Rent.Client.Passport.LastName}";
            CopterBrand = cheque.Rent.Copter.Brand.Name;
            CopterName = cheque.Rent.Copter.Name;
            StartTime = cheque.Rent.StartTime;
            FinishTime = cheque.Rent.FinishTime;
            DateOfCreation = cheque.DateOfCreation;
            TotalPrice = cheque.TotalPrice;
        }

        public int Id { get; set; }

        public string ClientName { get; set; }

        public string CopterBrand { get; set; }

        public string CopterName { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime FinishTime { get; set; }

        public DateTime DateOfCreation { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
