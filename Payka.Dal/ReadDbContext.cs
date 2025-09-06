using Microsoft.EntityFrameworkCore;

namespace Payka.Dal;
public class ReadDbContext : DbContext
{
	public ReadDbContext(DbContextOptions<ReadDbContext> options)
		: base(options)
	{
	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReadDbContext).Assembly);
	}
}