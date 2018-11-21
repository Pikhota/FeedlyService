using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace FeedlyServiceApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).UseKestrel(options => options.Limits.MinResponseDataRate = null).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
				WebHost.CreateDefaultBuilder(args)
			.UseKestrel()
			.UseIISIntegration()
			.UseStartup<Startup>();
	}

}
