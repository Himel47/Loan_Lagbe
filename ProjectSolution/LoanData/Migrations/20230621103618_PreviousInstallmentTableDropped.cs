using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanData.Migrations
{
    /// <inheritdoc />
    public partial class PreviousInstallmentTableDropped : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "LoanDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "LoanDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "LoanPaymentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPaidDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanPaymentDetails", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanPaymentDetails");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "LoanDetails");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "LoanDetails");

            migrationBuilder.CreateTable(
                name: "Installments",
                columns: table => new
                {
                    InstallmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanBasicLoanId = table.Column<long>(type: "bigint", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    InstallmentCount = table.Column<int>(type: "int", nullable: false),
                    InstallmentDays = table.Column<int>(type: "int", nullable: false),
                    InstalmentAmount = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<long>(type: "bigint", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    PaidAmount = table.Column<int>(type: "int", nullable: false),
                    RemainingAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Installments", x => x.InstallmentId);
                    table.ForeignKey(
                        name: "FK_Installments_LoanDetails_LoanBasicLoanId",
                        column: x => x.LoanBasicLoanId,
                        principalTable: "LoanDetails",
                        principalColumn: "LoanId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Installments_LoanBasicLoanId",
                table: "Installments",
                column: "LoanBasicLoanId");
        }
    }
}
