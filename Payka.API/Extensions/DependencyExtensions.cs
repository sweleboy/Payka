using FluentMigrator.Runner;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Payka.Application.Contracts.Services;
using Payka.Application.Contracts.UnitOfWork;
using Payka.Application.Services;
using Payka.Application.UnitOfWork;
using Payka.Application.UseCases.CreateUsers;
using Payka.Dal;
using Payka.Dal.Migrations;

namespace Payka.API.Extensions;

public static class DependencyExtensions
{
	public static IServiceCollection AddPaykaServices(this IServiceCollection services, string connectionString)
	{
		services.AddScoped<IUnitOfWork, UnitOfWork>();
		services.AddScoped<IAuthorizationService, AuthorizationService>();

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