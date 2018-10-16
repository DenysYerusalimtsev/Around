using System.Collections.Generic;
using System.Threading.Tasks;
using Around.Core.Entities;

namespace Around.Core.Interfaces
{
    public interface IAdminRepository
    {
        Task<List<Admin>> GetAllAsync();

        Task<Admin> Get(int id);

        void Create(Admin admin);

        void Update(Admin admin);

        List<Admin> Search(string search);

        void Delete(int id);
    }
}
