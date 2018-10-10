using Around.Core.Entities;

namespace Around.DataAccess.SqlServer.Repositories
{
    public class CountryRepository : Repository<Country>
    {
        public CountryRepository(DronesharingContext context)
            : base(context)
        {
            dbSet = db.Countries;
        }
    }
}
