using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBudget.Models
{
	public class Category
	{
		[Key]
		[Required]
		public Guid CategoryId { get; set; }

		[Required]
		public string CategoryName { get; set; }

		[Required]
		public string CategoryDescription { get; set; }

		public Guid? BudgetId { get; set; }

		[ForeignKey("BudgetId")]
		public virtual Budget Budget { get; set; }

		[ForeignKey("SubcategoryId")]
		public virtual IEnumerable<Subcategory> Subcategories { get; set; }
	}
}
