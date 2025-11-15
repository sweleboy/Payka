using Payka.Application.Contracts.CQRS;
using Payka.Application.Contracts.Services;
using Payka.Dal;

namespace Payka.Application.UseCases.AddUserInUserGroup;
public class AddUserInUserGroupCommandHandler(IUserService userService,
	IUserGroupService userGroupService,
	WriteDbContext dbContext) : ICommandHandler<AddUserInUserGroupCommand>
{
	public async Task Handle(AddUserInUserGroupCommand command, CancellationToken cancellationToken)
	{
		var user = await userService.GetUserByIdAsync(command.MemberId);
		var userGroup = await userGroupService.GetUserGroupByIdAsync(command.UserGroupId);

		userGroup.AddMember(user);
	}
}