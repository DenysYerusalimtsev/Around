﻿// <auto-generated />
using System;
using Around.DataAccess.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Around.DataAccess.SqlServer.Migrations
{
    [DbContext(typeof(DronesharingContext))]
    partial class DronesharingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Around.Core.Entities.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PassportSnapshot");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Around.Core.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryCode");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CountryCode");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Around.Core.Entities.Cheque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfCreation");

                    b.Property<int>("RentId");

                    b.Property<double>("TotalPrice");

                    b.HasKey("Id");

                    b.HasIndex("RentId")
                        .IsUnique();

                    b.ToTable("Cheques");
                });

            modelBuilder.Entity("Around.Core.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DiscountId");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PassportSnapshot");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.HasIndex("DiscountId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Around.Core.Entities.Copter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId");

                    b.Property<int>("Control");

                    b.Property<double>("CostPerMinute");

                    b.Property<int>("DroneType");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<double>("MaxFlightHeight");

                    b.Property<double>("MaxSpeed");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Copters");
                });

            modelBuilder.Entity("Around.Core.Entities.Country", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CountryName");

                    b.HasKey("Code");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Around.Core.Entities.CreditCard", b =>
                {
                    b.Property<string>("Number")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<string>("Cvv");

                    b.Property<string>("ValidThru");

                    b.HasKey("Number");

                    b.HasIndex("ClientId");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("Around.Core.Entities.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Percentage");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("Around.Core.Entities.Rent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<int>("CopterId");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("CopterId");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("Around.Core.Entities.Brand", b =>
                {
                    b.HasOne("Around.Core.Entities.Country", "Country")
                        .WithMany("Brands")
                        .HasForeignKey("CountryCode")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Around.Core.Entities.Cheque", b =>
                {
                    b.HasOne("Around.Core.Entities.Rent", "Rent")
                        .WithOne("Cheque")
                        .HasForeignKey("Around.Core.Entities.Cheque", "RentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Around.Core.Entities.Client", b =>
                {
                    b.HasOne("Around.Core.Entities.Discount", "Discount")
                        .WithMany("Client")
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Around.Core.Entities.Copter", b =>
                {
                    b.HasOne("Around.Core.Entities.Brand", "Brand")
                        .WithMany("Copters")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Around.Core.Entities.CreditCard", b =>
                {
                    b.HasOne("Around.Core.Entities.Client", "Client")
                        .WithMany("CreditCards")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Around.Core.Entities.Rent", b =>
                {
                    b.HasOne("Around.Core.Entities.Client", "Client")
                        .WithMany("Rent")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Around.Core.Entities.Copter", "Copter")
                        .WithMany("Rents")
                        .HasForeignKey("CopterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
