using Microsoft.AspNetCore.Mvc;
using PersonalBudget.Models;
using PersonalBudget.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBudget.Controllers
{
	public class SubcategoryController : Controller
	{
		private readonly ISubcategoryRepository _subcategoryRepository;
		private readonly ICategoryRepository _categoryRepository;

		public SubcategoryController(ISubcategoryRepository subcategoryRepository, ICategoryRepository categoryRepository)
		{
			_subcategoryRepository = subcategoryRepository;
			_categoryRepository = categoryRepository;
		}

		public ViewResult List(Guid categoryid)
		{
			Category category = _categoryRepository.GetCategoryById(categoryid);

			SubcategoryViewModel viewModel = new SubcategoryViewModel
			{
				CategoryId = categoryid,
				CategoryName = category.CategoryName,
				BudgetId = (Guid)category.BudgetId,
				Subcategories = _subcategoryRepository.GetSubcategoriesByCategoryId(categoryid)
			};

			return View(viewModel);
		}

		public ViewResult Details(Guid categoryId)
		{
			Subcategory subcategory = new Subcategory
			{
				SubcategoryId = Guid.NewGuid(),
				CategoryId = categoryId
			};

			return View(subcategory);
		}

		[HttpPost]
		public ActionResult Details(Subcategory subcategory)
		{
			_subcategoryRepository.AddSubcategory(subcategory);

			return RedirectToAction("List", new { categoryId = subcategory.CategoryId });
		}
	}
}
