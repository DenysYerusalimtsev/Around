using System.Collections.Generic;
using System.Threading.Tasks;
using Around.Core.Entities;
using Around.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Around.DataAccess.SqlServer.Repositories
{
    public class RentRepository : IRentRepository
    {
        private readonly DronesharingContext _context;

        public RentRepository(DronesharingContext context)
        {
            _context = context;
        }

        public async Task<List<Rent>> GetAllAsync()
        {
            return await _context.Rents
                .Include(x => x.Copter)
                .ThenInclude(c => c.Brand)
                .Include(x => x.Client)
                .ToListAsync();
        }

        public async Task<Rent> Get(int id)
        {
            return await _context.Rents.FirstOrDefaultAsync(r => r.Id == id);
        }

        public void Create(Rent rent)
        {
            _context.Rents.Add(rent);
            _context.SaveChanges();
        }

        public void Update(Rent rent)
        {
            _context.Rents.Update(rent);
            _context.SaveChanges();
        }

        public List<Rent> Search(string search)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            var rent = _context.Rents.Find(id);
            if (rent != null)
                _context.Rents.Remove(rent);
            _context.SaveChanges();
        }
    }
}
