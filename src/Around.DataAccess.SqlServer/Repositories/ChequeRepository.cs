using System.Collections.Generic;
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
            return await _context.Cheques.ToListAsync();
        }

        public async Task<Cheque> Get(int id)
        {
            return await _context.Cheques.FirstOrDefaultAsync(b => b.Id == id);
        }

        public void Create(Cheque cheque)
        {
            _context.Cheques.Add(cheque);
        }

        public void Update(Cheque cheque)
        {
            _context.Cheques.Update(cheque);
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
        }
    }
}
