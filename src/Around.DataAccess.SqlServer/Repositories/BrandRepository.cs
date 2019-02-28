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

        public int Create(Brand brand)
        {
            _context.Brands.Add(brand);
            _context.SaveChanges();

            return brand.Id;
        }

        public void Delete(int id)
        {
            var brand = _context.Brands.Find(id);
            if (brand != null)
                _context.Brands.Remove(brand);
            _context.SaveChanges();
        }

        public async Task<Brand> Get(int id)
        {
            return await _context.Brands
                .Include(b => b.Country)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<Brand>> GetAllAsync()
        {
            return await _context.Brands
                .Include(b => b.Country)
                .ToListAsync();
        }

        public List<Brand> Search(string search)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, Brand brand)
        {
            var existedBrand = _context.Brands.Find(id);
            if (existedBrand != null)
            {
                existedBrand.Update(brand);
                _context.Brands.Update(existedBrand);
            }

            _context.SaveChanges();
        }
    }
}
