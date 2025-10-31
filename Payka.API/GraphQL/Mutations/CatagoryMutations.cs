using HotChocolate;
using HotChocolate.Language;
using HotChocolate.Types;
using MediatR;
using Payka.Application.Exceptions;
using Payka.Application.UseCases.CreateCategories;

namespace Payka.API.GraphQL.Mutations;

[ExtendObjectType(OperationType.Mutation)]
public class CatagoryMutations
{
	[UseMutationConvention(PayloadFieldName = "isSuccess")]
	[Error<ExceptionWithMessage>]
	public async Task<bool> CreateCategoryAsync(string name,
		Guid ownerId,
		[Service] IMediator mediator)
	{
		await mediator.Send(new CreateCategoryCommand(name, ownerId));
		return true;
	}
}