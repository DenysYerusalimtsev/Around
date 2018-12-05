using Microsoft.EntityFrameworkCore.Migrations;

namespace Around.DataAccess.SqlServer.Migrations
{
    public partial class UpdateDbConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Copters_ClientId",
                table: "Rents");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_CopterId",
                table: "Rents",
                column: "CopterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Copters_CopterId",
                table: "Rents",
                column: "CopterId",
                principalTable: "Copters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Copters_CopterId",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Rents_CopterId",
                table: "Rents");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Copters_ClientId",
                table: "Rents",
                column: "ClientId",
                principalTable: "Copters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
