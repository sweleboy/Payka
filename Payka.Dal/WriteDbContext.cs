using Microsoft.EntityFrameworkCore;
using Payka.Dal.Write.Configurations;
using Payka.Domain.Models;
using Payka.Domain.Models.Users;
using Payka.Domain.Models.Wallets;

namespace Payka.Dal;

public class WriteDbContext : DbContext
{
	public DbSet<UserGroup> Groups { get; set; }
	public DbSet<User> Users { get; set; }
	public DbSet<Currency> Currencies { get; set; }
	public DbSet<Wallet> Wallets { get; set; }
	public DbSet<Category> Categories { get; set; }
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