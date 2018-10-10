using Around.Core.Entities;

namespace Around.DataAccess.SqlServer.Repositories
{
    public class FlightRepository : Repository<Flight>
    {
        public FlightRepository(DronesharingContext context)
            : base(context)
        {
            dbSet = db.Flights;
        }
    }
}
