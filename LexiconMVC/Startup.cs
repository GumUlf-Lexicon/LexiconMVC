using LexiconMVC.Data;
using LexiconMVC.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.AspNetCore.Http;
using JavaScriptEngineSwitcher.V8;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using React.AspNet;


namespace LexiconMVC
{
	public class Startup
	{

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{

			_ = services.AddDistributedMemoryCache();

			_ = services.AddSession(options =>
			  {
				  options.IdleTimeout = TimeSpan.FromMinutes(15);
				  options.Cookie.HttpOnly = true;
				  options.Cookie.IsEssential = true;
			  });

			_ = services.AddDbContext<LexiconDbContext>(options =>
				  options.UseSqlServer(Configuration.GetConnectionString("LexiconDbConnection"))
			);

			_ = services.AddIdentity<ApplicationUserModel, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
				.AddDefaultUI()
				.AddDefaultTokenProviders()
				.AddEntityFrameworkStores<LexiconDbContext>();

			_ = services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			_ = services.AddReact();

			_ = services.AddJsEngineSwitcher(options => options.DefaultEngineName = V8JsEngine.EngineName).AddV8();


			_ = services.AddControllersWithViews(o => o.Filters.Add(new AuthorizeFilter()));
			_ = services.AddRazorPages().AddMvcOptions(o => o.Filters.Add(new AuthorizeFilter()));

			_ = services.Configure<IdentityOptions>(options =>
			  {
				  options.User.AllowedUserNameCharacters =
							"abcdefghijklmnopqrstuvwxyzåäöüæøABCDEFGHIJKLMNOPQRSTUVWXYZåäöüæøß0123456789-._@+";
				  options.User.RequireUniqueEmail = true;
				  options.Password.RequiredLength = 12;


			  });

			_ = services.ConfigureApplicationCookie(options =>
			{
				options.AccessDeniedPath = "/Identity/Account/AccessDenied";
				options.Cookie.HttpOnly = true;
				options.Cookie.IsEssential = true;
				options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
				options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
				options.SlidingExpiration = true;

			});


		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if(env.IsDevelopment())
			{
				_ = app.UseDeveloperExceptionPage();
			}

			_ = app.UseReact(config =>	{});

			_ = app.UseStaticFiles();

			_ = app.UseRouting();

			_ = app.UseAuthentication();
			_ = app.UseAuthorization();

			_ = app.UseSession();

			_ = app.UseEndpoints(endpoints =>
			  {
				  _ = endpoints.MapControllerRoute(
					  name: "fevercheck",
					  pattern: "FeverCheck",
					  defaults: new { controller = "Doctor", action = "FeverCheck" }
				  );

				  _ = endpoints.MapControllerRoute(
					  name: "guessingGame",
					  pattern: "/GuessingGame",
					  defaults: new { controller = "Home", action = "GuessingGame" }
				  );

				  _ = endpoints.MapControllerRoute(
					  name: "default",
					  pattern: "{controller=Home}/{action=Index}/{id?}"
				  );

				  _ = endpoints.MapRazorPages();

			  });
		}
	}
}
