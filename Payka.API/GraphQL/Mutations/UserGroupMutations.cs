using HotChocolate;
using HotChocolate.Types;
using MediatR;
using Payka.Application.Exceptions;
using Payka.Application.UseCases.CreateUserGroup;

namespace Payka.API.GraphQL.Mutations;

[ExtendObjectType(OperationTypeNames.Mutation)]
public class UserGroupMutations
{
	[UseMutationConvention(PayloadFieldName = "isSuccess")]
	[Error<ExceptionWithMessage>]
	public async Task<bool> CreateUserGroupAsync([Service] IMediator mediator)
	{
		await mediator.Send(new CreateUserGroupCommand());
		return true;
	}
}