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

            builder.HasMany(x => x.Rent)
                .WithOne(x => x.Client)
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
