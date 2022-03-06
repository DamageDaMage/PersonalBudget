using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static PersonalBudget.Models.Enums;

namespace PersonalBudget.Models
{
	public class LineItem
	{
		public Guid LineItemId { get; set; }
		public Guid BudgetId { get; set; }
		public Budget Budget { get; set; }
		public Guid CategoryId { get; set; }
		public Category Category { get; set; }
		public Guid SubcategoryId { get; set; }
		public Subcategory Subcategory { get; set; }
		public TransactionType TransactionType { get; set; }
		[DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
		public decimal Amount { get; set; }
		public DateTime Date { get; set; }
		public string Source { get; set; }
		public string Description { get; set; }
		
	}
}
