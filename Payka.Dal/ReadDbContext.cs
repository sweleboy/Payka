using Microsoft.EntityFrameworkCore;
using Payka.Dal.Read.Configurations;
using Payka.ReadModel.Models.Users;

namespace Payka.Dal;

public class ReadDbContext : DbContext
{
	public DbSet<UserGroupEntity> GroupEntities { get; set; }
	public ReadDbContext(DbContextOptions<ReadDbContext> options)
		: base(options)
	{ }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		//modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReadDbContext).Assembly);
		modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
		modelBuilder.ApplyConfiguration(new CurrencyEntityConfiguration());
		modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
		modelBuilder.ApplyConfiguration(new WalletEntityConfiguration());
		modelBuilder.ApplyConfiguration(new TransactionEntityConfiguration());
		modelBuilder.ApplyConfiguration(new GroupSpendingPolicyEntityConfiguration());
		modelBuilder.ApplyConfiguration(new UserGroupEntityConfiguration());
		modelBuilder.ApplyConfiguration(new UserGroupMemberEntityConfiguration());
		modelBuilder.ApplyConfiguration(new GroupWalletEntityConfiguration());
		modelBuilder.ApplyConfiguration(new UserCredentionalConfiguration());
	}
}