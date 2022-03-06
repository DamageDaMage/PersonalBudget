using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBudget.Models
{
	public interface ILineItemRepository
	{
		IEnumerable<LineItem> GetLineItemsByBudgetId(Guid budgetId);

		IEnumerable<LineItem> GetLineItemsByCategoryId(Guid categoryId);

		IEnumerable<LineItem> GetLineItemsBySubcategoryId(Guid subcategoryId);

		public void AddLineItem(LineItem lineItem);
	}
}
