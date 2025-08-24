using Payka.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

builder.ConfigureKestrel();

//services.AddGraphQlAuthorization(builder.Configuration);
services.AddControllers();
//var connectionString = GetFormattedConnectionString();
//services.AddPaykaServices(connectionString);
services.AddGraphQL();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGraphQL();

app.Run();
string GetFormattedConnectionString()
{
	string connectionString = builder.Configuration.GetConnectionString("CyberPlantDb") ?? string.Empty;
	return connectionString.Replace("SERVER_NAME", Environment.MachineName);
}