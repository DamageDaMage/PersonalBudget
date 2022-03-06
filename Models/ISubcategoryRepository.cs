using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBudget.Models
{
	public interface ISubcategoryRepository
	{
		Subcategory GetSubcategoryById(Guid subcategoryId);

		IEnumerable<Subcategory> GetSubcategoriesByCategoryId(Guid categoryId);

		void AddSubcategory(Subcategory subcategory);
	}
}
