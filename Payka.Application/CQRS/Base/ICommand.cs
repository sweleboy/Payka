using MediatR;

namespace Payka.Application.CQRS.Base;

public interface ICommand : IRequest, IBaseRequest;
public interface ICommand<out TResult> : IRequest<TResult>, IBaseRequest;