using Microsoft.EntityFrameworkCore;
using Payka.Dal.Read.Configurations;
using Payka.Dal.Write.Configurations;
using Payka.Domain.Models.Users;

namespace Payka.Dal;

public class WriteDbContext : DbContext
{
	public DbSet<UserGroup> Groups { get; set; }
	public DbSet<User> Users { get; set; }
	public WriteDbContext(DbContextOptions<WriteDbContext> options)
		: base(options)
	{
	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(
			assembly: typeof(UserConfiguration).Assembly,
			type => type.Namespace?.StartsWith(typeof(UserConfiguration).Namespace!) == true
		);
	}
}