using Microsoft.EntityFrameworkCore;
using Payka.Dal;

namespace Payka.API.Extensions
{
	public static class DependencyExtensions
	{
		public static IServiceCollection AddPaykaServices(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseNpgsql(connectionString), ServiceLifetime.Transient);

			return services;
		}
	}
}
