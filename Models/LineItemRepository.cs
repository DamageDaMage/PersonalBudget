using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBudget.Models
{
	public class LineItemRepository : ILineItemRepository
	{
		private readonly AppDbContext _appDbContext;

		public LineItemRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public IEnumerable<LineItem> GetLineItemsByBudgetId(Guid budgetId)
		{
			return _appDbContext.LineItems.Where(l => l.BudgetId == budgetId);
		}

		public IEnumerable<LineItem> GetLineItemsByCategoryId(Guid categoryId)
		{
			return _appDbContext.LineItems.Where(l => l.CategoryId == categoryId);
		}

		public IEnumerable<LineItem> GetLineItemsBySubcategoryId(Guid subcategoryId)
		{
			return _appDbContext.LineItems.Where(l => l.SubcategoryId == subcategoryId);
		}

		public void AddLineItem(LineItem lineItem)
		{
			_appDbContext.LineItems.Add(lineItem);
			_appDbContext.SaveChanges();
		}
	}
}
