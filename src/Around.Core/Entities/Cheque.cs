using System;

namespace Around.Core.Entities
{
    public class Cheque
    {
        public int Id { get; set; }

        public int RentId { get; set; }

        public DateTime DateOfCreation { get; set; }

        public decimal TotalPrice { get; set; }

        public virtual Rent Rent { get; set; }
    }
}
