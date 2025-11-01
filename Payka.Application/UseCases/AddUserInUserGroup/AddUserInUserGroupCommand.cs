using Payka.Application.Contracts.CQRS;

namespace Payka.Application.UseCases.AddUserInUserGroup;
public record AddUserInUserGroupCommand(Guid UserGroupId, Guid MemberId) : ICommand;