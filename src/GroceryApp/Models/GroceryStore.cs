using System.ComponentModel.DataAnnotations;

namespace GroceryApp.Models
{
	public class GroceryStore
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
	}
}