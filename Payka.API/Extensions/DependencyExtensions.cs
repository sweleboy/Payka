using FluentMigrator.Runner;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Payka.Application.UnitOfWork;
using Payka.Application.UnitOfWork.Base;
using Payka.Application.UseCases.CreateUsers;
using Payka.Dal;
using Payka.Dal.Migrations;

namespace Payka.API.Extensions;

public static class DependencyExtensions
{
	public static IServiceCollection AddPaykaServices(this IServiceCollection services, string connectionString)
	{
		services.AddScoped<IUnitOfWork, UnitOfWork>();

		services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateUserCommandHandler>());

		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>));

		services.AddDbContext<WriteDbContext>(options =>
			options.UseNpgsql(connectionString), ServiceLifetime.Scoped);
		services.AddDbContext<ReadDbContext>(options =>
			options.UseNpgsql(connectionString), ServiceLifetime.Scoped);

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