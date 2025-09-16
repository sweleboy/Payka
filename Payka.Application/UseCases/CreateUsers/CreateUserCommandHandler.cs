using Payka.Application.CQRS.Base;
using Payka.Dal;

namespace Payka.Application.UseCases.CreateUsers;

public class CreateUserCommandHandler(WriteDbContext dbContext)
	: ICommandHandler<CreateUserCommand>
{
	public Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}