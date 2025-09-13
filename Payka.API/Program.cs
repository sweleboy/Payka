using FluentMigrator.Runner;
using Payka.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

builder.ConfigureKestrel();

//services.AddGraphQlAuthorization(builder.Configuration);
services.AddControllers();
var connectionString = GetFormattedConnectionString();
services.AddPaykaServices(connectionString);
services.AddFluentMigrator(connectionString);
services.AddGraphQL();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGraphQL();
MigrateDb();

app.Run();
string GetFormattedConnectionString() =>
	builder.Configuration.GetConnectionString("PaykaDb") ?? string.Empty;

void MigrateDb()
{
	using (var scope = app.Services.CreateScope())
	{
		var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
		runner.MigrateUp();
	}
}