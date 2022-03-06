using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PersonalBudget.Models;
using PersonalBudget.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PersonalBudget.Models.Enums;

namespace PersonalBudget.Controllers
{
	public class BudgetController : Controller
	{
		private readonly IBudgetRepository _budgetRepository;
		private readonly ICategoryRepository _categoryRepository;
		private readonly ISubcategoryRepository _subcategoryRepository;
		private readonly ILineItemRepository _lineItemRepository;

		public BudgetController(IBudgetRepository budgetRepository, ICategoryRepository categoryRepository, ISubcategoryRepository subcategoryRepository, ILineItemRepository lineItemRepository)
		{
			_budgetRepository = budgetRepository;
			_categoryRepository = categoryRepository;
			_subcategoryRepository = subcategoryRepository;
			_lineItemRepository = lineItemRepository;
		}

		public IActionResult Details(Guid id)
		{
			BudgetViewModel viewModel = new BudgetViewModel();
			viewModel.Budget = _budgetRepository.GetBudgetById(id);

			if(viewModel.Budget == null)
			{
				return NotFound();
			}

			viewModel.LineItems = _lineItemRepository.GetLineItemsByBudgetId(id).ToList();

			foreach (LineItem lineItem in viewModel.LineItems)
			{
				lineItem.Category = _categoryRepository.GetCategoryById(lineItem.CategoryId);
				lineItem.Subcategory = _subcategoryRepository.GetSubcategoryById(lineItem.SubcategoryId);
			}

			return View(viewModel);
		}

		public IActionResult AddLineItem(Guid budgetId)
		{
			AddLineItemViewModel viewModel = new AddLineItemViewModel();
			List<SelectListItem> categoriesList = new List<SelectListItem>();
			List<SelectListItem> subcategoriesList = new List<SelectListItem>();

			viewModel.BudgetId = budgetId;

			List<Category> categories = _categoryRepository.GetCategoriesByBudgetId(budgetId).ToList();

			foreach(Category category in categories)
			{
				SelectListItem selectItem = new SelectListItem
				{
					Text = category.CategoryName,
					Value = category.CategoryId.ToString()
				};

				categoriesList.Add(selectItem);
			}

			viewModel.Categories = categoriesList;

			List<Subcategory> subcategories = new List<Subcategory>();

			foreach(Category category in categories)
			{
				subcategories.AddRange(_subcategoryRepository.GetSubcategoriesByCategoryId(category.CategoryId));
			}

			foreach(Subcategory subcategory in subcategories)
			{
				SelectListItem selectItem = new SelectListItem
				{
					Text = subcategory.SubcategoryName,
					Value = subcategory.SubcategoryId.ToString()
				};

				subcategoriesList.Add(selectItem);
			}

			viewModel.Subcategories = subcategoriesList;

			viewModel.TransactionTypes = new List<SelectListItem>
			{
				new SelectListItem
				{
					Text = nameof(TransactionType.Expense),
					Value = TransactionType.Expense.ToString()
				},
				new SelectListItem
				{
					Text = nameof(TransactionType.Income),
					Value = TransactionType.Income.ToString()
				}
			};

			viewModel.LineItem = new LineItem
			{
				LineItemId = Guid.NewGuid(),
				BudgetId = budgetId,
				Date = DateTime.Now
			};

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult AddLineItem(AddLineItemViewModel viewModel)
		{
			_lineItemRepository.AddLineItem(viewModel.LineItem);

			_budgetRepository.UpdateRunningTotal(viewModel.BudgetId, viewModel.LineItem.Amount, viewModel.LineItem.TransactionType);

			return RedirectToAction("Details", new { id = viewModel.BudgetId });
		}
	}
}
