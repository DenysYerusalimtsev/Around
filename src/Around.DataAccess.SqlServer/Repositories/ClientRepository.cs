using System.Collections.Generic;
using System.Threading.Tasks;
using Around.Core.Entities;
using Around.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Around.DataAccess.SqlServer.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private DronesharingContext _context;

        public ClientRepository(DronesharingContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> GetAll()
        {
            return await _context.Clients
                .Include(navigationPropertyPath: x => x.Discount)
                .ToListAsync();
        }

        public async Task<Client> Get(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Client> Get(string email)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.Email == email);
        }

        public void Create(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public void Update(Client client)
        {
            _context.Clients.Update(client);
            _context.SaveChanges();
        }

        public List<Client> Search(string search)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            var client = _context.Clients.Find(id);
            if (client != null)
                _context.Clients.Remove(client);
            _context.SaveChanges();
        }

        public async Task AddCreditCardAsync(CreditCard card, int userId)
        {
            var client = await Get(userId);
            client.CreditCards.Add(card);
            _context.SaveChanges();
        }
    }
}
