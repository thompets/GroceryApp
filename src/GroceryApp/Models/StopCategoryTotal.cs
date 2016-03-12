namespace GroceryApp.Models
{
	public class StopCategoryTotal
	{
		public int Id { get; set; }
		public GroceryCategory Category { get; set; }
		public decimal AmountSpent { get; set; }
	}
}