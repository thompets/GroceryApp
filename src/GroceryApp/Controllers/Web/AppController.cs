using GroceryApp.Models;
using Microsoft.AspNet.Mvc;

namespace GroceryApp.Controllers.Web
{
	public class AppController : Controller
	{
		private GroceryContext _context;
		private IGroceryRepository _repository;

		public AppController(GroceryContext context, IGroceryRepository repository)
		{
			_context = context;
			_repository = repository;
		}

		public IActionResult Index()
		{
			var trips = _repository.GetAllTripsWithStops();

			return View(trips);
		}

		public IActionResult Admin()
		{
			return View();
		}		
	}
}