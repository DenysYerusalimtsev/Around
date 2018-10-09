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

            builder.HasOne(x => x.Aircraft)
                .WithOne(x => x.Copter)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Equipment)
                .WithOne(x => x.Copter)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Characteristics)
                .WithOne(x => x.Copter)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Flight)
                .WithOne(x => x.Copter)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Brand)
                .WithOne(x => x.Copter)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.RemoteControl)
                .WithOne(x => x.Copter)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Camera)
                .WithOne(x => x.Copter)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.LoadCapacity)
                .WithOne(x => x.Copter)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.TransportCharacteristics)
                .WithOne(x => x.Copter)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Battery)
                .WithOne(x => x.Copter)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Modes)
                .WithOne(x => x.Copter)
                .OnDelete(DeleteBehavior.Restrict);;

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
