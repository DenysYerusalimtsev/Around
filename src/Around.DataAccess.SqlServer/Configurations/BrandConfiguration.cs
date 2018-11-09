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

            builder.HasMany(x => x.Copters)
               .WithOne(x => x.Brand)
               .HasForeignKey(a => a.BrandId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
