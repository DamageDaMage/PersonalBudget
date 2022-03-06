using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBudget.Models
{
	public class Subcategory
	{
		[Key]
		[Required]
		public Guid SubcategoryId { get; set; }

		[Required]
		public string SubcategoryName { get; set; }

		[Required]
		public string SubcategoryDescription { get; set; }

		public Guid? CategoryId { get; set; }

		[ForeignKey("CategoryId")]
		public virtual Category Category { get; set; }
	}
}
