using System.Collections.Generic;

namespace Around.Core.Entities
{
    public class Client : User
    {
        public int PassportId { get; set; }

        public string CreditCardNumber { get; set; }

        public int DiscountId { get; set; }

        public virtual Passport Passport { get; set; }

        public virtual List<CreditCard> CreditCards { get; set; }

        public virtual Discount Discount { get; set; }

        public virtual List<Rent> Rent { get; set; }

        public Client CreateFromDto(ClientAggregate client)
        {
            Id = client.Id;
            FirstName = client.FirstName;
            LastName = client.LastName;
            Email = client.Email;
            PhoneNumber = client.PhoneNumber;
            CreditCardNumber = client.CreditCardNumber;
            DiscountId = client.DiscountId;

            return this;
        }
    }
}
