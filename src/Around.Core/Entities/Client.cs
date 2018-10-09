using System.Collections.Generic;

namespace Around.Core.Entities
{
    public class Client : User
    {
        public int PassportId { get; }

        public Passport Passport { get; }

        public string CreditCardNumber { get; }

        public int DiscountId { get; }

        public virtual List<CreditCard> CreditCards { get; }

        public virtual Discount Discount { get; }
    }
}
