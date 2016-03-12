using System;
using System.Collections.Generic;

namespace GroceryApp.Models
{
	public class GroceryTrip
	{
		public int Id { get; set; }
		public DateTime TripDate { get; set; }
		public decimal TotalSpent { get; set; }

		public ICollection<Stop> Stops { get; set; }
	}
}