using System.Collections.Generic;
using System.Threading.Tasks;
using Around.Core.Entities;

namespace Around.Core.Interfaces
{
    public interface IChequeRepository
    {
        Task<List<Cheque>> GetAllAsync();

        Task<Cheque> Get(int id);

        void Create(Cheque brand);

        void Update(Cheque brand);

        List<Cheque> Search(string search);

        void Delete(int id);
    }
}
