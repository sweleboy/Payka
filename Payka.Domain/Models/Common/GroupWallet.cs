namespace Payka.Domain.Models.Common;

public class GroupWallet
{
	public Guid Id { get; set; }
	public Wallet Wallet { get; set; } = null!;
}