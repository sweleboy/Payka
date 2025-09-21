using MediatR;
using Payka.Application.Contracts.UnitOfWork;

namespace Payka.Application.UnitOfWork;

public sealed class UnitOfWorkBehavior<TRequest, TResponse>(IUnitOfWork unitOfWork)
	: IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest
{
	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
	{
		var response = await next();
		await unitOfWork.CommitAsync(ct);
		return response;
	}
}