using Payka.Application.Contracts.CQRS;

namespace Payka.Application.UseCases.CreateUserGroup;
public class CreateUserGroupCommandHandler : ICommandHandler<CreateUserGroupCommand>
{
	public Task Handle(CreateUserGroupCommand request, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}