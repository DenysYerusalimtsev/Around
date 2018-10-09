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
                .HasForeignKey<Aircraft>(a => a.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Equipment)
                .WithOne(x => x.Copter)
                .HasForeignKey<Equipment>(a => a.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Characteristics)
                .WithOne(x => x.Copter)
                .HasForeignKey<Characteristics>(a => a.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Flight)
                .WithOne(x => x.Copter)
                .HasForeignKey<Flight>(a => a.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Brand)
                .WithOne(x => x.Copter)
                .HasForeignKey<Brand>(a => a.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.RemoteControl)
                .WithOne(x => x.Copter)
                .HasForeignKey<RemoteControl>(a => a.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Camera)
                .WithOne(x => x.Copter)
                .HasForeignKey<Camera>(a => a.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.LoadCapacity)
                .WithOne(x => x.Copter)
                .HasForeignKey<LoadCapacity>(a => a.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.TransportCharacteristics)
                .WithOne(x => x.Copter)
                .HasForeignKey<TransportCharacteristics>(a => a.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Battery)
                .WithOne(x => x.Copter)
                .HasForeignKey<Battery>(a => a.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Modes)
                .WithOne(x => x.Copter)
                .HasForeignKey<Modes>(a => a.Id)
                .OnDelete(DeleteBehavior.Restrict);;

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
