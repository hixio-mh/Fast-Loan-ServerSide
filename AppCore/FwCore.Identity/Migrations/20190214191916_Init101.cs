using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FwCore.Identity.Migrations
{
    public partial class Init101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoanMannageId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LoanMannage",
                columns: table => new
                {
                    LoanMannageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApprovedBy = table.Column<string>(nullable: true),
                    OperateBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanMannage", x => x.LoanMannageId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LoanMannageId",
                table: "AspNetUsers",
                column: "LoanMannageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_LoanMannage_LoanMannageId",
                table: "AspNetUsers",
                column: "LoanMannageId",
                principalTable: "LoanMannage",
                principalColumn: "LoanMannageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_LoanMannage_LoanMannageId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "LoanMannage");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LoanMannageId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LoanMannageId",
                table: "AspNetUsers");
        }
    }
}
