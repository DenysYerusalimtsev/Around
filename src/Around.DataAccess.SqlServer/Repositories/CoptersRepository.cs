 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using Around.Core.Entities;
 using Around.Core.Enums;
 using Around.Core.Interfaces;
 using Microsoft.EntityFrameworkCore;

namespace Around.DataAccess.SqlServer.Repositories
{
    public class CoptersRepository : ICopterRepository
    {
        private DronesharingContext _context;
        List<Copter> _copters = new List<Copter>
        {
            new Copter(id: 1, name: "MiCopter", status: Status.Free, 
                latitude: 49.99825924, longitude: 36.33680653, costPerMinute: 1,
                brandId: 1, maxSpeed: 15, maxFlightHeight: 20, 
                control: Control.Smartphone, droneType: DroneType.Filming, fullCharacteristicsId: null),

            new Copter(id: 2, name: "ICopter", status: Status.Ordered,
                latitude:50.00233947, longitude: 36.30294321, costPerMinute: 1,
                brandId: 2, maxSpeed: 15, maxFlightHeight: 20,
                control: Control.Autopilot, droneType: DroneType.CargoTransportation, fullCharacteristicsId: null),

            new Copter(id: 3, name: "GoogleCopter", status: Status.Free,
                latitude: 50.00121699, longitude: 36.23420704, costPerMinute: 1,
                brandId: 3, maxSpeed: 15, maxFlightHeight: 20,
                control: Control.Driving, droneType: DroneType.Vehiche, fullCharacteristicsId: null)

        };
        public CoptersRepository(DronesharingContext context)
        {
            _context = context;
        }

        public List<Copter> GetAll()
        {
            return _copters;
        }

        public Copter GetCopter(int id)
        {
            return _copters.FirstOrDefault(c => c.Id == id);
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
