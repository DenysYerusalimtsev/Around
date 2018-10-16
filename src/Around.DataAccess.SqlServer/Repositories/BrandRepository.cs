using System.Collections.Generic;
using System.Threading.Tasks;
using Around.Core.Entities;
using Around.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Around.DataAccess.SqlServer.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private DronesharingContext _context;

        public BrandRepository(DronesharingContext context)
        {
            _context = context;
        }

        public void Create(Brand brand)
        {
            _context.Brands.Add(brand);
        }

        public void Delete(int id)
        {
            var brand = _context.Brands.Find(id);
            if (brand != null)
                _context.Brands.Remove(brand);
        }

        public async Task<Brand> Get(int id)
        {
            return await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<Brand>> GetAll()
        {
            return await _context.Brands.ToListAsync();
        }

        public List<Brand> Search(string search)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Brand brand)
        {
            _context.Brands.Update(brand);
        }
    }
}
