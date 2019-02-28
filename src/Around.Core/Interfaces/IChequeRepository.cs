using System.Collections.Generic;
using System.Threading.Tasks;
using Around.Core.Entities;

namespace Around.Core.Interfaces
{
    public interface IChequeRepository
    {
        Task<List<Cheque>> GetAllAsync();

        Task<Cheque> Get(int id);

        int Create(Cheque cheque);

        void Update(Cheque cheque);

        Cheque GetLast();

        Task<Cheque> GetLastAsync();

        List<Cheque> Search(string search);

        Task<Cheque> AddCost(int chequeId);

        void Delete(int id);
    }
}
