using Around.Core.Entities;

namespace Around.DataAccess.SqlServer.Repositories
{
    public class AdminRepositories : Repository<Admin>
    {
        public AdminRepositories(DronesharingContext context)
            : base(context)
        {
            dbSet = db.Admins;
        }
    }
}
