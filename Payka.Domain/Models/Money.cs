namespace Payka.Domain.Models;

public class Money
{
	public decimal Amount { get; private set; }
	public Currency Currency { get; private set; }

	private Money() { }

	private Money(decimal amount, Currency currency)
	{
		Amount = amount;
		Currency = currency;
	}

	public static Money Create(decimal amount, Currency currency)
	{
		return new Money(amount, currency);
	}

	public void ChangeCurency(Currency newCurency)
	{
		var amountAtRubles = Amount * Currency.RublesValue;
		Amount = amountAtRubles / newCurency.RublesValue;
		Currency = newCurency;
	}
}