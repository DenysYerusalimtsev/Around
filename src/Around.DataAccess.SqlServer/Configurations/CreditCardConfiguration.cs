using Around.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Around.DataAccess.SqlServer.Configurations
{
    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(x => x.Number);

            builder.HasOne(p => p.Client)
               .WithMany(b => b.CreditCards)
               .HasForeignKey(p => p.ClientId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
