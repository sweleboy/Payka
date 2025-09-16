using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Payka.API.Extensions
{
	public static class GraphqlExtensions
	{
		public static IServiceCollection AddGraphQL(this IServiceCollection services)
		{
			services.AddGraphQLServer()
					.AddAuthorization()
					.AddQueryType()
					.AddMutationType()
					.AddAPITypes()
					.AddMutationConventions()	
					.AddFiltering()
					.AddProjections()
					.AddPagingArguments()
					.ModifyPagingOptions(opt =>
					{
						opt.DefaultPageSize = 10;
						opt.IncludeTotalCount = true;
						opt.InferCollectionSegmentNameFromField = true;
					})
					.ModifyCostOptions(opt =>
					{
						opt.ApplyCostDefaults = false;
						opt.EnforceCostLimits = true;
					})
					.ModifyRequestOptions(opt =>
					{
						opt.IncludeExceptionDetails = true;
					})
					.AddSorting();

			return services;
		}
		public static IServiceCollection AddGraphQlAuthorization(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
					.AddJwtBearer(options =>
					{
						options.TokenValidationParameters = new TokenValidationParameters
						{
							ValidateIssuer = true,
							ValidateAudience = true,
							ValidateLifetime = true,
							ValidateIssuerSigningKey = true,
							ValidIssuer = configuration["Jwt:Issuer"],
							ValidAudience = configuration["Jwt:Audience"],
							IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
						};
					});

			services.AddAuthorization();
			return services;
		}
	}
}
