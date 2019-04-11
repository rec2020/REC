using Microsoft.EntityFrameworkCore.Migrations;

namespace NajmetAlraqee.Data.Migrations
{
    public partial class _inti5555555555 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserDelegates_NationalityId",
                table: "UserDelegates");

            migrationBuilder.DropIndex(
                name: "IX_ForeignAgencies_NationalityId",
                table: "ForeignAgencies");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ForeignAgencyId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_GenderId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_NationalityId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_ContractVisas_EmployeeId",
                table: "ContractVisas");

            migrationBuilder.DropIndex(
                name: "IX_ContractTickets_EmployeeId",
                table: "ContractTickets");

            migrationBuilder.DropIndex(
                name: "IX_ContractSelects_ForeignAgencyId",
                table: "ContractSelects");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_ContractStatusId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_ContractTypeId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_EmployeeId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_ForeignAgencyId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_ContractHistories_ContractStatusId",
                table: "ContractHistories");

            migrationBuilder.DropIndex(
                name: "IX_ContractDelegations_ForeignAgencyId",
                table: "ContractDelegations");

            migrationBuilder.CreateIndex(
                name: "IX_UserDelegates_NationalityId",
                table: "UserDelegates",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgencies_NationalityId",
                table: "ForeignAgencies",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ForeignAgencyId",
                table: "Employees",
                column: "ForeignAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_GenderId",
                table: "Employees",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_NationalityId",
                table: "Employees",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractVisas_EmployeeId",
                table: "ContractVisas",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTickets_EmployeeId",
                table: "ContractTickets",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractSelects_ForeignAgencyId",
                table: "ContractSelects",
                column: "ForeignAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContractStatusId",
                table: "Contracts",
                column: "ContractStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContractTypeId",
                table: "Contracts",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_EmployeeId",
                table: "Contracts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ForeignAgencyId",
                table: "Contracts",
                column: "ForeignAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractHistories_ContractStatusId",
                table: "ContractHistories",
                column: "ContractStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractDelegations_ForeignAgencyId",
                table: "ContractDelegations",
                column: "ForeignAgencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserDelegates_NationalityId",
                table: "UserDelegates");

            migrationBuilder.DropIndex(
                name: "IX_ForeignAgencies_NationalityId",
                table: "ForeignAgencies");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ForeignAgencyId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_GenderId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_NationalityId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_ContractVisas_EmployeeId",
                table: "ContractVisas");

            migrationBuilder.DropIndex(
                name: "IX_ContractTickets_EmployeeId",
                table: "ContractTickets");

            migrationBuilder.DropIndex(
                name: "IX_ContractSelects_ForeignAgencyId",
                table: "ContractSelects");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_ContractStatusId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_ContractTypeId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_EmployeeId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_ForeignAgencyId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_ContractHistories_ContractStatusId",
                table: "ContractHistories");

            migrationBuilder.DropIndex(
                name: "IX_ContractDelegations_ForeignAgencyId",
                table: "ContractDelegations");

            migrationBuilder.CreateIndex(
                name: "IX_UserDelegates_NationalityId",
                table: "UserDelegates",
                column: "NationalityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgencies_NationalityId",
                table: "ForeignAgencies",
                column: "NationalityId",
                unique: true,
                filter: "[NationalityId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ForeignAgencyId",
                table: "Employees",
                column: "ForeignAgencyId",
                unique: true,
                filter: "[ForeignAgencyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_GenderId",
                table: "Employees",
                column: "GenderId",
                unique: true,
                filter: "[GenderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_NationalityId",
                table: "Employees",
                column: "NationalityId",
                unique: true,
                filter: "[NationalityId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractVisas_EmployeeId",
                table: "ContractVisas",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTickets_EmployeeId",
                table: "ContractTickets",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractSelects_ForeignAgencyId",
                table: "ContractSelects",
                column: "ForeignAgencyId",
                unique: true,
                filter: "[ForeignAgencyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContractStatusId",
                table: "Contracts",
                column: "ContractStatusId",
                unique: true,
                filter: "[ContractStatusId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContractTypeId",
                table: "Contracts",
                column: "ContractTypeId",
                unique: true,
                filter: "[ContractTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_EmployeeId",
                table: "Contracts",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ForeignAgencyId",
                table: "Contracts",
                column: "ForeignAgencyId",
                unique: true,
                filter: "[ForeignAgencyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractHistories_ContractStatusId",
                table: "ContractHistories",
                column: "ContractStatusId",
                unique: true,
                filter: "[ContractStatusId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractDelegations_ForeignAgencyId",
                table: "ContractDelegations",
                column: "ForeignAgencyId",
                unique: true,
                filter: "[ForeignAgencyId] IS NOT NULL");
        }
    }
}
