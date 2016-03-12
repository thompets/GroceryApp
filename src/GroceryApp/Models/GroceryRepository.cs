using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryApp.Models
{
	public class GroceryRepository : IGroceryRepository
	{
		private GroceryContext _context;
		private ILogger<GroceryRepository> _logger;

		public GroceryRepository(GroceryContext context, ILogger<GroceryRepository> logger)
		{
			_context = context;
			_logger = logger;
		}

		public IEnumerable<GroceryTrip> GetAllTrips()
		{
			try
			{
				return _context.Trips.OrderBy(t => t.TripDate).ToList();
			}
			catch (Exception ex)
			{
				_logger.LogError("Error getting trips from database.", ex);
				return null;
			}
		}

		public IEnumerable<GroceryTrip> GetAllTripsWithStops()
		{
			try
			{
				return _context.Trips
					.Include(t => t.Stops)
					.OrderBy(t => t.TripDate)
					.ToList();
			}
			catch (Exception ex)
			{
				_logger.LogError("Error getting trips with stops from database.", ex);
				return null;
			}
		}

		public GroceryCategory GetCategoryByName(string categoryName)
		{
			return _context.Categories
					.Where(c => c.Name == categoryName)
					.FirstOrDefault();
		}		

		public IEnumerable<StopCategoryTotal> GetCategoryTotalsForStop(int stopId)
		{
			try
			{
				return _context.StopTotals
					.Where(s => s.StopId == stopId)
					.OrderBy(s => s.Category)
					.ToList();
			}
			catch (Exception ex)
			{
				_logger.LogError("Error getting category totals for the stop", ex);
				return null;
			}
		}

		public GroceryStore GetStoreByName(string groceryName)
		{
			return _context.Stores
				.Where(s => s.Name == groceryName)
				.FirstOrDefault();
		}
	}
}