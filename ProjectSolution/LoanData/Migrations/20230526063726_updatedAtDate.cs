using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanData.Migrations
{
    /// <inheritdoc />
    public partial class updatedAtDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "LoanGroups",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "CollectionGroups",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "LoanGroups");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "CollectionGroups");
        }
    }
}
