using Around.Core.Entities;

namespace Around.DataAccess.SqlServer.Repositories
{
    class ChequeRepository : Repository<Cheque>
    {
        public ChequeRepository(DronesharingContext context)
            : base(context)
        {
            dbSet = db.Cheques;
        }
    }
}
