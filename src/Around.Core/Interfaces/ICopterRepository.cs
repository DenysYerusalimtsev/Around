using System.Collections.Generic;
using System.Threading.Tasks;
using Around.Core.Entities;

namespace Around.Core.Interfaces
{
    public interface ICopterRepository
    {
        Task<List<Copter>> GetAllAsync();

        Task<Copter> Get(int id);

        int Create(Copter copter);

        void Update(int id, Copter copter);

        void UpdateStatus(int id);

        List<Copter> Search(string search);

        void Delete(int id);
    }
}
