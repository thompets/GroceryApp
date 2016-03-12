using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace GroceryApp.Models
{
	public class GroceryAppContext : IdentityDbContext<User>
	{
		public GroceryAppContext()
		{
			Database.EnsureCreated();
		}

		public DbSet<GroceryCategory> Categories { get; set; }
		public DbSet<GroceryStore> Stores { get; set; }
		public DbSet<GroceryTrip> Trips { get; set; }
		public DbSet<Stop> Stops { get; set; }
		public DbSet<StopCategoryTotal> StopTotals { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var connString = Startup.Configuration["Data:GroceryAppConnection"];
			optionsBuilder.UseSqlServer(connString);

			base.OnConfiguring(optionsBuilder);
		}
	}
}