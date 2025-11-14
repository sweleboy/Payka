using Payka.Domain.Models.Wallets;

namespace Payka.Domain.Models.Common;

public class GroupWallet
{
	public Guid Id { get; set; }
	public Wallet Wallet { get; set; } = null!;

	public static GroupWallet Create(Guid id, Wallet wallet)
	{
		return new GroupWallet()
		{
			Id = id,
			Wallet = wallet
		};
	}
}