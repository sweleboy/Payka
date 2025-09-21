using MediatR;

namespace Payka.Application.Contracts.CQRS;

public interface ICommand : IRequest, IBaseRequest;
public interface ICommand<out TResult> : IRequest<TResult>, IBaseRequest;