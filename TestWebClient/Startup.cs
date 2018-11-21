using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO.Compression;
using TestWebClient.Models;

namespace TestWebClient
{
	public class Startup
	{
		private ILogger _log;
		public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
		{
			Configuration = configuration;
			_log = loggerFactory.CreateLogger("Logger");
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationContext>(options =>
								options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddIdentity<User, IdentityRole>()
					.AddEntityFrameworkStores<ApplicationContext>();

			services.Configure<CookiePolicyOptions>(options =>
			{
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

	

			services.AddResponseCompression();

			services.Configure<GzipCompressionProviderOptions>(options =>
			{
				options.Level = CompressionLevel.Optimal;
			});

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole();
			loggerFactory.AddDebug();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseResponseCompression();

			app.UseStaticFiles();
			app.UseAuthentication();
			app.UseHttpsRedirection();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
									name: "default",
									template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
