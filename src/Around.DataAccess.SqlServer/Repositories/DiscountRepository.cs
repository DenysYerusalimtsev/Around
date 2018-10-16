using System.Collections.Generic;
using System.Threading.Tasks;
using Around.Core.Entities;
using Around.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Around.DataAccess.SqlServer.Repositories
{
    public class DiscountRepository: IDiscountRepository
    {
        private DronesharingContext _context;

        public DiscountRepository(DronesharingContext context)
        {
            _context = context;
        }

        public Task<List<Discount>> GetAllAsync()
        {
            return _context.Discounts.ToListAsync();
        }

        public async Task<Discount> Get(int id)
        {
            return await _context.Discounts.FirstOrDefaultAsync(d => d.Id == id);
        }

        public void Create(Discount discount)
        {
            _context.Discounts.Add(discount);
        }

        public void Update(Discount discount)
        {
            _context.Discounts.Update(discount);
        }

        public List<Discount> Search(string search)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            var discount = _context.Discounts.Find(id);
            if (discount != null)
                _context.Discounts.Remove(discount);
        }
    }
}
