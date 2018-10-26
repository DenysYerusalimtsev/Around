using Around.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Around.DataAccess.SqlServer.Configurations
{
    public class CharacteristicsConfiguration : IEntityTypeConfiguration<Characteristics>
    {
        public void Configure(EntityTypeBuilder<Characteristics> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.FullCharacteristics)
                .WithOne(x => x.Characteristics)
                .HasForeignKey<Characteristics>(a => a.FullCharacteristicsId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
