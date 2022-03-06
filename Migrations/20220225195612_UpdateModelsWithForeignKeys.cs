using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalBudget.Migrations
{
    public partial class UpdateModelsWithForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "BudgetId",
                keyValue: new Guid("f28b9a0d-11b1-4c49-badf-fdfc80b1f5ab"));

            migrationBuilder.InsertData(
                table: "Budgets",
                columns: new[] { "BudgetId", "BudgetName", "RunningTotal" },
                values: new object[] { new Guid("9270a1fa-483e-43a7-bd2e-be05a5d0e315"), "2021 Budget", 0m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "BudgetId",
                keyValue: new Guid("9270a1fa-483e-43a7-bd2e-be05a5d0e315"));

            migrationBuilder.InsertData(
                table: "Budgets",
                columns: new[] { "BudgetId", "BudgetName", "RunningTotal" },
                values: new object[] { new Guid("f28b9a0d-11b1-4c49-badf-fdfc80b1f5ab"), "2021 Budget", 0m });
        }
    }
}
