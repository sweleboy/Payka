using Payka.Application.Contracts.Services;
using Payka.Application.Exceptions;
using Payka.Dal;
using Payka.Domain.Models;

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
}