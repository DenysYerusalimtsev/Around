using Microsoft.EntityFrameworkCore.Migrations;

namespace Around.DataAccess.SqlServer.Migrations
{
    public partial class UpdateCopterEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Copters",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Copters",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Copters");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Copters");
        }
    }
}
