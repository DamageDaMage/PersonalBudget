using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBudget.Models
{
	public class Budget
	{
		[Key]
		[Required]
		public Guid BudgetId { get; set; }

		[Required]
		public string BudgetName { get; set; }

		public decimal RunningTotal { get; set; }

		[ForeignKey("CategoryId")]
		public virtual IEnumerable<Category> Categories { get; set; }
	}
}
