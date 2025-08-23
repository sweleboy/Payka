namespace Payka.API.Extensions;

public static class WebApplicationBuilderExtensions
{
	public static WebApplicationBuilder ConfigureKestrel(this WebApplicationBuilder builder)
	{
		builder.WebHost.ConfigureKestrel((context, options) =>
		{
			options.Configure(context.Configuration.GetSection("Kestrel"));
		});
		return builder;
	}
}
