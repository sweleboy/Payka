using Microsoft.EntityFrameworkCore;
using Payka.Dal.Read.Configurations;
using Payka.ReadModel.Models;
using Payka.ReadModel.Models.Users;

namespace Payka.Dal;

public class ReadDbContext : DbContext
{
	public DbSet<UserGroupEntity> GroupEntities { get; set; }
	public DbSet<CurrencyEntity> Currencies { get; set; }
	public ReadDbContext(DbContextOptions<ReadDbContext> options)
		: base(options)
	{ }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(
			assembly: typeof(UserEntityConfiguration).Assembly, 
			type => type.Namespace?.StartsWith(typeof(UserEntityConfiguration).Namespace!) == true
		);
	}
}