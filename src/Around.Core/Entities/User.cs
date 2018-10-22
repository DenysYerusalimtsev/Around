namespace Around.Core.Entities
{
    public abstract class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public int PassportId { get; set; }

        public string CreditCardNumber { get; set; }

        public int DiscountId { get; set; }

        public virtual Passport Passport { get; set; }

        public virtual List<CreditCard> CreditCards { get; set; }

        public virtual Discount Discount { get; set; }

        public virtual List<Rent> Rent { get; set; }
    }
}
