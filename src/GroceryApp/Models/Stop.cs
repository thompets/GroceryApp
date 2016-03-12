using System;
using System.Collections.Generic;

namespace GroceryApp.Models
{
	public class Stop
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public GroceryStore Store { get; set; }
		public List<StopCategoryTotal> StopTotals { get; set; }
		public decimal TotalSpent { get; set; }
	}
}