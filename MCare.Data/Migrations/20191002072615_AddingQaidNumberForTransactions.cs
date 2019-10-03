using Microsoft.EntityFrameworkCore.Migrations;

namespace NajmetAlraqee.Data.Migrations
{
    public partial class AddingQaidNumberForTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FinancialPeriodId",
                table: "SnadReceipts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QaidNo",
                table: "SnadReceipts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FinancialPeriodId",
                table: "ReceiptDocs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FinancialPeriodId",
                table: "ForeignAgencyTransfers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QaidNo",
                table: "ForeignAgencyTransfers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FinancialPeriodId",
                table: "DelegateTransfers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QaidNo",
                table: "DelegateTransfers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SnadReceipts_FinancialPeriodId",
                table: "SnadReceipts",
                column: "FinancialPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptDocs_FinancialPeriodId",
                table: "ReceiptDocs",
                column: "FinancialPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgencyTransfers_FinancialPeriodId",
                table: "ForeignAgencyTransfers",
                column: "FinancialPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_DelegateTransfers_FinancialPeriodId",
                table: "DelegateTransfers",
                column: "FinancialPeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_DelegateTransfers_FinancialPeriods_FinancialPeriodId",
                table: "DelegateTransfers",
                column: "FinancialPeriodId",
                principalTable: "FinancialPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForeignAgencyTransfers_FinancialPeriods_FinancialPeriodId",
                table: "ForeignAgencyTransfers",
                column: "FinancialPeriodId",
                principalTable: "FinancialPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptDocs_FinancialPeriods_FinancialPeriodId",
                table: "ReceiptDocs",
                column: "FinancialPeriodId",
                principalTable: "FinancialPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SnadReceipts_FinancialPeriods_FinancialPeriodId",
                table: "SnadReceipts",
                column: "FinancialPeriodId",
                principalTable: "FinancialPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DelegateTransfers_FinancialPeriods_FinancialPeriodId",
                table: "DelegateTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_ForeignAgencyTransfers_FinancialPeriods_FinancialPeriodId",
                table: "ForeignAgencyTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptDocs_FinancialPeriods_FinancialPeriodId",
                table: "ReceiptDocs");

            migrationBuilder.DropForeignKey(
                name: "FK_SnadReceipts_FinancialPeriods_FinancialPeriodId",
                table: "SnadReceipts");

            migrationBuilder.DropIndex(
                name: "IX_SnadReceipts_FinancialPeriodId",
                table: "SnadReceipts");

            migrationBuilder.DropIndex(
                name: "IX_ReceiptDocs_FinancialPeriodId",
                table: "ReceiptDocs");

            migrationBuilder.DropIndex(
                name: "IX_ForeignAgencyTransfers_FinancialPeriodId",
                table: "ForeignAgencyTransfers");

            migrationBuilder.DropIndex(
                name: "IX_DelegateTransfers_FinancialPeriodId",
                table: "DelegateTransfers");

            migrationBuilder.DropColumn(
                name: "FinancialPeriodId",
                table: "SnadReceipts");

            migrationBuilder.DropColumn(
                name: "QaidNo",
                table: "SnadReceipts");

            migrationBuilder.DropColumn(
                name: "FinancialPeriodId",
                table: "ReceiptDocs");

            migrationBuilder.DropColumn(
                name: "FinancialPeriodId",
                table: "ForeignAgencyTransfers");

            migrationBuilder.DropColumn(
                name: "QaidNo",
                table: "ForeignAgencyTransfers");

            migrationBuilder.DropColumn(
                name: "FinancialPeriodId",
                table: "DelegateTransfers");

            migrationBuilder.DropColumn(
                name: "QaidNo",
                table: "DelegateTransfers");
        }
    }
}
