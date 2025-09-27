using HotChocolate;
using HotChocolate.Language;
using HotChocolate.Types;
using MediatR;
using Payka.Application.Exceptions;
using Payka.Application.UseCases.CreateUsers;

namespace Payka.API.GraphQL.Users;

[ExtendObjectType(OperationType.Mutation)]
public class UserMutations
{
	[UseMutationConvention(PayloadFieldName = "isSuccess")]
	[Error<ExceptionWithMessage>]
	public async Task<bool> CreateUserAsync(string fullName,
		string userName,
		string password,
		[Service] IMediator mediator)
	{
		await mediator.Send(new CreateUserCommand(fullName, userName, password));
		return true;
	}
}