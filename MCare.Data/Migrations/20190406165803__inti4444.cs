using Microsoft.EntityFrameworkCore.Migrations;

namespace NajmetAlraqee.Data.Migrations
{
    public partial class _inti4444 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserDelegates_DelegateTypeId",
                table: "UserDelegates");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_ArrivalCityId",
                table: "Contracts");

            migrationBuilder.CreateIndex(
                name: "IX_UserDelegates_DelegateTypeId",
                table: "UserDelegates",
                column: "DelegateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ArrivalCityId",
                table: "Contracts",
                column: "ArrivalCityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserDelegates_DelegateTypeId",
                table: "UserDelegates");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_ArrivalCityId",
                table: "Contracts");

            migrationBuilder.CreateIndex(
                name: "IX_UserDelegates_DelegateTypeId",
                table: "UserDelegates",
                column: "DelegateTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ArrivalCityId",
                table: "Contracts",
                column: "ArrivalCityId",
                unique: true,
                filter: "[ArrivalCityId] IS NOT NULL");
        }
    }
}
