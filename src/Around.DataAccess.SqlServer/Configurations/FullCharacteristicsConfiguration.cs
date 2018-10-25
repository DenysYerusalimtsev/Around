using Around.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Around.DataAccess.SqlServer.Configurations
{
    public class FullCharacteristicsConfiguration : IEntityTypeConfiguration<FullCharacteristics>
    {
        public void Configure(EntityTypeBuilder<FullCharacteristics> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Aircraft)
                .WithOne(x => x.FullCharacteristics)
                .HasForeignKey<Aircraft>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Equipment)
                .WithOne(x => x.FullCharacteristics)
                .HasForeignKey<Equipment>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Characteristics)
                .WithOne(x => x.FullCharacteristics)
                .HasForeignKey<Characteristics>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Flight)
                .WithOne(x => x.FullCharacteristics)
                .HasForeignKey<Flight>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Camera)
                .WithOne(x => x.FullCharacteristics)
                .HasForeignKey<Camera>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.LoadCapacity)
                .WithOne(x => x.FullCharacteristics)
                .HasForeignKey<LoadCapacity>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.TransportCharacteristics)
                .WithOne(x => x.FullCharacteristics)
                .HasForeignKey<TransportCharacteristics>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Battery)
                .WithOne(x => x.FullCharacteristics)
                .HasForeignKey<Battery>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Modes)
                .WithOne(x => x.FullCharacteristics)
                .HasForeignKey<Modes>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
