using Microsoft.EntityFrameworkCore.Migrations;

namespace NajmetAlraqee.Data.Migrations
{
    public partial class AddMisssingAccountToDFE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNoTree",
                table: "UserDelegates");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "ForeignAgencies");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Expenses");

            migrationBuilder.AddColumn<int>(
                name: "AccountTreeId",
                table: "UserDelegates",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountTreeId",
                table: "ForeignAgencies",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountTreeId",
                table: "Expenses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDelegates_AccountTreeId",
                table: "UserDelegates",
                column: "AccountTreeId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgencies_AccountTreeId",
                table: "ForeignAgencies",
                column: "AccountTreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_AccountTreeId",
                table: "Expenses",
                column: "AccountTreeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_AccountTrees_AccountTreeId",
                table: "Expenses",
                column: "AccountTreeId",
                principalTable: "AccountTrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForeignAgencies_AccountTrees_AccountTreeId",
                table: "ForeignAgencies",
                column: "AccountTreeId",
                principalTable: "AccountTrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDelegates_AccountTrees_AccountTreeId",
                table: "UserDelegates",
                column: "AccountTreeId",
                principalTable: "AccountTrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_AccountTrees_AccountTreeId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_ForeignAgencies_AccountTrees_AccountTreeId",
                table: "ForeignAgencies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDelegates_AccountTrees_AccountTreeId",
                table: "UserDelegates");

            migrationBuilder.DropIndex(
                name: "IX_UserDelegates_AccountTreeId",
                table: "UserDelegates");

            migrationBuilder.DropIndex(
                name: "IX_ForeignAgencies_AccountTreeId",
                table: "ForeignAgencies");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_AccountTreeId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "AccountTreeId",
                table: "UserDelegates");

            migrationBuilder.DropColumn(
                name: "AccountTreeId",
                table: "ForeignAgencies");

            migrationBuilder.DropColumn(
                name: "AccountTreeId",
                table: "Expenses");

            migrationBuilder.AddColumn<string>(
                name: "AccountNoTree",
                table: "UserDelegates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "ForeignAgencies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "Expenses",
                nullable: true);
        }
    }
}
