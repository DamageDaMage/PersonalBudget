using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PersonalBudget.Models.Enums;

namespace PersonalBudget.Models
{
	public class BudgetRepository : IBudgetRepository
	{
		private readonly AppDbContext _appDbContext;

		public BudgetRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public Budget GetBudgetById(Guid id)
		{
			return _appDbContext.Budgets.FirstOrDefault(b => b.BudgetId == id);
		}

		public IEnumerable<Budget> GetBudgets()
		{
			return _appDbContext.Budgets.ToList();
		}

		public void UpdateRunningTotal(Guid id, decimal amount, TransactionType transactionType)
		{
			Budget budget = _appDbContext.Budgets.FirstOrDefault(b => b.BudgetId == id);

			if(transactionType == TransactionType.Expense)
			{
				budget.RunningTotal -= amount;
			}
			else if(transactionType == TransactionType.Income)
			{
				budget.RunningTotal += amount;
			}

			_appDbContext.SaveChanges();
		}
	}
}
