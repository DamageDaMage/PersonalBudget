using PersonalBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBudget.ViewModels
{
	public class HomeViewModel
	{
		public IEnumerable<Budget> Budgets { get; set; }
	}
}
