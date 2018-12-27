 using System.Collections.Generic;
 using System.Threading.Tasks;
 using Around.Core.Entities;
 using Around.Core.Enums;
 using Around.Core.Interfaces;
 using Microsoft.EntityFrameworkCore;

namespace Around.DataAccess.SqlServer.Repositories
{
    public class CoptersRepository : ICopterRepository
    {
        private readonly DronesharingContext _context;
       
        public CoptersRepository(DronesharingContext context)
        {
            _context = context;
        }

        public async Task<List<Copter>> GetAllAsync()
        {
            return await _context.Copters
                .Include(navigationPropertyPath: c => c.Brand)
                .ToListAsync();
        }

        public async Task<Copter> Get(int id)
         {
            return await _context.Copters
                .Include(navigationPropertyPath: c => c.Brand)
                .FirstOrDefaultAsync(predicate: c => c.Id == id);
        }

        public void Create(Copter copter)
        {
            _context.Copters.Add(entity: copter);
            _context.SaveChanges();
        }

        public void Update(int id, Copter copter)
        {
            var existedCopter = _context.Copters.Find(id);
            if (existedCopter != null)
            {         
                existedCopter.Update(newCopter: copter);
                _context.Copters.Update(entity: existedCopter);
            }

            _context.SaveChanges();
        }

        public void UpdateStatus(int id)
        {
            var existedCopter = _context.Copters.Find(id);
            if (existedCopter != null)
            {
                existedCopter.Status = existedCopter.Status == Status.Free
                    ? Status.Ordered : Status.Free;
                _context.Copters.Update(entity: existedCopter);
            }

            _context.SaveChanges();
        }

        public List<Copter> Search(string search)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            var copter = _context.Copters.Find(id);
            if (copter != null)
                _context.Copters.Remove(entity: copter);
            _context.SaveChanges();
        }
    }
}
