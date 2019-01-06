using System.Collections.Generic;

namespace Around.Core.Entities
{
    public class Client
    {
        public Client()
        {
        }

        public Client(ClientAggregate clientAggregate)
        {
            FirstName = clientAggregate.FirstName;
            LastName = clientAggregate.LastName;
            Email = clientAggregate.Email;
            PhoneNumber = clientAggregate.PhoneNumber;
            DiscountId = clientAggregate.DiscountId;
            CreditCard = clientAggregate.CreditCardNumber;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string PhoneNumber { get; set; }

        public int DiscountId { get; set; }

        public string CreditCard { get; set; }

        public virtual List<CreditCard> CreditCards { get; set; }

        public virtual Discount Discount { get; set; }

        public virtual List<Rent> Rent { get; set; }

        public Client Update(ClientAggregate clientAggregate)
        {
            FirstName = clientAggregate.FirstName;
            LastName = clientAggregate.LastName;
            Email = clientAggregate.Email;
            PhoneNumber = clientAggregate.PhoneNumber;
            DiscountId = clientAggregate.DiscountId;
            CreditCard = clientAggregate.CreditCardNumber;

            return this;
        }
    }
}
