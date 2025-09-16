using Payka.Application.UnitOfWork.Base;
using Payka.Dal;

namespace Payka.Application.UnitOfWork;

public class UnitOfWork(WriteDbContext writeDbContext) : IUnitOfWork	
{
	public void Commit()
	{
		using var transaction = writeDbContext.Database.BeginTransaction();
		try
		{
			writeDbContext.SaveChanges();
			transaction.Commit();
		}
		catch
		{
			transaction.Rollback();
			throw;
		}
	}

	public async Task CommitAsync(CancellationToken cancellationToken)
	{
		await using var tx = await writeDbContext.Database.BeginTransactionAsync(cancellationToken);
		try
		{
			await writeDbContext.SaveChangesAsync(cancellationToken);
			await tx.CommitAsync(cancellationToken);
		}
		catch
		{
			await tx.RollbackAsync(cancellationToken);
			throw;
		}
	}

	public void Dispose()
	{
		writeDbContext.Dispose();
	}

	public async ValueTask DisposeAsync()
	{
		await writeDbContext.DisposeAsync();
	}
}