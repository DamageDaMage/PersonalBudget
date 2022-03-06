using Microsoft.AspNetCore.Mvc.Rendering;
using PersonalBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBudget.ViewModels
{
	public class AddLineItemViewModel
	{
		public Guid BudgetId { get; set; }

		public IEnumerable<SelectListItem> Categories { get; set; }

		public IEnumerable<SelectListItem> Subcategories { get; set; }

		public IEnumerable<SelectListItem> TransactionTypes { get; set; }

		public LineItem LineItem { get; set; }
	}
}
