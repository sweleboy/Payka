using Microsoft.EntityFrameworkCore;

namespace Payka.Dal
{
	public class WriteDbContext : DbContext
	{
		public WriteDbContext(DbContextOptions<WriteDbContext> options)
			: base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(WriteDbContext).Assembly);
		}
	}
}
