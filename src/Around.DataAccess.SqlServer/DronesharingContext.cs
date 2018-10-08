using Around.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Around.DataAccess.SqlServer
{
    public class DronesharingContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Check> Checks { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<Passport> Passports { get; set; }

        public DbSet<Rent> Trips { get; set; }

        public DronesharingContext()
        {
            Database.Migrate();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=DroneSharing;Trusted_Connection=True;");
        }
    }
}
