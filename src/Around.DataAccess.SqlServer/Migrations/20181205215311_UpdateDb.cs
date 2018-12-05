using Microsoft.EntityFrameworkCore.Migrations;

namespace Around.DataAccess.SqlServer.Migrations
{
    public partial class UpdateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Copters_CopterId",
                table: "Rents");

            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Cheques_Id",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Rents_CopterId",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "CreditCardNumber",
                table: "Clients");

            migrationBuilder.CreateIndex(
                name: "IX_Cheques_RentId",
                table: "Cheques",
                column: "RentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cheques_Rents_RentId",
                table: "Cheques",
                column: "RentId",
                principalTable: "Rents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Copters_ClientId",
                table: "Rents",
                column: "ClientId",
                principalTable: "Copters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cheques_Rents_RentId",
                table: "Cheques");

            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Copters_ClientId",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Cheques_RentId",
                table: "Cheques");

            migrationBuilder.AddColumn<string>(
                name: "CreditCardNumber",
                table: "Clients",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Cheques_Id",
                table: "Rents",
                column: "Id",
                principalTable: "Cheques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
