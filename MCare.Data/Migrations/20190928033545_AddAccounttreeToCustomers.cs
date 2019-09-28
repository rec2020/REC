using Microsoft.EntityFrameworkCore.Migrations;

namespace NajmetAlraqee.Data.Migrations
{
    public partial class AddAccounttreeToCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountTreeId",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AccountTreeId",
                table: "Customers",
                column: "AccountTreeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AccountTrees_AccountTreeId",
                table: "Customers",
                column: "AccountTreeId",
                principalTable: "AccountTrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AccountTrees_AccountTreeId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AccountTreeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AccountTreeId",
                table: "Customers");
        }
    }
}
