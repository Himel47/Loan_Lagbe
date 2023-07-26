using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanData.Migrations
{
    /// <inheritdoc />
    public partial class NamesAddedinLoanSection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "LoanPersonalInstallments",
                newName: "MemberNID");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "LoanDetails",
                newName: "MemberNID");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "InstallmentDetails",
                newName: "MemberNID");

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "LoanPersonalInstallments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MemberName",
                table: "LoanPersonalInstallments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "LoanDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MemberName",
                table: "LoanDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "InstallmentDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MemberName",
                table: "InstallmentDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "LoanPersonalInstallments");

            migrationBuilder.DropColumn(
                name: "MemberName",
                table: "LoanPersonalInstallments");

            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "LoanDetails");

            migrationBuilder.DropColumn(
                name: "MemberName",
                table: "LoanDetails");

            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "InstallmentDetails");

            migrationBuilder.DropColumn(
                name: "MemberName",
                table: "InstallmentDetails");

            migrationBuilder.RenameColumn(
                name: "MemberNID",
                table: "LoanPersonalInstallments",
                newName: "MemberId");

            migrationBuilder.RenameColumn(
                name: "MemberNID",
                table: "LoanDetails",
                newName: "MemberId");

            migrationBuilder.RenameColumn(
                name: "MemberNID",
                table: "InstallmentDetails",
                newName: "MemberId");
        }
    }
}
