namespace Around.Core.Entities
{
    public class Client : User
    {
        public int PassportId { get; }

        public Passport Passport { get; }

        public string CreditCardNumber { get; }

        public int DiscountId { get; }

        public virtual CreditCard CreditCard { get; }

        public virtual Discount Discount { get; }
    }
}
