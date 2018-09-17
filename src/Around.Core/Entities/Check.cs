using System;

namespace Around.Core.Entities
{
    public class Check
    {
        public int Id { get; }

        public Trip Trip { get; }

        public DateTime DateOfCreation { get; }

        public decimal TotalPrice { get; }
    }
}
