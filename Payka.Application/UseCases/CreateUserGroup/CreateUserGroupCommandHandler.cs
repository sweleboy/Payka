using Payka.Application.Contracts.CQRS;
using Payka.Application.Contracts.Services;
using Payka.Dal;
using Payka.Domain.Models;
using Payka.Domain.Models.Common;
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

		await walletService.CheckWalletAlreadyContainsInGroupAsync(wallet.Id);

		var userGroupId = Guid.NewGuid();
		var userGroup = UserGroup.Create(userGroupId, command.Name, owner);

		var groupWalletId = Guid.NewGuid();
		var grroupWallet = GroupWallet.Create(groupWalletId, wallet);

		var ownerMember = UserGroupMember.Create(userGroupId, owner, UserGroupRole.Owner);
		userGroup.AddMember(ownerMember);
		userGroup.AddWallet(grroupWallet);

		await dbContext.AddAsync(userGroup);
	}
}