using Payka.Application.Contracts.CQRS;

namespace Payka.Application.UseCases.CreateUserGroup;
public record CreateUserGroupCommand(Guid OwnerId, Guid WalletId, string Name) : ICommand;