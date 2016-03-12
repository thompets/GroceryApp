using System.ComponentModel.DataAnnotations;

namespace GroceryApp.Models
{
	public class GroceryCategory
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
	}
}