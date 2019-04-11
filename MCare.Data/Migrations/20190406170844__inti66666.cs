using Microsoft.EntityFrameworkCore.Migrations;

namespace NajmetAlraqee.Data.Migrations
{
    public partial class _inti66666 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ForeignAgencies_BankDetailId",
                table: "ForeignAgencies");

            migrationBuilder.DropIndex(
                name: "IX_ForeignAgencies_JobTypeId",
                table: "ForeignAgencies");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeStatusId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_JobTypeId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ReligionId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_SocialStatusId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerTypeId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Currencies_CurrencyTypeId",
                table: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_ContractVisas_VisaById",
                table: "ContractVisas");

            migrationBuilder.DropIndex(
                name: "IX_ContractTickets_CityId",
                table: "ContractTickets");

            migrationBuilder.DropIndex(
                name: "IX_ContractTickets_TicketById",
                table: "ContractTickets");

            migrationBuilder.DropIndex(
                name: "IX_ContractSelects_SelectById",
                table: "ContractSelects");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_JobTypeId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_ContractHistories_ActionId",
                table: "ContractHistories");

            migrationBuilder.DropIndex(
                name: "IX_ContractDelegations_DelegateById",
                table: "ContractDelegations");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgencies_BankDetailId",
                table: "ForeignAgencies",
                column: "BankDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgencies_JobTypeId",
                table: "ForeignAgencies",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeStatusId",
                table: "Employees",
                column: "EmployeeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobTypeId",
                table: "Employees",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReligionId",
                table: "Employees",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SocialStatusId",
                table: "Employees",
                column: "SocialStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTypeId",
                table: "Customers",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_CurrencyTypeId",
                table: "Currencies",
                column: "CurrencyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractVisas_VisaById",
                table: "ContractVisas",
                column: "VisaById");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTickets_CityId",
                table: "ContractTickets",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTickets_TicketById",
                table: "ContractTickets",
                column: "TicketById");

            migrationBuilder.CreateIndex(
                name: "IX_ContractSelects_SelectById",
                table: "ContractSelects",
                column: "SelectById");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_JobTypeId",
                table: "Contracts",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractHistories_ActionId",
                table: "ContractHistories",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractDelegations_DelegateById",
                table: "ContractDelegations",
                column: "DelegateById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ForeignAgencies_BankDetailId",
                table: "ForeignAgencies");

            migrationBuilder.DropIndex(
                name: "IX_ForeignAgencies_JobTypeId",
                table: "ForeignAgencies");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeStatusId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_JobTypeId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ReligionId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_SocialStatusId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerTypeId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Currencies_CurrencyTypeId",
                table: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_ContractVisas_VisaById",
                table: "ContractVisas");

            migrationBuilder.DropIndex(
                name: "IX_ContractTickets_CityId",
                table: "ContractTickets");

            migrationBuilder.DropIndex(
                name: "IX_ContractTickets_TicketById",
                table: "ContractTickets");

            migrationBuilder.DropIndex(
                name: "IX_ContractSelects_SelectById",
                table: "ContractSelects");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_JobTypeId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_ContractHistories_ActionId",
                table: "ContractHistories");

            migrationBuilder.DropIndex(
                name: "IX_ContractDelegations_DelegateById",
                table: "ContractDelegations");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgencies_BankDetailId",
                table: "ForeignAgencies",
                column: "BankDetailId",
                unique: true,
                filter: "[BankDetailId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgencies_JobTypeId",
                table: "ForeignAgencies",
                column: "JobTypeId",
                unique: true,
                filter: "[JobTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeStatusId",
                table: "Employees",
                column: "EmployeeStatusId",
                unique: true,
                filter: "[EmployeeStatusId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobTypeId",
                table: "Employees",
                column: "JobTypeId",
                unique: true,
                filter: "[JobTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReligionId",
                table: "Employees",
                column: "ReligionId",
                unique: true,
                filter: "[ReligionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SocialStatusId",
                table: "Employees",
                column: "SocialStatusId",
                unique: true,
                filter: "[SocialStatusId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTypeId",
                table: "Customers",
                column: "CustomerTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_CurrencyTypeId",
                table: "Currencies",
                column: "CurrencyTypeId",
                unique: true,
                filter: "[CurrencyTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractVisas_VisaById",
                table: "ContractVisas",
                column: "VisaById",
                unique: true,
                filter: "[VisaById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTickets_CityId",
                table: "ContractTickets",
                column: "CityId",
                unique: true,
                filter: "[CityId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTickets_TicketById",
                table: "ContractTickets",
                column: "TicketById",
                unique: true,
                filter: "[TicketById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractSelects_SelectById",
                table: "ContractSelects",
                column: "SelectById",
                unique: true,
                filter: "[SelectById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_JobTypeId",
                table: "Contracts",
                column: "JobTypeId",
                unique: true,
                filter: "[JobTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractHistories_ActionId",
                table: "ContractHistories",
                column: "ActionId",
                unique: true,
                filter: "[ActionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractDelegations_DelegateById",
                table: "ContractDelegations",
                column: "DelegateById",
                unique: true,
                filter: "[DelegateById] IS NOT NULL");
        }
    }
}
