using Around.Core.Entities;

namespace Around.DataAccess.SqlServer.Repositories
{
    public class ClientRepository : Repository<Client>
    {
        public ClientRepository(DronesharingContext context)
            : base(context)
        {
            dbSet = db.Clients;
        }
    }
}
