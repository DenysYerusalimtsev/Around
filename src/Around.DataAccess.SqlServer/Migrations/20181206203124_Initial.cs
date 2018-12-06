using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Around.DataAccess.SqlServer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PassportSnapshot = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    CountryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    Percentage = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brands_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PassportSnapshot = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    DiscountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Copters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    CostPerMinute = table.Column<double>(nullable: false),
                    BrandId = table.Column<int>(nullable: false),
                    MaxSpeed = table.Column<double>(nullable: false),
                    MaxFlightHeight = table.Column<double>(nullable: false),
                    Control = table.Column<int>(nullable: false),
                    DroneType = table.Column<int>(nullable: false),
                    FullCharacteristicsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Copters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Copters_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Number = table.Column<string>(nullable: false),
                    ValidThru = table.Column<string>(nullable: true),
                    Cvv = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Number);
                    table.ForeignKey(
                        name: "FK_CreditCards_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FullCharacteristics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CopterId = table.Column<int>(nullable: false),
                    CharacteristicId = table.Column<int>(nullable: false),
                    FlightId = table.Column<int>(nullable: false),
                    EquipmentId = table.Column<int>(nullable: false),
                    CameraId = table.Column<int>(nullable: false),
                    RemoteControlId = table.Column<int>(nullable: false),
                    AircraftId = table.Column<int>(nullable: false),
                    ModesId = table.Column<int>(nullable: false),
                    LoadCapacityId = table.Column<int>(nullable: false),
                    TransportCharacteristicsId = table.Column<int>(nullable: false),
                    BatteryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullCharacteristics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FullCharacteristics_Copters_CopterId",
                        column: x => x.CopterId,
                        principalTable: "Copters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(nullable: false),
                    CopterId = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rents_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_Copters_CopterId",
                        column: x => x.CopterId,
                        principalTable: "Copters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aircraft",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    FlameMaterial = table.Column<int>(nullable: false),
                    HasFoldableDesign = table.Column<bool>(nullable: false),
                    EngineType = table.Column<int>(nullable: false),
                    Connectors = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aircraft_FullCharacteristics_Id",
                        column: x => x.Id,
                        principalTable: "FullCharacteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Battery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ChargingSpeed = table.Column<double>(nullable: false),
                    Capacity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Battery_FullCharacteristics_Id",
                        column: x => x.Id,
                        principalTable: "FullCharacteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Camera",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CameraMount = table.Column<int>(nullable: false),
                    Lens = table.Column<string>(nullable: true),
                    HasCameraRotation = table.Column<bool>(nullable: false),
                    IsoSensetivity = table.Column<string>(nullable: true),
                    Resolution = table.Column<int>(nullable: false),
                    PhotoModes = table.Column<string>(nullable: true),
                    Stabilization = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Camera_FullCharacteristics_Id",
                        column: x => x.Id,
                        principalTable: "FullCharacteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characteristics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullCharacteristicsId = table.Column<int>(nullable: false),
                    AmbientTemperature = table.Column<double>(nullable: false),
                    Widht = table.Column<double>(nullable: false),
                    Length = table.Column<double>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Colour = table.Column<string>(nullable: true),
                    PropellersCount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characteristics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characteristics_FullCharacteristics_FullCharacteristicsId",
                        column: x => x.FullCharacteristicsId,
                        principalTable: "FullCharacteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    HasGps = table.Column<bool>(nullable: false),
                    InternalMemory = table.Column<int>(nullable: false),
                    HasMemoryCardSupport = table.Column<bool>(nullable: false),
                    HasGyroscope = table.Column<bool>(nullable: false),
                    HasMagnetometer = table.Column<bool>(nullable: false),
                    HasAccelerometer = table.Column<bool>(nullable: false),
                    HasBarometer = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_FullCharacteristics_Id",
                        column: x => x.Id,
                        principalTable: "FullCharacteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    LiftingSpeed = table.Column<double>(nullable: false),
                    DescentSpeed = table.Column<double>(nullable: false),
                    MaximumHeight = table.Column<double>(nullable: false),
                    MaximumSpeed = table.Column<double>(nullable: false),
                    MinimumSpeed = table.Column<double>(nullable: false),
                    FlightTime = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_FullCharacteristics_Id",
                        column: x => x.Id,
                        principalTable: "FullCharacteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoadCapacity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    LoadMountsCount = table.Column<int>(nullable: false),
                    MaximumWeight = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadCapacity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoadCapacity_FullCharacteristics_Id",
                        column: x => x.Id,
                        principalTable: "FullCharacteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    HasTracking = table.Column<bool>(nullable: false),
                    HasTrick = table.Column<bool>(nullable: false),
                    HasReturnBase = table.Column<bool>(nullable: false),
                    HasCfmPositioning = table.Column<bool>(nullable: false),
                    HasFirstPersonView = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modes_FullCharacteristics_Id",
                        column: x => x.Id,
                        principalTable: "FullCharacteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransportCharacteristics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    HasAutopilot = table.Column<bool>(nullable: false),
                    SeatCount = table.Column<int>(nullable: false),
                    HasAirbag = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportCharacteristics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportCharacteristics_FullCharacteristics_Id",
                        column: x => x.Id,
                        principalTable: "FullCharacteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cheques",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RentId = table.Column<int>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cheques_Rents_RentId",
                        column: x => x.RentId,
                        principalTable: "Rents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CountryCode",
                table: "Brands",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Characteristics_FullCharacteristicsId",
                table: "Characteristics",
                column: "FullCharacteristicsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cheques_RentId",
                table: "Cheques",
                column: "RentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_DiscountId",
                table: "Clients",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Copters_BrandId",
                table: "Copters",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_ClientId",
                table: "CreditCards",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_FullCharacteristics_CopterId",
                table: "FullCharacteristics",
                column: "CopterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rents_ClientId",
                table: "Rents",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_CopterId",
                table: "Rents",
                column: "CopterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Aircraft");

            migrationBuilder.DropTable(
                name: "Battery");

            migrationBuilder.DropTable(
                name: "Camera");

            migrationBuilder.DropTable(
                name: "Characteristics");

            migrationBuilder.DropTable(
                name: "Cheques");

            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "LoadCapacity");

            migrationBuilder.DropTable(
                name: "Modes");

            migrationBuilder.DropTable(
                name: "TransportCharacteristics");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "FullCharacteristics");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Copters");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
