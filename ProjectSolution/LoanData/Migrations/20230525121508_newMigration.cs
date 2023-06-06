using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanData.Migrations
{
    /// <inheritdoc />
    public partial class newMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTypes", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    NID = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Institute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalFamilyMember = table.Column<int>(type: "int", nullable: false),
                    NoOfEarningMember = table.Column<int>(type: "int", nullable: false),
                    MonthlyIncome = table.Column<int>(type: "int", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.NID);
                });

            migrationBuilder.CreateTable(
                name: "SubmissionPeriods",
                columns: table => new
                {
                    SubmissionPeriodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmissionPeriodDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmissionPeriods", x => x.SubmissionPeriodId);
                });

            migrationBuilder.CreateTable(
                name: "CollectionGroups",
                columns: table => new
                {
                    CollectionGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollectionGroupName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    MemberNID = table.Column<long>(type: "bigint", nullable: true),
                    CollectedMoney = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionGroups", x => x.CollectionGroupId);
                    table.ForeignKey(
                        name: "FK_CollectionGroups_Members_MemberNID",
                        column: x => x.MemberNID,
                        principalTable: "Members",
                        principalColumn: "NID");
                });

            migrationBuilder.CreateTable(
                name: "LoanGroups",
                columns: table => new
                {
                    LoanGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanGroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    MemberNID = table.Column<long>(type: "bigint", nullable: true),
                    TotalLoanAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanGroups", x => x.LoanGroupId);
                    table.ForeignKey(
                        name: "FK_LoanGroups_Members_MemberNID",
                        column: x => x.MemberNID,
                        principalTable: "Members",
                        principalColumn: "NID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionGroups_MemberNID",
                table: "CollectionGroups",
                column: "MemberNID");

            migrationBuilder.CreateIndex(
                name: "IX_LoanGroups_MemberNID",
                table: "LoanGroups",
                column: "MemberNID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionGroups");

            migrationBuilder.DropTable(
                name: "GroupTypes");

            migrationBuilder.DropTable(
                name: "LoanGroups");

            migrationBuilder.DropTable(
                name: "SubmissionPeriods");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
