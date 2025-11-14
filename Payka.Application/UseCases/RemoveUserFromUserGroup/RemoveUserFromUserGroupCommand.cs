using Payka.Application.Contracts.CQRS;

namespace Payka.Application.UseCases.RemoveUserFromUserGroup;
public record RemoveUserFromUserGroupCommand(Guid UserGroupId, Guid MemberId) : ICommand;