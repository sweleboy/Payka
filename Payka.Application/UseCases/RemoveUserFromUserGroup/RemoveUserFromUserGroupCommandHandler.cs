using Payka.Application.Contracts.CQRS;
using Payka.Application.Contracts.Services;

namespace Payka.Application.UseCases.RemoveUserFromUserGroup;
public class RemoveUserFromUserGroupCommandHandler(IUserService userService,
	IUserGroupService userGroupService) : ICommandHandler<RemoveUserFromUserGroupCommand>
{
	public async Task Handle(RemoveUserFromUserGroupCommand command, CancellationToken cancellationToken)
	{
		var user = await userService.GetUserByIdAsync(command.MemberId);
		var userGroup = await userGroupService.GetUserGroupByUserAsync(user);

		userGroup.RemoveMemberById(user.Id);
	}
}