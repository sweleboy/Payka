namespace Payka.Application.Contracts.UnitOfWork;

public interface IUnitOfWork : IAsyncDisposable, IDisposable
{
	void Commit();
	Task CommitAsync(CancellationToken cancellationToken);
}