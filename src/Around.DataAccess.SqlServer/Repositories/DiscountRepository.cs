using Around.Core.Entities;

namespace Around.DataAccess.SqlServer.Repositories
{
    public class DiscountRepository : Repository<Discount>
    {
        public DiscountRepository(DronesharingContext context)
            : base(context)
        {
            dbSet = db.Discounts;
        }
    }
}
