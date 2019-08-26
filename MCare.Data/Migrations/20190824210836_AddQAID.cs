using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NajmetAlraqee.Data.Migrations
{
    public partial class AddQAID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "Contracts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RecruitmentQaids",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QaidDate = table.Column<string>(nullable: true),
                    FromAccountId = table.Column<int>(nullable: true),
                    ToAccountId = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecruitmentQaids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecruitmentQaids_AccountTrees_FromAccountId",
                        column: x => x.FromAccountId,
                        principalTable: "AccountTrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecruitmentQaids_AccountTrees_ToAccountId",
                        column: x => x.ToAccountId,
                        principalTable: "AccountTrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentQaids_FromAccountId",
                table: "RecruitmentQaids",
                column: "FromAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentQaids_ToAccountId",
                table: "RecruitmentQaids",
                column: "ToAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecruitmentQaids");

            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "Contracts");
        }
    }
}
