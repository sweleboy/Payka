namespace Payka.ReadModel.Models;

public class MoneyEntity
{
	public decimal Amount { get; set; }
	public CurrencyEntity Currency { get; set; } = null!;
}