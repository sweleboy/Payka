using Payka.Application.Contracts.CQRS;

namespace Payka.Application.UseCases.CreateUsers;

public record CreateUserCommand(Guid Id) : ICommand;