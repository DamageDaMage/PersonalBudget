using PersonalBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBudget.ViewModels
{
	public class SubcategoryViewModel
	{
		public Guid CategoryId { get; set; }
		public string CategoryName { get; set; }
		public Guid BudgetId { get; set; }
		public IEnumerable<Subcategory> Subcategories { get; set; }
	}
}
