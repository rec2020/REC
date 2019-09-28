using Microsoft.EntityFrameworkCore.Migrations;

namespace NajmetAlraqee.Data.Migrations
{
    public partial class AddAccounttreeToBankDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNumberInTree",
                table: "BankDetails");

            migrationBuilder.AddColumn<int>(
                name: "AccountTreeId",
                table: "BankDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_AccountTreeId",
                table: "BankDetails",
                column: "AccountTreeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankDetails_AccountTrees_AccountTreeId",
                table: "BankDetails",
                column: "AccountTreeId",
                principalTable: "AccountTrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankDetails_AccountTrees_AccountTreeId",
                table: "BankDetails");

            migrationBuilder.DropIndex(
                name: "IX_BankDetails_AccountTreeId",
                table: "BankDetails");

            migrationBuilder.DropColumn(
                name: "AccountTreeId",
                table: "BankDetails");

            migrationBuilder.AddColumn<string>(
                name: "AccountNumberInTree",
                table: "BankDetails",
                nullable: true);
        }
    }
}
