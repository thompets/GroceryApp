using System.Collections.Generic;

namespace GroceryApp.Models
{
	public interface IGroceryRepository
	{
		IEnumerable<GroceryTrip> GetAllTrips();
		IEnumerable<GroceryTrip> GetAllTripsWithStops();
		IEnumerable<StopCategoryTotal> GetCategoryTotalsForStop(int stopId);
		GroceryCategory GetCategoryByName(string categoryName);
		GroceryStore GetStoreByName(string groceryName);
	}
}