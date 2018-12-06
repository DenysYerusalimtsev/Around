using Around.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Around.DataAccess.SqlServer.Configurations
{
    public class RentConfiguration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(r => r.Client)
                .WithMany(c => c.Rent)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.Copter)
                .WithMany(c => c.Rents)
                .HasForeignKey(p => p.CopterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Cheque)
                .WithOne(x => x.Rent)
                .HasForeignKey<Cheque>(x => x.RentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
