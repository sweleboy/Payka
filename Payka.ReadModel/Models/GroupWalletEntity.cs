namespace Payka.ReadModel.Models;

public class GroupWalletEntity
{
	public Guid Id { get; set; }
	public WalletEntity Wallet { get; set; } = null!;
}