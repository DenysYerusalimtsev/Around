using System.Threading.Tasks;
using Around.Core.Entities;

namespace Around.Core.Interfaces
{
    public interface IUserService
    {
        Client Authenticate(string username, string password);

        Task<Client> Create(ClientAggregate clientAggregate);

        Task Update(int id, ClientAggregate clientAggregate);

        Task<Client> GetById(int id);
    }
}
