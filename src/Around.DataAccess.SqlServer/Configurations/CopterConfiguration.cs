using Around.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Around.DataAccess.SqlServer.Configurations
{
    public class CopterConfiguration : IEntityTypeConfiguration<Copter>
    {
        public void Configure(EntityTypeBuilder<Copter> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
