using Around.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Around.DataAccess.SqlServer.Configurations
{
    public class ChequeConfiguration : IEntityTypeConfiguration<Cheque>
    {
        public void Configure(EntityTypeBuilder<Cheque> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Rent)
                .WithOne(x => x.Cheque)
                .HasForeignKey<Rent>(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}