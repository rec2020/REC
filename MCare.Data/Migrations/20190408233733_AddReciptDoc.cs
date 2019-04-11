using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NajmetAlraqee.Data.Migrations
{
    public partial class AddReciptDoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReceiptdocTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptdocTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receiptdocs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReceiptdocTypeId = table.Column<int>(nullable: true),
                    ContractId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    VAT = table.Column<decimal>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    ReceiptDate = table.Column<string>(nullable: true),
                    ReceiptByUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receiptdocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receiptdocs_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receiptdocs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receiptdocs_ReceiptdocTypes_ReceiptdocTypeId",
                        column: x => x.ReceiptdocTypeId,
                        principalTable: "ReceiptdocTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ReceiptdocTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "سند صرف " });

            migrationBuilder.InsertData(
                table: "ReceiptdocTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "سند قبض" });

            migrationBuilder.CreateIndex(
                name: "IX_Receiptdocs_ContractId",
                table: "Receiptdocs",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Receiptdocs_CustomerId",
                table: "Receiptdocs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Receiptdocs_ReceiptdocTypeId",
                table: "Receiptdocs",
                column: "ReceiptdocTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receiptdocs");

            migrationBuilder.DropTable(
                name: "ReceiptdocTypes");
        }
    }
}
