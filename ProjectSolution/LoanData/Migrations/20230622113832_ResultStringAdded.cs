using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanData.Migrations
{
    /// <inheritdoc />
    public partial class ResultStringAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResultString",
                table: "LoanDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResultString",
                table: "LoanDetails");
        }
    }
}
