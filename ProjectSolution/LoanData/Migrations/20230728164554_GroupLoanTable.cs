using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanData.Migrations
{
    /// <inheritdoc />
    public partial class GroupLoanTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupLoans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupLoanId = table.Column<long>(type: "bigint", nullable: false),
                    IsLoanRunning = table.Column<bool>(type: "bit", nullable: false),
                    MemberNID = table.Column<long>(type: "bigint", nullable: false),
                    MemberName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupLoans", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupLoans");
        }
    }
}
