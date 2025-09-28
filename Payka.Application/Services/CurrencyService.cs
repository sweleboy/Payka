using Payka.Application.Contracts.Services;
using Payka.Application.Exceptions;
using Payka.Dal;
using Payka.Domain.Models;

namespace Payka.Application.Services;

public class CurrencyService(WriteDbContext dbContext) : ICurrencyService
{
	public async Task<Currency> GetCurrencyByIdAsync(Guid id)
	{
		var currency = await dbContext.Currencies.FindAsync(id);
		if (currency == null)
		{
			throw new ExceptionWithMessage($"Валюта с идентификатором: \"{id}\" не найдена или была null.");
		}

		return currency;
	}
}