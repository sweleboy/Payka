using Payka.Application.Contracts.CQRS;
using Payka.Application.Contracts.Services;
using Payka.Dal;
using Payka.Domain.Models;
using Payka.Domain.Models.Users;

namespace Payka.Application.UseCases.CreateUserGroup;
public class CreateUserGroupCommandHandler(IUserService userService,
	IWalletService walletService,
	WriteDbContext dbContext) : ICommandHandler<CreateUserGroupCommand>
{
	public async Task Handle(CreateUserGroupCommand command, CancellationToken cancellationToken)
	{
		var owner = await userService.GetUserByIdAsync(command.OwnerId);
		var wallet = await walletService.GetWalletByIdAsync(command.WalletId);

		var id = Guid.NewGuid();
		var userGroup = UserGroup.Create(id, command.Name, owner);

		var ownerMember = UserGroupMember.Create(id, owner, UserGroupRole.Owner);
		userGroup.AddMember(ownerMember);

		await dbContext.AddAsync(userGroup);
	}
}