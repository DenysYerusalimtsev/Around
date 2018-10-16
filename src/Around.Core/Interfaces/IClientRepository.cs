using Around.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Around.Core.Interfaces
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAll();

        Task<Client> Get(int id);

        void Create(Client client);

        void Update(Client client);

        List<Client> Search(string search);

        void Delete(int id);
    }
}
