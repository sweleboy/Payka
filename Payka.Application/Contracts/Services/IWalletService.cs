using Payka.Domain.Models;

namespace Payka.Application.Contracts.Services;
public interface IWalletService
{
	Task<Wallet> GetWalletByIdAsync(Guid id);
}