using Payka.Domain.Models.Wallets;

namespace Payka.Application.Contracts.Services;
public interface IWalletService
{
	Task<Wallet> GetWalletByIdAsync(Guid id);
	Task<bool> CheckWalletAlreadyContainsInGroupAsync(Guid id);
}