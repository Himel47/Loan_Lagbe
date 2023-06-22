using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanData.Migrations
{
    /// <inheritdoc />
    public partial class blank : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Installments_SubmissionPeriods_SubmissionPeriodId",
                table: "Installments");

            migrationBuilder.DropIndex(
                name: "IX_Installments_SubmissionPeriodId",
                table: "Installments");

            migrationBuilder.DropColumn(
                name: "SubmissionPeriodId",
                table: "Installments");

            migrationBuilder.AddColumn<int>(
                name: "InstallmentDays",
                table: "LoanDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstallmentDays",
                table: "LoanDetails");

            migrationBuilder.AddColumn<int>(
                name: "SubmissionPeriodId",
                table: "Installments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Installments_SubmissionPeriodId",
                table: "Installments",
                column: "SubmissionPeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Installments_SubmissionPeriods_SubmissionPeriodId",
                table: "Installments",
                column: "SubmissionPeriodId",
                principalTable: "SubmissionPeriods",
                principalColumn: "SubmissionPeriodId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
