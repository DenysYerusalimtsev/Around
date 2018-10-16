using System.Collections.Generic;
using System.Threading.Tasks;
using Around.Core.Entities;
using Around.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Around.DataAccess.SqlServer.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private DronesharingContext _context;

        public AdminRepository(DronesharingContext context)
        {
            _context = context;
        }

        public async Task<List<Admin>> GetAllAsync()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task<Admin> Get(int id)
        {
            return await _context.Admins.FirstOrDefaultAsync(a => a.Id == id);
        }

        public void Create(Admin admin)
        {
            _context.Admins.Add(admin);
        }

        public void Update(Admin admin)
        {
            _context.Admins.Update(admin);
        }

        public List<Admin> Search(string search)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            var admin = _context.Admins.Find(id);
            if (admin != null)
                _context.Admins.Remove(admin);
        }
    }
}
