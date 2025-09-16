using HotChocolate;
using HotChocolate.Language;
using HotChocolate.Types;
using MediatR;
using Payka.Application.UseCases.CreateUsers;

namespace Payka.API.GraphQL.Users;


[ExtendObjectType(OperationType.Mutation)]
public class UserMutations
{
	public async Task<bool> CreateEmptyUser([Service] IMediator mediator)
	{
		await mediator.Send(new CreateUserCommand(Guid.NewGuid()));
		return false;
	}
}