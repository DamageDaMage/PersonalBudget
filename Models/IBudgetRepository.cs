using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PersonalBudget.Models.Enums;

namespace PersonalBudget.Models
{
	public interface IBudgetRepository
	{
		Budget GetBudgetById(Guid id);

		IEnumerable<Budget> GetBudgets();

		public void UpdateRunningTotal(Guid id, decimal amount, TransactionType transactionType);
	}
}
