using Around.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Around.DataAccess.SqlServer.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Country)
                .WithOne(x => x.Brand)
                .HasForeignKey<Country>(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
