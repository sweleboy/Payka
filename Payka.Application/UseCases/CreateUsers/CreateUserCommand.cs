using Payka.Application.CQRS.Base;

namespace Payka.Application.UseCases.CreateUsers;

public record CreateUserCommand(Guid Id) : ICommand;