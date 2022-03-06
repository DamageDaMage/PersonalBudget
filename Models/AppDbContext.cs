using Microsoft.EntityFrameworkCore;
using System;

namespace PersonalBudget.Models
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		public DbSet<Budget> Budgets { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Subcategory> Subcategories { get; set; }
		public DbSet<LineItem> LineItems { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Budget>().HasData(new Budget
			{
				BudgetId = Guid.NewGuid(),
				BudgetName = "2021 Budget",
				RunningTotal = decimal.Zero
			});
		}
	}
}
