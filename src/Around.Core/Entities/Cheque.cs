using System;

namespace Around.Core.Entities
{
    public class Cheque
    {
        public int Id { get; }

        public int RentId { get; }

        public DateTime DateOfCreation { get; }

        public decimal TotalPrice { get; }

        public virtual Rent Rent { get; }
    }
}
