using Payka.Application.Contracts.CQRS;

namespace Payka.Application.UseCases.CreateUsers;

public record CreateUserCommand(string FullName, string UserName, string Password) : ICommand;