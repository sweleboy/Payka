using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Payka.Dal;
using Payka.Dal.Migrations;

namespace Payka.API.Extensions;

public static class DependencyExtensions
{
	public static IServiceCollection AddPaykaServices(this IServiceCollection services, string connectionString)
	{
		services.AddDbContext<WriteDbContext>(options =>
			options.UseNpgsql(connectionString), ServiceLifetime.Transient);
		services.AddDbContext<ReadDbContext>(options =>
			options.UseNpgsql(connectionString), ServiceLifetime.Transient);

		return services;
	}

	public static IServiceCollection AddFluentMigrator(this IServiceCollection services, string connectionString)
	{
		services
			.AddFluentMigratorCore()
			.ConfigureRunner(rb => rb
				.AddPostgres()
				.WithGlobalConnectionString(connectionString)
				.ScanIn(typeof(M001_CreateUserTableMigration).Assembly).For.Migrations())
			.AddLogging()
			.BuildServiceProvider(false);

		return services;
	}
}