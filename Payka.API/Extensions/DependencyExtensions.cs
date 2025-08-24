namespace Payka.API.Extensions
{
	public static class DependencyExtensions
	{
		public static IServiceCollection AddPaykaServices(this IServiceCollection services, string connectionString)
		{
			//services.AddDbContext<ApplicationDbContext>(options =>
			//	options.UseSqlServer(connectionString), ServiceLifetime.Transient);
			//services.AddDbContext<InitializedDbContext>(options =>
			//	options.UseSqlServer(connectionString));

			return services;
		}
	}
}
