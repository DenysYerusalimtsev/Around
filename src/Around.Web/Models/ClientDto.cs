using Around.Core.Entities;

namespace Around.Web.Models
{
    public class ClientDto
    {
        public ClientDto(Client client)
        {
            Id = client.Id;
            Email = client.Email;
            Password = client.Password;
            PhoneNumber = client.PhoneNumber;
            PassportNumber = client.Passport.RecordNumber;
            CreditCardNumber = client.CreditCardNumber;
            DiscountPercentage = client.Discount.Percentage;
        }

        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string PassportNumber { get; set; }

        public string CreditCardNumber { get; set; }

        public double DiscountPercentage { get; set; }
    }
}
