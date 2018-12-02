namespace Around.Core.Entities
{
    public class ClientAggregate
    {
        public ClientAggregate(Client client)
        {
            Id = client.Id;
            FirstName = client.FirstName;
            LastName = client.LastName;
            Email = client.Email;
            PhoneNumber = client.PhoneNumber;
            PassportNumber = client.Passport.Id;
            CreditCardNumber = client.CreditCardNumber;
            DiscountId = client.Discount.Id;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string PassportNumber { get; set; }

        public string CreditCardNumber { get; set; }

        public int DiscountId { get; set; }
    }
}
