using Around.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Around.DataAccess.SqlServer.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.CreditCards)
                .WithOne(x => x.Client)
                .HasForeignKey(x => x.Number)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Rent)
                .WithOne(x => x.Client)
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Discount)
                .WithOne(x => x.Client)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Passport)
                .WithOne(x => x.Client)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
