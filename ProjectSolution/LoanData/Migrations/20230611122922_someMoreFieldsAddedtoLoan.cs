using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanData.Migrations
{
    /// <inheritdoc />
    public partial class someMoreFieldsAddedtoLoan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IncludedTax",
                table: "LoanDetails",
                newName: "TotalCharge");

            migrationBuilder.AddColumn<int>(
                name: "IncludedInterest",
                table: "LoanDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InterestRate",
                table: "LoanDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsLoanPaymentComplete",
                table: "LoanDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PerInstallmentAmount",
                table: "LoanDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubmissionTimeInMonth",
                table: "LoanDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncludedInterest",
                table: "LoanDetails");

            migrationBuilder.DropColumn(
                name: "InterestRate",
                table: "LoanDetails");

            migrationBuilder.DropColumn(
                name: "IsLoanPaymentComplete",
                table: "LoanDetails");

            migrationBuilder.DropColumn(
                name: "PerInstallmentAmount",
                table: "LoanDetails");

            migrationBuilder.DropColumn(
                name: "SubmissionTimeInMonth",
                table: "LoanDetails");

            migrationBuilder.RenameColumn(
                name: "TotalCharge",
                table: "LoanDetails",
                newName: "IncludedTax");
        }
    }
}
