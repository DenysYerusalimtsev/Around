using System.Collections.Generic;
using System.Threading.Tasks;
using Around.Core.Entities;

namespace Around.Core.Interfaces
{
    public interface IRentRepository
    {
        Task<List<Rent>> GetAllAsync();

        Task<Rent> Get(int id);

        void Create(Rent rent);

        void Update(Rent rent);

        List<Rent> Search(string search);

        void Delete(int id);
    }
}
