using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Builder;
using Newtonsoft.Json.Serialization;
using GroceryApp.Models;
using Microsoft.Extensions.Logging;

namespace GroceryApp
{
	public class Startup
	{
		public static IConfiguration Configuration;

		public Startup(IApplicationEnvironment appEnv)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(appEnv.ApplicationBasePath)
				.AddJsonFile("config.json");

			Configuration = builder.Build();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc()
			.AddJsonOptions(opt => 
			{
				opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			});

			//services.AddIdentity<User, IdentityRole>(config => 
			//{
			//	config.User.RequireUniqueEmail = true;
			//	config.Password.RequiredLength = 8;
			//	config.Cookies.ApplicationCookie.LoginPath = "Auth/Login";
			//	config.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents()
			//	{
			//		OnRedirectToLogin = ctx =>
			//		{
			//			if (ctx.Request.Path.StartsWithSegments("/api") &&
			//				ctx.Response.StatusCode == (int)HttpStatusCode.OK)
			//			{
			//				ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
			//			}
			//			else
			//			{
			//				ctx.Response.Redirect(ctx.RedirectUri);
			//			}

			//			return Task.FromResult(0);
			//		}
			//	};
			//})
			//.AddEntityFrameworkStores<GroceryAppContext>();

			services.AddEntityFramework()
				.AddSqlServer()
				.AddDbContext<GroceryContext>();

			services.AddTransient<GroceryContextSeedData>();
			services.AddScoped<IGroceryRepository, GroceryRepository>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, 
			GroceryContextSeedData seedData,
			IHostingEnvironment env,
			ILoggerFactory loggerFactory)
		{
			// look at adding the Hosting environment once switching to PROD
			if (env.IsDevelopment())
			{
				loggerFactory.AddDebug(LogLevel.Information);
				app.UseDeveloperExceptionPage();
			}
			else
			{
				loggerFactory.AddDebug(LogLevel.Error);
				app.UseExceptionHandler("/App/Error");
			}


			app.UseStaticFiles();

			app.UseMvc(config =>
			{
				config.MapRoute(
					name: "Default",
					template: "{controller}/{action}/{id?}",
					defaults: new { controller = "App", action = "Index" }
					);
			});

			seedData.EnsureSeedData();
		}

		// Entry point for the application.
		public static void Main(string[] args) => WebApplication.Run<Startup>(args);
	}
}
