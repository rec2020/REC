using Microsoft.EntityFrameworkCore.Migrations;

namespace NajmetAlraqee.Data.Migrations
{
    public partial class AddFinancyPeriods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FinancialPeriodId",
                table: "Contracts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_FinancialPeriodId",
                table: "Contracts",
                column: "FinancialPeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_FinancialPeriods_FinancialPeriodId",
                table: "Contracts",
                column: "FinancialPeriodId",
                principalTable: "FinancialPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_FinancialPeriods_FinancialPeriodId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_FinancialPeriodId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "FinancialPeriodId",
                table: "Contracts");
        }
    }
}
