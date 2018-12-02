using Around.Core.Entities;
using Around.DataAccess.SqlServer.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Around.DataAccess.SqlServer
{
    public class DronesharingContext : DbContext
    {
        public DronesharingContext(DbContextOptions<DronesharingContext> options) : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Copter> Copters { get; set; }

        public DbSet<Cheque> Cheques { get; set; }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<Rent> Rents { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdminConfigurations());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new ChequeConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new CopterConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new CreditCardConfiguration());
            modelBuilder.ApplyConfiguration(new DiscountConfiguration());
            modelBuilder.ApplyConfiguration(new RentConfiguration());
            modelBuilder.ApplyConfiguration(new CharacteristicsConfiguration());
            modelBuilder.ApplyConfiguration(new FullCharacteristicsConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
