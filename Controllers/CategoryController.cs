using Microsoft.AspNetCore.Mvc;
using PersonalBudget.Models;
using PersonalBudget.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBudget.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryRepository _categoryRepository;

		public CategoryController(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public ViewResult List(Guid budgetId)
		{
			CategoryViewModel viewModel = new CategoryViewModel
			{
				BudgetId = budgetId,
				Categories = _categoryRepository.GetCategoriesByBudgetId(budgetId)
			};

			return View(viewModel);
		}

		public ViewResult Details(Guid budgetId)
		{
			Category category = new Category
			{
				CategoryId = Guid.NewGuid(),
				BudgetId = budgetId
			};

			return View(category);
		}

		[HttpPost]
		public ActionResult Details(Category category)
		{
			_categoryRepository.AddCategory(category);

			return RedirectToAction("List", new { budgetId = category.BudgetId });
		}
	}
}
