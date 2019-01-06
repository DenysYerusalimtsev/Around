using Around.Core.Entities;

namespace Around.Web.Models
{
    public class ClientDto
    {
        public ClientDto(Client client)
        {
            Id = client.Id;
            Email = client.Email;
            PhoneNumber = client.PhoneNumber;
            DiscountPercentage = client.Discount.Percentage;
        }

        public int Id { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public double DiscountPercentage { get; set; }
    }
}
