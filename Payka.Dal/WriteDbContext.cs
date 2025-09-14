using Microsoft.EntityFrameworkCore;
using Payka.Dal.Write.Configurations;
using Payka.Domain.Models.Users;

namespace Payka.Dal;

public class WriteDbContext : DbContext
{
	public DbSet<UserGroup> Groups { get; set; }
	public WriteDbContext(DbContextOptions<WriteDbContext> options)
		: base(options)
	{
	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		//modelBuilder.ApplyConfigurationsFromAssembly(typeof(WriteDbContext).Assembly);
		modelBuilder.ApplyConfiguration(new UserConfiguration());
		modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
		modelBuilder.ApplyConfiguration(new GroupWalletConfiguration());
		modelBuilder.ApplyConfiguration(new CategoryConfiguration());
		modelBuilder.ApplyConfiguration(new WalletConfiguration());
		modelBuilder.ApplyConfiguration(new TransactionConfiguration());
		modelBuilder.ApplyConfiguration(new GroupSpendingPolicyConfiguration());
		modelBuilder.ApplyConfiguration(new UserGroupConfiguration());
		modelBuilder.ApplyConfiguration(new UserGroupMemberConfiguration());
	}
}