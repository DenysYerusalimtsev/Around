using Around.Core.Entities;

namespace Around.DataAccess.SqlServer.Repositories
{
    public class RentRepository : Repository<Rent>
    {
        public RentRepository(DronesharingContext context)
            : base(context)
        {
            dbSet = db.Rents;
        }
    }
}
