 using Around.Core.Entities;

namespace Around.DataAccess.SqlServer.Repositories
{
    public class CoptersRepository : Repository<Copter>
    {
        public CoptersRepository(DronesharingContext context)
            : base(context)
        {
            dbSet = db.Copters;
        }
    }
}
