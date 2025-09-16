namespace Payka.Application.UnitOfWork.Base;

public interface IUnitOfWork : IAsyncDisposable, IDisposable
{
	void Commit();
	Task CommitAsync(CancellationToken cancellationToken);
}