using Around.Core.Entities;

namespace Around.DataAccess.SqlServer.Repositories
{
    public class BrandRepository : Repository<Brand>
    {
        public BrandRepository(DronesharingContext context)
            : base(context)
        {
            dbSet = db.Brands;
        }
    }
}
