using Microsoft.AspNet.Identity.EntityFramework;

namespace GroceryApp.Models
{
	public class User : IdentityUser
	{
		public bool IsAdmin { get; set; }
	}
}