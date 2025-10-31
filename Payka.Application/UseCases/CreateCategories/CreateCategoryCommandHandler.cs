using Payka.Application.Contracts.CQRS;
using Payka.Application.Contracts.Services;
using Payka.Dal;
using Payka.Domain.Models;

namespace Payka.Application.UseCases.CreateCategories;

public class CreateCategoryCommandHandler(WriteDbContext dbContext,
	IUserService userService)
	: ICommandHandler<CreateCategoryCommand>
{
	public async Task Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
	{
		var id = Guid.NewGuid();
		var owner = await userService.GetUserByIdAsync(command.OwnerId);
		var category = Category.Create(id, command.Name, owner);

		await dbContext.Categories.AddAsync(category);
	}
}