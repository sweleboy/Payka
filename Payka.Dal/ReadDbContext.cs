using Microsoft.EntityFrameworkCore;
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
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReadDbContext).Assembly);
	}
}