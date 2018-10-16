using System.Collections.Generic;
using System.Threading.Tasks;
using Around.Core.Entities;

namespace Around.Core.Interfaces
{
    public interface IDiscountRepository
    {
        Task<List<Discount>> GetAllAsync();

        Task<Discount> Get(int id);

        void Create(Discount discount);

        void Update(Discount discount);

        List<Discount> Search(string search);

        void Delete(int id);
    }
}
