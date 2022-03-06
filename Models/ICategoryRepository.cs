using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBudget.Models
{
	public interface ICategoryRepository
	{
		Category GetCategoryById(Guid categoryId);

		IEnumerable<Category> GetCategoriesByBudgetId(Guid budgetId);

		void AddCategory(Category category);
	}
}
