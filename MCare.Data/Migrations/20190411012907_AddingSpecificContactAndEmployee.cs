using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NajmetAlraqee.Data.Migrations
{
    public partial class AddingSpecificContactAndEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContractTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.CreateTable(
                name: "SpecialEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PassportNo = table.Column<string>(nullable: true),
                    NationalityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialEmployees_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecificContracts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    SpecialEmployeeId = table.Column<int>(nullable: true),
                    ForeignAgencyId = table.Column<int>(nullable: true),
                    ForeignAgencyName = table.Column<string>(nullable: true),
                    LicenceNumber = table.Column<string>(nullable: true),
                    ContractCost = table.Column<decimal>(nullable: false),
                    VAT = table.Column<decimal>(nullable: false),
                    DelegationDate = table.Column<string>(nullable: true),
                    ContractStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificContracts_ContractStatuses_ContractStatusId",
                        column: x => x.ContractStatusId,
                        principalTable: "ContractStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecificContracts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecificContracts_ForeignAgencies_ForeignAgencyId",
                        column: x => x.ForeignAgencyId,
                        principalTable: "ForeignAgencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecificContracts_SpecialEmployees_SpecialEmployeeId",
                        column: x => x.SpecialEmployeeId,
                        principalTable: "SpecialEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ContractTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "بديل" });

            migrationBuilder.CreateIndex(
                name: "IX_SpecialEmployees_NationalityId",
                table: "SpecialEmployees",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificContracts_ContractStatusId",
                table: "SpecificContracts",
                column: "ContractStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificContracts_CustomerId",
                table: "SpecificContracts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificContracts_ForeignAgencyId",
                table: "SpecificContracts",
                column: "ForeignAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificContracts_SpecialEmployeeId",
                table: "SpecificContracts",
                column: "SpecialEmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecificContracts");

            migrationBuilder.DropTable(
                name: "SpecialEmployees");

            migrationBuilder.DeleteData(
                table: "ContractTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "ContractTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "بديل" });
        }
    }
}
