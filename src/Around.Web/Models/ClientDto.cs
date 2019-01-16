using Around.Core.Entities;

namespace Around.Web.Models
{
    public class ClientDto
    {
        public ClientDto(Client client)
        {
            Id = client.Id;
            FirstName = client.FirstName;
            LastName = client.LastName;
            Email = client.Email;
            PhoneNumber = client.PhoneNumber;
            Discount = client.Discount.Type;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Discount { get; set; }
    }
}
