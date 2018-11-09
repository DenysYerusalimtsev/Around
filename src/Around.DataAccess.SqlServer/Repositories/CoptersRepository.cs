 using System.Collections.Generic;
 using System.Threading.Tasks;
 using Around.Core.Entities;
 using Around.Core.Interfaces;
 using Microsoft.EntityFrameworkCore;

namespace Around.DataAccess.SqlServer.Repositories
{
    public class CoptersRepository : ICopterRepository
    {
        private DronesharingContext _context;

        public CoptersRepository(DronesharingContext context)
        {
            _context = context;
        }

        public async Task<List<Copter>> GetAllAsync()
        {
            return await _context.Copters
                .Include(c => c.Brand)
                .ToListAsync();
        }

        public async Task<Copter> Get(int id)
        {
            return await _context.Copters
                .Include(c => c.Brand)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public void Create(Copter copter)
        {
            _context.Copters.Add(copter);
        }

        public void Update(Copter copter)
        {
            _context.Copters.Update(copter);
        }

        public List<Copter> Search(string search)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            var copter = _context.Copters.Find(id);
            if (copter != null)
                _context.Copters.Remove(copter);
        }
    }
}
