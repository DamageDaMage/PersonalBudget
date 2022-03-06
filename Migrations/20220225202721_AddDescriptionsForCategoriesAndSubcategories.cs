using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalBudget.Migrations
{
    public partial class AddDescriptionsForCategoriesAndSubcategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "BudgetId",
                keyValue: new Guid("9270a1fa-483e-43a7-bd2e-be05a5d0e315"));

            migrationBuilder.AddColumn<string>(
                name: "SubcategoryDescription",
                table: "Subcategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategoryDescription",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Budgets",
                columns: new[] { "BudgetId", "BudgetName", "RunningTotal" },
                values: new object[] { new Guid("048e95d1-3840-4439-bc76-7e1c64973105"), "2021 Budget", 0m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "BudgetId",
                keyValue: new Guid("048e95d1-3840-4439-bc76-7e1c64973105"));

            migrationBuilder.DropColumn(
                name: "SubcategoryDescription",
                table: "Subcategories");

            migrationBuilder.DropColumn(
                name: "CategoryDescription",
                table: "Categories");

            migrationBuilder.InsertData(
                table: "Budgets",
                columns: new[] { "BudgetId", "BudgetName", "RunningTotal" },
                values: new object[] { new Guid("9270a1fa-483e-43a7-bd2e-be05a5d0e315"), "2021 Budget", 0m });
        }
    }
}
