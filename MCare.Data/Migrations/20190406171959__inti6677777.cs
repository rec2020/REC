using Microsoft.EntityFrameworkCore.Migrations;

namespace NajmetAlraqee.Data.Migrations
{
    public partial class _inti6677777 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ForeignAgencies_CurrencyId",
                table: "ForeignAgencies");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgencies_CurrencyId",
                table: "ForeignAgencies",
                column: "CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ForeignAgencies_CurrencyId",
                table: "ForeignAgencies");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgencies_CurrencyId",
                table: "ForeignAgencies",
                column: "CurrencyId",
                unique: true,
                filter: "[CurrencyId] IS NOT NULL");
        }
    }
}
