using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBudget.Models
{
	public class SubcategoryRepository : ISubcategoryRepository
	{
		private readonly AppDbContext _appDbContext;

		public SubcategoryRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}
		public void AddSubcategory(Subcategory subcategory)
		{
			_appDbContext.Subcategories.Add(subcategory);
			_appDbContext.SaveChanges();
		}

		public IEnumerable<Subcategory> GetSubcategoriesByCategoryId(Guid categoryId)
		{
			return _appDbContext.Subcategories.Where(s => s.CategoryId == categoryId).ToList();
		}

		public Subcategory GetSubcategoryById(Guid subcategoryId)
		{
			return _appDbContext.Subcategories.FirstOrDefault(s => s.SubcategoryId == subcategoryId);
		}
	}
}
