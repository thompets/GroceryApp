using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryApp.Models
{
	public class GroceryContextSeedData
	{
		private GroceryContext _context;
		private IGroceryRepository _repository;

		public GroceryContextSeedData(GroceryContext context, IGroceryRepository repository)
		{
			_context = context;
			_repository = repository;
		}

		public void EnsureSeedData()
		{
			if (!_context.Stores.Any())
			{
				var stores = new List<GroceryStore>()
				{
					new GroceryStore() { Name = "EarthFare" },
					new GroceryStore() { Name = "Publix" },
					new GroceryStore() { Name = "Target" },
					new GroceryStore() { Name = "Walmart" },
					new GroceryStore() { Name = "WholeFoods" }
				};

				_context.Stores.AddRange(stores);
				_context.SaveChanges();
			}

			if (!_context.Categories.Any())
			{
				var categories = new List<GroceryCategory>()
				{
					new GroceryCategory() { Name = "Alcohol" },
					new GroceryCategory() { Name = "Dairy" },
					new GroceryCategory() { Name = "Dessert" },
					new GroceryCategory() { Name = "DryGoods" },
					new GroceryCategory() { Name = "FrozenGoods" },
					new GroceryCategory() { Name = "HouseholdGoods" },
					new GroceryCategory() { Name = "Meat" },
					new GroceryCategory() { Name = "Produce" },
					new GroceryCategory() { Name = "Toiletries" }
				};

				_context.AddRange(categories);
				_context.SaveChanges();
			}

			if (!_context.Trips.Any())
			{
				// Initialize new GroceryTrip
				var firstGroceryTrip = new GroceryTrip()
				{
					TripDate = new DateTime(2016, 03, 12),
					TotalSpent = 145.20M,
					Stops = new List<Stop>()
					{
						new Stop()
						{
							Store = _repository.GetStoreByName("Publix"),
							StopTotals = new List<StopCategoryTotal>()
							{
								new StopCategoryTotal()
								{
									Category = _repository.GetCategoryByName("Produce"),
									AmountSpent = 23.50M,
								},

								new StopCategoryTotal()
								{
									Category = _repository.GetCategoryByName("DryGoods"),
									AmountSpent = 14.00M
								}
							},
							TotalSpent = 37.50M
						},

						new Stop()
						{
							Store = _repository.GetStoreByName("EarthFare"),
							StopTotals = new List<StopCategoryTotal>()
							{
								new StopCategoryTotal()
								{
									Category = _repository.GetCategoryByName("Produce"),
									AmountSpent = 67.70M
								},

								new StopCategoryTotal()
								{
									Category = _repository.GetCategoryByName("Meat"),
									AmountSpent = 40.00M
								}
							},
							TotalSpent = 107.70M
						}
					}
				};

				_context.Trips.Add(firstGroceryTrip);
				_context.Stops.AddRange(firstGroceryTrip.Stops);

				_context.SaveChanges();
			}
		}
	}
}