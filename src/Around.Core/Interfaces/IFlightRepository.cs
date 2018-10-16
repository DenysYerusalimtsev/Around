using System.Collections.Generic;
using System.Threading.Tasks;
using Around.Core.Entities;

namespace Around.Core.Interfaces
{
    public interface IFlightRepository
    {
        Task<List<Flight>> GetAllAsync();

        Task<Flight> Get(int id);

        void Create(Flight flight);

        void Update(Flight flight);

        List<Cheque> Search(string search);

        void Delete(int id);
    }
}
