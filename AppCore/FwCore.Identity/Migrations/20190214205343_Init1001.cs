using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FwCore.Identity.Migrations
{
    public partial class Init1001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "LoanManage",
                columns: table => new
                {
                    LoanManageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApprovedBy = table.Column<string>(nullable: true),
                    OperateBy = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanManage", x => x.LoanManageId);
                    table.ForeignKey(
                        name: "FK_LoanManage_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanManage_ApplicationUserId",
                table: "LoanManage",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanManage");

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
    }
}
