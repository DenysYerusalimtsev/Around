using System.Collections.Generic;
using System.Threading.Tasks;
using Around.Core.Entities;
using Around.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Around.DataAccess.SqlServer.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private DronesharingContext _context;

        public FlightRepository(DronesharingContext context)
        {
            _context = context;
        }

        public async Task<List<Flight>> GetAllAsync()
        {
            return await _context.Flights.ToListAsync();
        }

        public async Task<Flight> Get(int id)
        {
            return await _context.Flights.FirstOrDefaultAsync(f => f.Id == id);
        }

        public void Create(Flight flight)
        {
            _context.Flights.Add(flight);
            _context.SaveChanges();
        }

        public void Update(Flight flight)
        {
            _context.Flights.Update(flight);
            _context.SaveChanges();
        }

        public List<Cheque> Search(string search)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            var flight = _context.Flights.Find(id);
            if (flight != null)
                _context.Flights.Remove(flight);
            _context.SaveChanges();
        }
    }
}
