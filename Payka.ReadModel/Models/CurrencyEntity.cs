using Payka.ReadModel.Models.Base;

namespace Payka.ReadModel.Models;

public class CurrencyEntity : ReadModelBase
{
	public string Code { get; set; } = string.Empty;
	public string? Symbol { get; set; }
	public decimal RublesValue { get; set; }
}