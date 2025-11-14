using HotChocolate;
using HotChocolate.Language;
using HotChocolate.Types;
using MediatR;
using Payka.Application.Exceptions;
using Payka.Application.UseCases.CreateWallets;

namespace Payka.API.GraphQL.Mutations;

[ExtendObjectType(OperationType.Mutation)]
public class WalletMutations
{
	[UseMutationConvention(PayloadFieldName = "isSuccess")]
	[Error<ExceptionWithMessage>]
	public async Task<bool> CreateWalletAsync(string name,
		Guid ownerId,
		string notes,
		Guid currencyId,
		[Service] IMediator mediator)
	{
		await mediator.Send(new CreateWalletCommand(name, ownerId, notes, currencyId));
		return true;
	}
}