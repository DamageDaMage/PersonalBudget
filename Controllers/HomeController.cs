using Microsoft.AspNetCore.Mvc;
using PersonalBudget.Models;
using PersonalBudget.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBudget.Controllers
{
	public class HomeController : Controller
	{
		private readonly IBudgetRepository _budgetRepository;

		public HomeController(IBudgetRepository budgetRepository)
		{
			_budgetRepository = budgetRepository;
		}

		public IActionResult Index()
		{
			HomeViewModel viewModel = new HomeViewModel
			{
				Budgets = _budgetRepository.GetBudgets()
			};

			return View(viewModel);
		}
	}
}
