using Around.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Around.DataAccess.SqlServer
{
    public class CarsharingContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Check> Checks { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<DriveLicense> DriveLicenses { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public CarsharingContext()
        {
            Database.Migrate();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DIMON01;Initial Catalog=CarsharingDB;Integrated Security=True");
        }
    }
}
