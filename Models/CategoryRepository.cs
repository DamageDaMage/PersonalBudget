using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBudget.Models
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly AppDbContext _appDbContext;

		public CategoryRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public Category GetCategoryById(Guid categoryId)
		{
			return _appDbContext.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
		}

		public IEnumerable<Category> GetCategoriesByBudgetId(Guid budgetId)
		{
			return _appDbContext.Categories.Where(c => c.BudgetId == budgetId).ToList();
		}

		public void AddCategory(Category category)
		{
			_appDbContext.Categories.Add(category);
			_appDbContext.SaveChanges();
		}
	}
}
