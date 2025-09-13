using Payka.Domain.Models.Base;

namespace Payka.Domain.Models;

public class Currency : DomainModelBase
{
	public string Code { get; private set; } = string.Empty;
	public string? Symbol { get; private set; }
	public decimal RublesValue { get; private set; }

	private Currency() { }

	private Currency(Guid id, string code, string? symbol, decimal rublesValue)
	{
		Id = id;
		Code = code;
		Symbol = symbol;
		RublesValue = rublesValue;
	}

	public static Currency Create(Guid id, string code, string? symbol, decimal rublesValue)
	{
		return new Currency(id, code, symbol, rublesValue);
	}
}