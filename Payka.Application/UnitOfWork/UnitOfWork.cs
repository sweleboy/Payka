using Microsoft.EntityFrameworkCore.Storage;
using Payka.Application.Contracts.UnitOfWork;
using Payka.Dal;

namespace Payka.Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
	private readonly WriteDbContext _writeDbContext;

	private readonly IDbContextTransaction _transaction;

	public UnitOfWork(WriteDbContext writeDbContext)
	{
		_writeDbContext = writeDbContext;
		_transaction = _writeDbContext.Database.BeginTransaction();
	}

	public void Commit()
	{
		try
		{
			_writeDbContext.SaveChanges();
			_transaction.Commit();
		}
		catch
		{
			_transaction.Rollback();
		}
	}

	public async Task CommitAsync(CancellationToken cancellationToken)
	{
		try
		{
			await _writeDbContext.SaveChangesAsync(cancellationToken);
			await _transaction.CommitAsync(cancellationToken);
		}
		catch
		{
			await _transaction.RollbackAsync(cancellationToken);
		}
	}

	public void Dispose()
	{
		_transaction.Dispose();
	}

	public async ValueTask DisposeAsync()
	{
		await _transaction.DisposeAsync();
	}
}