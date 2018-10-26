using Around.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Around.DataAccess.SqlServer.Configurations
{
    public class PassportConfiguration : IEntityTypeConfiguration<Passport>
    {
        public void Configure(EntityTypeBuilder<Passport> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Admin)
                .WithOne(x => x.Passport)
                .HasForeignKey<Admin>(x => x.PassportId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
