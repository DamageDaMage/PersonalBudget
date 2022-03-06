using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalBudget.Migrations
{
    public partial class AddLinksBetweenBudgetsCategoriesAndSubcategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "BudgetId",
                keyValue: new Guid("a7c55592-9852-4b59-b8ed-711d7b773ace"));

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Subcategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BudgetId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Budgets",
                columns: new[] { "BudgetId", "BudgetName", "RunningTotal" },
                values: new object[] { new Guid("a52c4865-fd8d-4ab2-89d8-850354d6ef22"), "2021 Budget", 0m });

            migrationBuilder.CreateIndex(
                name: "IX_Subcategories_CategoryId",
                table: "Subcategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_BudgetId",
                table: "Categories",
                column: "BudgetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Budgets_BudgetId",
                table: "Categories",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "BudgetId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategories_Categories_CategoryId",
                table: "Subcategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Budgets_BudgetId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Categories_CategoryId",
                table: "Subcategories");

            migrationBuilder.DropIndex(
                name: "IX_Subcategories_CategoryId",
                table: "Subcategories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_BudgetId",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "BudgetId",
                keyValue: new Guid("a52c4865-fd8d-4ab2-89d8-850354d6ef22"));

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Subcategories");

            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "Categories");

            migrationBuilder.InsertData(
                table: "Budgets",
                columns: new[] { "BudgetId", "BudgetName", "RunningTotal" },
                values: new object[] { new Guid("a7c55592-9852-4b59-b8ed-711d7b773ace"), "2021 Budget", 0m });
        }
    }
}
