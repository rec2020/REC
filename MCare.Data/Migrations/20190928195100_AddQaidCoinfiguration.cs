using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NajmetAlraqee.Data.Migrations
{
    public partial class AddQaidCoinfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecruitmentQaids_AccountTrees_FromAccountId",
                table: "RecruitmentQaids");

            migrationBuilder.DropForeignKey(
                name: "FK_RecruitmentQaids_AccountTrees_ToAccountId",
                table: "RecruitmentQaids");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "RecruitmentQaids");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "RecruitmentQaids");

            migrationBuilder.RenameColumn(
                name: "ToAccountId",
                table: "RecruitmentQaids",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "FromAccountId",
                table: "RecruitmentQaids",
                newName: "StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_RecruitmentQaids_ToAccountId",
                table: "RecruitmentQaids",
                newName: "IX_RecruitmentQaids_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecruitmentQaids_FromAccountId",
                table: "RecruitmentQaids",
                newName: "IX_RecruitmentQaids_StatusId");

            migrationBuilder.AddColumn<int>(
                name: "FinancialPeriodId",
                table: "RecruitmentQaids",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RecruitmentQaidDetailTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecruitmentQaidDetailTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecruitmentQaidStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecruitmentQaidStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecruitmentQaidTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecruitmentQaidTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecruitmentQaidDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QaidId = table.Column<int>(nullable: true),
                    TypeId = table.Column<int>(nullable: true),
                    AccountTreeId = table.Column<int>(nullable: true),
                    Credit = table.Column<decimal>(nullable: true),
                    Debit = table.Column<decimal>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecruitmentQaidDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecruitmentQaidDetails_AccountTrees_AccountTreeId",
                        column: x => x.AccountTreeId,
                        principalTable: "AccountTrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecruitmentQaidDetails_RecruitmentQaids_QaidId",
                        column: x => x.QaidId,
                        principalTable: "RecruitmentQaids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecruitmentQaidDetails_RecruitmentQaidDetailTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "RecruitmentQaidDetailTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "RecruitmentQaidDetailTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Credit" },
                    { 2, "Debit" }
                });

            migrationBuilder.InsertData(
                table: "RecruitmentQaidStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "مفتوح" },
                    { 2, "مغلق" }
                });

            migrationBuilder.InsertData(
                table: "RecruitmentQaidTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "صرف" },
                    { 2, "قبض" },
                    { 3, "حوالة" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentQaids_FinancialPeriodId",
                table: "RecruitmentQaids",
                column: "FinancialPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentQaidDetails_AccountTreeId",
                table: "RecruitmentQaidDetails",
                column: "AccountTreeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentQaidDetails_QaidId",
                table: "RecruitmentQaidDetails",
                column: "QaidId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentQaidDetails_TypeId",
                table: "RecruitmentQaidDetails",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecruitmentQaids_FinancialPeriods_FinancialPeriodId",
                table: "RecruitmentQaids",
                column: "FinancialPeriodId",
                principalTable: "FinancialPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecruitmentQaids_RecruitmentQaidStatuses_StatusId",
                table: "RecruitmentQaids",
                column: "StatusId",
                principalTable: "RecruitmentQaidStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecruitmentQaids_RecruitmentQaidTypes_TypeId",
                table: "RecruitmentQaids",
                column: "TypeId",
                principalTable: "RecruitmentQaidTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecruitmentQaids_FinancialPeriods_FinancialPeriodId",
                table: "RecruitmentQaids");

            migrationBuilder.DropForeignKey(
                name: "FK_RecruitmentQaids_RecruitmentQaidStatuses_StatusId",
                table: "RecruitmentQaids");

            migrationBuilder.DropForeignKey(
                name: "FK_RecruitmentQaids_RecruitmentQaidTypes_TypeId",
                table: "RecruitmentQaids");

            migrationBuilder.DropTable(
                name: "RecruitmentQaidDetails");

            migrationBuilder.DropTable(
                name: "RecruitmentQaidStatuses");

            migrationBuilder.DropTable(
                name: "RecruitmentQaidTypes");

            migrationBuilder.DropTable(
                name: "RecruitmentQaidDetailTypes");

            migrationBuilder.DropIndex(
                name: "IX_RecruitmentQaids_FinancialPeriodId",
                table: "RecruitmentQaids");

            migrationBuilder.DropColumn(
                name: "FinancialPeriodId",
                table: "RecruitmentQaids");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "RecruitmentQaids",
                newName: "ToAccountId");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "RecruitmentQaids",
                newName: "FromAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_RecruitmentQaids_TypeId",
                table: "RecruitmentQaids",
                newName: "IX_RecruitmentQaids_ToAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_RecruitmentQaids_StatusId",
                table: "RecruitmentQaids",
                newName: "IX_RecruitmentQaids_FromAccountId");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "RecruitmentQaids",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "RecruitmentQaids",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RecruitmentQaids_AccountTrees_FromAccountId",
                table: "RecruitmentQaids",
                column: "FromAccountId",
                principalTable: "AccountTrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecruitmentQaids_AccountTrees_ToAccountId",
                table: "RecruitmentQaids",
                column: "ToAccountId",
                principalTable: "AccountTrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
