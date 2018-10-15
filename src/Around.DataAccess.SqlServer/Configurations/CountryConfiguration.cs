using Around.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Around.DataAccess.SqlServer.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(x => x.Code);

            builder.HasMany(x => x.Brands)
                .WithOne(x => x.Country)
                .HasForeignKey(x => x.CountryCode)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
