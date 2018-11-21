using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TestWebClient.Models
{
	public class ApplicationContext : IdentityDbContext<User>
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{

		}
	}
}
