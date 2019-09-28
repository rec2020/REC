using Microsoft.EntityFrameworkCore.Migrations;

namespace NajmetAlraqee.Data.Migrations
{
    public partial class updatePaymentMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TreeAccountNo",
                table: "PaymentMethods");

            migrationBuilder.AddColumn<int>(
                name: "AccountTreeId",
                table: "PaymentMethods",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_AccountTreeId",
                table: "PaymentMethods",
                column: "AccountTreeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethods_AccountTrees_AccountTreeId",
                table: "PaymentMethods",
                column: "AccountTreeId",
                principalTable: "AccountTrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethods_AccountTrees_AccountTreeId",
                table: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethods_AccountTreeId",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "AccountTreeId",
                table: "PaymentMethods");

            migrationBuilder.AddColumn<string>(
                name: "TreeAccountNo",
                table: "PaymentMethods",
                nullable: true);
        }
    }
}
