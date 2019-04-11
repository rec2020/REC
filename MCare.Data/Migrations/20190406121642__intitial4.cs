using Microsoft.EntityFrameworkCore.Migrations;

namespace NajmetAlraqee.Data.Migrations
{
    public partial class _intitial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractHistories_Customers_CustomerId",
                table: "ContractHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractHistories_Employees_EmployeeId",
                table: "ContractHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractHistories_ForeignAgencies_ForeignAgencyId",
                table: "ContractHistories");

            migrationBuilder.DropIndex(
                name: "IX_ContractHistories_CustomerId",
                table: "ContractHistories");

            migrationBuilder.DropIndex(
                name: "IX_ContractHistories_EmployeeId",
                table: "ContractHistories");

            migrationBuilder.DropIndex(
                name: "IX_ContractHistories_ForeignAgencyId",
                table: "ContractHistories");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "ContractHistories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeName",
                table: "ContractHistories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ForeignAgencyName",
                table: "ContractHistories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "ContractHistories");

            migrationBuilder.DropColumn(
                name: "EmployeeName",
                table: "ContractHistories");

            migrationBuilder.DropColumn(
                name: "ForeignAgencyName",
                table: "ContractHistories");

            migrationBuilder.CreateIndex(
                name: "IX_ContractHistories_CustomerId",
                table: "ContractHistories",
                column: "CustomerId",
                unique: true,
                filter: "[CustomerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractHistories_EmployeeId",
                table: "ContractHistories",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractHistories_ForeignAgencyId",
                table: "ContractHistories",
                column: "ForeignAgencyId",
                unique: true,
                filter: "[ForeignAgencyId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractHistories_Customers_CustomerId",
                table: "ContractHistories",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractHistories_Employees_EmployeeId",
                table: "ContractHistories",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractHistories_ForeignAgencies_ForeignAgencyId",
                table: "ContractHistories",
                column: "ForeignAgencyId",
                principalTable: "ForeignAgencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
