using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FwCore.DBContext.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplications",
                columns: table => new
                {
                    LoanApplicationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoanType = table.Column<string>(nullable: false),
                    LoanAmount = table.Column<double>(nullable: false),
                    Installments = table.Column<int>(nullable: false),
                    UserFirstName = table.Column<string>(nullable: false),
                    UserLastName = table.Column<string>(nullable: false),
                    UserFatherName = table.Column<string>(nullable: false),
                    UserMotherName = table.Column<string>(nullable: false),
                    UserPresentAddress = table.Column<string>(nullable: false),
                    UserPermanentAddress = table.Column<string>(nullable: false),
                    UserCity = table.Column<string>(nullable: false),
                    UserState = table.Column<string>(nullable: false),
                    UserZipCode = table.Column<string>(nullable: false),
                    UserCountry = table.Column<string>(nullable: false),
                    UserNationality = table.Column<string>(nullable: false),
                    UserOccupation = table.Column<string>(nullable: false),
                    UserDateOfBirth = table.Column<DateTime>(nullable: false),
                    UserGender = table.Column<string>(nullable: false),
                    UserReligion = table.Column<string>(nullable: false),
                    UserMobile = table.Column<string>(nullable: false),
                    UserEmailAddress = table.Column<string>(nullable: false),
                    UserVerificationType = table.Column<string>(nullable: false),
                    UserVerificationCode = table.Column<string>(nullable: false),
                    GranterFirstName = table.Column<string>(nullable: false),
                    GranterLastName = table.Column<string>(nullable: false),
                    GranterFatherName = table.Column<string>(nullable: false),
                    GranterMotherName = table.Column<string>(nullable: false),
                    GranterPresentAddress = table.Column<string>(nullable: false),
                    GranterPermanentAddress = table.Column<string>(nullable: false),
                    GranterCity = table.Column<string>(nullable: false),
                    GranterState = table.Column<string>(nullable: false),
                    GranterZipCode = table.Column<string>(nullable: false),
                    GranterCountry = table.Column<string>(nullable: false),
                    GranterNationality = table.Column<string>(nullable: false),
                    GranterOccupation = table.Column<string>(nullable: false),
                    GranterDateOfBirth = table.Column<DateTime>(nullable: false),
                    GranterGender = table.Column<string>(nullable: false),
                    GranterReligion = table.Column<string>(nullable: false),
                    GranterRelation = table.Column<string>(nullable: false),
                    GranterMobile = table.Column<string>(nullable: false),
                    GranterEmailAddress = table.Column<string>(nullable: false),
                    GranterVerificationType = table.Column<string>(nullable: false),
                    GranterVerificationCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplications", x => x.LoanApplicationId);
                });

            migrationBuilder.CreateTable(
                name: "LoanTypes",
                columns: table => new
                {
                    LoanTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoanTypeName = table.Column<string>(nullable: true),
                    InterestRate = table.Column<double>(nullable: false),
                    NoOfInstallment = table.Column<int>(nullable: false),
                    LoanAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanTypes", x => x.LoanTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoanStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "VerificationSources",
                columns: table => new
                {
                    VerificationSourceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VerificationType = table.Column<string>(nullable: true),
                    VerificationCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationSources", x => x.VerificationSourceId);
                });

            migrationBuilder.CreateTable(
                name: "Granters",
                columns: table => new
                {
                    GranterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    FatherName = table.Column<string>(nullable: false),
                    MotherName = table.Column<string>(nullable: false),
                    PresentAddress = table.Column<string>(nullable: false),
                    PermanentAddress = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    Nationality = table.Column<string>(nullable: false),
                    Occupation = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Religion = table.Column<string>(nullable: false),
                    Relation = table.Column<string>(nullable: false),
                    Mobile = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    VerificationSourceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Granters", x => x.GranterId);
                    table.ForeignKey(
                        name: "FK_Granters_VerificationSources_VerificationSourceId",
                        column: x => x.VerificationSourceId,
                        principalTable: "VerificationSources",
                        principalColumn: "VerificationSourceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserType = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    FatherName = table.Column<string>(nullable: false),
                    MotherName = table.Column<string>(nullable: false),
                    PresentAddress = table.Column<string>(nullable: false),
                    PermanentAddress = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    Nationality = table.Column<string>(nullable: false),
                    Occupation = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Religion = table.Column<string>(nullable: false),
                    Mobile = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    VerificationSourceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_VerificationSources_VerificationSourceId",
                        column: x => x.VerificationSourceId,
                        principalTable: "VerificationSources",
                        principalColumn: "VerificationSourceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    LoanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoanTypeId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: true),
                    GranterId = table.Column<int>(nullable: true),
                    DocumentId = table.Column<int>(nullable: true),
                    ApprovedBy = table.Column<string>(nullable: true),
                    OperateBy = table.Column<string>(nullable: true),
                    IssueDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanId);
                    table.ForeignKey(
                        name: "FK_Loans_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loans_Granters_GranterId",
                        column: x => x.GranterId,
                        principalTable: "Granters",
                        principalColumn: "GranterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loans_LoanTypes_LoanTypeId",
                        column: x => x.LoanTypeId,
                        principalTable: "LoanTypes",
                        principalColumn: "LoanTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loans_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoanInstallments",
                columns: table => new
                {
                    LoanInstallmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EMI = table.Column<double>(nullable: false),
                    ScheduleDate = table.Column<DateTime>(nullable: false),
                    ActualPayDate = table.Column<DateTime>(nullable: false),
                    Penalty = table.Column<double>(nullable: false),
                    PayAmount = table.Column<double>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    LoanId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanInstallments", x => x.LoanInstallmentId);
                    table.ForeignKey(
                        name: "FK_LoanInstallments_Loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loans",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Granters_VerificationSourceId",
                table: "Granters",
                column: "VerificationSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanInstallments_LoanId",
                table: "LoanInstallments",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_DocumentId",
                table: "Loans",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_GranterId",
                table: "Loans",
                column: "GranterId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_LoanTypeId",
                table: "Loans",
                column: "LoanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_StatusId",
                table: "Loans",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserId",
                table: "Loans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_VerificationSourceId",
                table: "Users",
                column: "VerificationSourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanApplications");

            migrationBuilder.DropTable(
                name: "LoanInstallments");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Granters");

            migrationBuilder.DropTable(
                name: "LoanTypes");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VerificationSources");
        }
    }
}
