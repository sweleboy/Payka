using Microsoft.EntityFrameworkCore;
using Payka.Application.Contracts.Services;
using Payka.Application.Exceptions;
using Payka.Dal;
using Payka.Domain.Models.Wallets;

namespace Payka.Application.Services;
public class WalletService(WriteDbContext dbContext) : IWalletService
{
	public async Task<Wallet> GetWalletByIdAsync(Guid id)
	{
		var wallet = await dbContext.Wallets.FindAsync(id);
		if (wallet == null)
		{
			throw new ExceptionWithMessage($"Кошелёк с идентификатором: \"{id}\" не найдена или была null.");
		}

		return wallet;
	}


	public async Task<bool> CheckWalletAlreadyContainsInGroupAsync(Guid id)
	{
		var isWalletAlreadyContainsInGroup = await dbContext.GroupWallets.AnyAsync(x => x.Wallet.Id == id);
		if (isWalletAlreadyContainsInGroup == true)
		{
			throw new ExceptionWithMessage("Кошелёк уже содержиться в другой группе.");
		}

		return true;
	}
}