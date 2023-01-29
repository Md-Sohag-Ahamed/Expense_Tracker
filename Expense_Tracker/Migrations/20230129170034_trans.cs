using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Expense_Tracker.Migrations
{
    public partial class trans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "ToDate",
                table: "Transactions",
                newName: "ExpenseDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpenseDate",
                table: "Transactions",
                newName: "ToDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "FromDate",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
