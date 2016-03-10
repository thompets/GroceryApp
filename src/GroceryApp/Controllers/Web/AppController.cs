using Microsoft.AspNet.Mvc;
using System;

namespace GroceryApp.Controllers.Web
{
	public class AppController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Admin()
		{
			return View();
		}		
	}
}