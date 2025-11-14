using Payka.Application.Contracts.CQRS;
using Payka.Application.Contracts.Services;
using Payka.Dal;
using Payka.Domain.Models;
using Payka.Domain.Models.Wallets;

namespace Payka.Application.UseCases.CreateWallets;

public class CreateWalletCommandHandler(WriteDbContext dbContext,
	IUserService userService,
	ICurrencyService currencyService)
	: ICommandHandler<CreateWalletCommand>
{
	public async Task Handle(CreateWalletCommand command, CancellationToken cancellationToken)
	{
		var owner = await userService.GetUserByIdAsync(command.OwnerId);
		var curency = await currencyService.GetCurrencyByIdAsync(command.CurrencyId);

		var wallet = Wallet.Create(
			Guid.NewGuid(),
			command.Name,
			Money.Create(0, curency),
			owner,
			command.Note
		);
		await dbContext.Wallets.AddAsync(wallet);
	}
}