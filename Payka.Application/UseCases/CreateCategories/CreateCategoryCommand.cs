using Payka.Application.Contracts.CQRS;

namespace Payka.Application.UseCases.CreateCategories;

public record CreateCategoryCommand(string Name, Guid OwnerId) : ICommand;