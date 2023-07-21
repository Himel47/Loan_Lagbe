using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanData.Migrations
{
    /// <inheritdoc />
    public partial class SomeChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResultString",
                table: "LoanDetails");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPaid",
                table: "LoanPersonalInstallments",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "InstallmentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstallmentCount = table.Column<int>(type: "int", nullable: false),
                    InstallmentDays = table.Column<int>(type: "int", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    MemberId = table.Column<long>(type: "bigint", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallmentDetails", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstallmentDetails");

            migrationBuilder.AlterColumn<string>(
                name: "IsPaid",
                table: "LoanPersonalInstallments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "ResultString",
                table: "LoanDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
