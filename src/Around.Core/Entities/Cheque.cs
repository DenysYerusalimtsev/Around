using System;

namespace Around.Core.Entities
{
    public class Cheque
    {
        public int Id { get; set; }

        public int RentId { get; set; }

        public DateTime DateOfCreation { get; set; }

        public double TotalPrice { get; set; }

        public virtual Rent Rent { get; set; }

        public Cheque CreateFromDto(ChequeAggregate cheque)
        {
            RentId = cheque.RentId;
            DateOfCreation = DateTime.Now;
            TotalPrice = Rent.Copter.CostPerMinute * (DateOfCreation - Rent.StartTime).Minutes;

            return this;
        }
    }
}
