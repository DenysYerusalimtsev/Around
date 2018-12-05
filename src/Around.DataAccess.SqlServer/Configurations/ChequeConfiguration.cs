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

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}