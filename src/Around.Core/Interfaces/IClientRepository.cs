using Around.Core.Entities;
using System.Collections.Generic;

namespace Around.Core.Interfaces
{
    public interface IClientRepository
    {
        List<Client> GetAll();

        Client Get(int id);

        void Create(Client client);

        void Update(Client client);

        List<Client> Search(string search);

        void Delete(int id);
    }
}
