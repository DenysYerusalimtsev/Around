using Around.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Around.DataAccess.SqlServer.Configurations
{
    public class DiscountConfigurations : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Client)
                .WithOne(x => x.Discount)
                .HasForeignKey(x => x.DiscountId);
        }
    }
}
