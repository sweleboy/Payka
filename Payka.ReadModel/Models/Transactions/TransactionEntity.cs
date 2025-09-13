using Payka.ReadModel.Models.Base;
using Payka.ReadModel.Models.Users;

namespace Payka.ReadModel.Models.Transactions;

public class TransactionEntity : ReadModelBase
{
	public Guid Id { get; set; }
	public MoneyEntity Amount { get; set; } = null!;
	public TransactionType Type { get; set; }
	public WalletEntity Wallet { get; set; } = null!;
	public UserEntity Initiator { get; set; } = null!;
	public CategoryEntity Category { get; set; } = null!;
	public string? Description { get; set; }
	public DateTimeOffset OccurredDate { get; set; }
}