using System.Collections.Generic;
using System.Threading.Tasks;
using Around.Core.Entities;
using Around.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Around.DataAccess.SqlServer.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private DronesharingContext _context;

        public CountryRepository(DronesharingContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> GetAllAsync()
        {
            return await _context.Countries.ToListAsync(); 
        }

        public async Task<Country> Get(string code)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.Code == code);
        }

        public void Create(Country country)
        {
            _context.Countries.Add(country);
            _context.SaveChanges();
        }

        public void Update(Country country)
        {
            _context.Countries.Update(country);
            _context.SaveChanges();
        }

        public List<Country> Search(string search)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string code)
        {
            var country = _context.Countries.Find(code);
            if (country != null)
                _context.Countries.Remove(country);
            _context.SaveChanges();
        }
    }
}
