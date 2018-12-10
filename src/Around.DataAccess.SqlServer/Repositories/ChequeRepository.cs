using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Around.Core.Entities;
using Around.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Around.DataAccess.SqlServer.Repositories
{
    public class ChequeRepository : IChequeRepository
    {
        private DronesharingContext _context;

        public ChequeRepository(DronesharingContext context)
        {
            _context = context;
        }

        public async Task<List<Cheque>> GetAllAsync()
        {
            return await _context.Cheques
                .Include(x => x.Rent)
                .ThenInclude(x => x.Copter)
                .ThenInclude(x => x.Brand)
                .Include(x => x.Rent)
                .ThenInclude(x => x.Client)
                .ToListAsync();
        }

        public async Task<Cheque> Get(int id)
        {
            return await _context.Cheques
                .Include(x => x.Rent)
                .ThenInclude(x => x.Copter)
                .ThenInclude(x => x.Brand)
                .Include(x => x.Rent)
                .ThenInclude(x => x.Client).FirstOrDefaultAsync(b => b.Id == id);
        }

        public Cheque GetLast()
        {
            return _context.Cheques
                .Include(x => x.Rent)
                .ThenInclude(x => x.Copter)
                .ThenInclude(x => x.Brand)
                .Include(x => x.Rent)
                .ThenInclude(x => x.Client)
                .Last();
        }

        public Task<Cheque> GetLastAsync()
        {
            return _context.Cheques
                .Include(x => x.Rent)
                .ThenInclude(x => x.Copter)
                .ThenInclude(x => x.Brand)
                .Include(x => x.Rent)
                .ThenInclude(x => x.Client)
                .LastAsync();
        }

        public void Create(Cheque cheque)
        {
            _context.Cheques.Add(cheque);
            _context.SaveChanges();
        }

        public void AddCost()
        {
            var chequeToUpdate = GetLast();
            chequeToUpdate.TotalPrice = chequeToUpdate.Rent.Copter.CostPerMinute
                                        * (chequeToUpdate.DateOfCreation - chequeToUpdate.Rent.StartTime)
                                        .Minutes;
            Update(chequeToUpdate);
        }

        public void Update(Cheque cheque)
        {
            _context.Cheques.Update(cheque);
            _context.SaveChanges();
        }

        public List<Cheque> Search(string search)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            var cheque = _context.Cheques.Find(id);
            if (cheque != null)
                _context.Cheques.Remove(cheque);
            _context.SaveChanges();
        }
    }
}
