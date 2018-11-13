using Around.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Around.Core.Interfaces
{
    public interface IBrandRepository
    {
        Task<List<Brand>> GetAllAsync();

        Task<Brand> Get(int id);

        void Create(Brand brand);

        void Update(int id, Brand brand);

        List<Brand> Search(string search);

        void Delete(int id);
    }
}
