using PersonalBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBudget.ViewModels
{
	public class BudgetViewModel
	{
		public Budget Budget { get; set; }

		public List<LineItem> LineItems { get; set; }
	}
}
