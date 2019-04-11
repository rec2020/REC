using Microsoft.EntityFrameworkCore.Migrations;

namespace NajmetAlraqee.Data.Migrations
{
    public partial class AddReceipByName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receiptdocs_Contracts_ContractId",
                table: "Receiptdocs");

            migrationBuilder.DropForeignKey(
                name: "FK_Receiptdocs_Customers_CustomerId",
                table: "Receiptdocs");

            migrationBuilder.DropForeignKey(
                name: "FK_Receiptdocs_ReceiptdocTypes_ReceiptdocTypeId",
                table: "Receiptdocs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiptdocTypes",
                table: "ReceiptdocTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receiptdocs",
                table: "Receiptdocs");

            migrationBuilder.DeleteData(
                table: "ContractTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "ReceiptdocTypes",
                newName: "ReceiptDocTypes");

            migrationBuilder.RenameTable(
                name: "Receiptdocs",
                newName: "ReceiptDocs");

            migrationBuilder.RenameIndex(
                name: "IX_Receiptdocs_ReceiptdocTypeId",
                table: "ReceiptDocs",
                newName: "IX_ReceiptDocs_ReceiptdocTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Receiptdocs_CustomerId",
                table: "ReceiptDocs",
                newName: "IX_ReceiptDocs_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Receiptdocs_ContractId",
                table: "ReceiptDocs",
                newName: "IX_ReceiptDocs_ContractId");

            migrationBuilder.AddColumn<string>(
                name: "ReceiptByUserName",
                table: "ReceiptDocs",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiptDocTypes",
                table: "ReceiptDocTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiptDocs",
                table: "ReceiptDocs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptDocs_Contracts_ContractId",
                table: "ReceiptDocs",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptDocs_Customers_CustomerId",
                table: "ReceiptDocs",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptDocs_ReceiptDocTypes_ReceiptdocTypeId",
                table: "ReceiptDocs",
                column: "ReceiptdocTypeId",
                principalTable: "ReceiptDocTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptDocs_Contracts_ContractId",
                table: "ReceiptDocs");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptDocs_Customers_CustomerId",
                table: "ReceiptDocs");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptDocs_ReceiptDocTypes_ReceiptdocTypeId",
                table: "ReceiptDocs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiptDocTypes",
                table: "ReceiptDocTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiptDocs",
                table: "ReceiptDocs");

            migrationBuilder.DropColumn(
                name: "ReceiptByUserName",
                table: "ReceiptDocs");

            migrationBuilder.RenameTable(
                name: "ReceiptDocTypes",
                newName: "ReceiptdocTypes");

            migrationBuilder.RenameTable(
                name: "ReceiptDocs",
                newName: "Receiptdocs");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptDocs_ReceiptdocTypeId",
                table: "Receiptdocs",
                newName: "IX_Receiptdocs_ReceiptdocTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptDocs_CustomerId",
                table: "Receiptdocs",
                newName: "IX_Receiptdocs_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptDocs_ContractId",
                table: "Receiptdocs",
                newName: "IX_Receiptdocs_ContractId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiptdocTypes",
                table: "ReceiptdocTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receiptdocs",
                table: "Receiptdocs",
                column: "Id");

            migrationBuilder.InsertData(
                table: "ContractTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "معين" });

            migrationBuilder.AddForeignKey(
                name: "FK_Receiptdocs_Contracts_ContractId",
                table: "Receiptdocs",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receiptdocs_Customers_CustomerId",
                table: "Receiptdocs",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receiptdocs_ReceiptdocTypes_ReceiptdocTypeId",
                table: "Receiptdocs",
                column: "ReceiptdocTypeId",
                principalTable: "ReceiptdocTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
