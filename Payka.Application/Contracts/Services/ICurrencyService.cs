using Payka.Domain.Models;

namespace Payka.Application.Contracts.Services;

public interface ICurrencyService
{
	public Task<Currency> GetCurrencyByIdAsync(Guid id);
}