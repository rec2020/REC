using Microsoft.EntityFrameworkCore.Migrations;

namespace NajmetAlraqee.Data.Migrations
{
    public partial class _intitial123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractHistories_AspNetUsers_ActionById",
                table: "ContractHistories");

            migrationBuilder.DropIndex(
                name: "IX_ContractHistories_ActionById",
                table: "ContractHistories");

            migrationBuilder.AlterColumn<string>(
                name: "ActionById",
                table: "ContractHistories",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActionByName",
                table: "ContractHistories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionByName",
                table: "ContractHistories");

            migrationBuilder.AlterColumn<string>(
                name: "ActionById",
                table: "ContractHistories",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContractHistories_ActionById",
                table: "ContractHistories",
                column: "ActionById",
                unique: true,
                filter: "[ActionById] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractHistories_AspNetUsers_ActionById",
                table: "ContractHistories",
                column: "ActionById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
