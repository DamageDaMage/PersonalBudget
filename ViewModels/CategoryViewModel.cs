using PersonalBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBudget.ViewModels
{
	public class CategoryViewModel
	{
		public Guid BudgetId { get; set; }
		public IEnumerable<Category> Categories { get; set; }
	}
}
