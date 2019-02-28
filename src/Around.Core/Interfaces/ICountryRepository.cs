using System.Collections.Generic;
using System.Threading.Tasks;
using Around.Core.Entities;

namespace Around.Core.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllAsync();

        Task<Country> Get(string code);

        string Create(Country country);

        void Update(Country country);

        List<Country> Search(string search);

        void Delete(string code);
    }
}
