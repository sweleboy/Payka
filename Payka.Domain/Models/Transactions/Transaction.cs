using Payka.Domain.Models.Base;
using Payka.Domain.Models.Users;

namespace Payka.Domain.Models.Transactions;

public class Transaction : DomainModelBase
{
	public Money Amount { get; private set; }
	public TransactionType Type { get; private set; }
	public Wallet Wallet { get; private set; }
	public User Initiator { get; private set; }
	public Category Category { get; private set; }
	public string? Description { get; private set; }
	public DateTimeOffset OccurredDate { get; private set; }

	private Transaction() { }

	private Transaction(Guid id,
		Money amount,
		TransactionType type,
		Wallet wallet,
		User initiator,
		Category category,
		DateTimeOffset occurredDate,
		string? description)
	{
		Id = id;
		Amount = amount;
		Type = type;
		Wallet = wallet;
		Initiator = initiator;
		Category = category;
		OccurredDate = occurredDate;
		Description = description;
	}

	public static Transaction Create(Guid id,
		Money amount,
		TransactionType type,
		Wallet wallet,
		User initiator,
		Category category,
		DateTimeOffset occurredDate,
		string? description = null)
	{
		return new Transaction(id, amount, type, wallet, initiator, category, occurredDate, description);
	}
}