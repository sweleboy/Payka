using HotChocolate;
using HotChocolate.Types;
using MediatR;
using Payka.Application.Exceptions;
using Payka.Application.UseCases.AddUserInUserGroup;
using Payka.Application.UseCases.CreateUserGroup;

namespace Payka.API.GraphQL.Mutations;

[ExtendObjectType(OperationTypeNames.Mutation)]
public class UserGroupMutations
{
	[UseMutationConvention(PayloadFieldName = "isSuccess")]
	[Error<ExceptionWithMessage>]
	public async Task<bool> CreateUserGroupAsync(Guid ownerId, Guid walletId, string name,[Service] IMediator mediator)
	{
		await mediator.Send(new CreateUserGroupCommand(ownerId, walletId, name));
		return true;
	}

	[UseMutationConvention(PayloadFieldName = "isSuccess")]
	public async Task<bool> AddUserInUserGroupAsync(Guid userGroupId, Guid memberId,[Service] IMediator mediator)
	{
		await mediator.Send(new AddUserInUserGroupCommand(userGroupId, memberId));
		return true;
	}
}