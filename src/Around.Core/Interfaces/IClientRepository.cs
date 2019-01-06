using Around.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Around.Core.Interfaces
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAll();

        Task<Client> Get(int id);

        Task<Client> Get(string email);

        Task<bool> GetAny(string email);

        void Create(Client client);

        void Update(int id, Client client);

        List<Client> Search(string search);

        void Delete(int id);

        Task AddCreditCardAsync(CreditCard card, int userId);
    }
}
