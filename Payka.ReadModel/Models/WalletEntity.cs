using Payka.ReadModel.Models.Base;
using Payka.ReadModel.Models.Users;

namespace Payka.ReadModel.Models;

public class WalletEntity : ReadModelBase
{
	public string Name { get; set; } = string.Empty;
	public MoneyEntity Balance { get; set; } = null!;
	public UserEntity Owner { get; set; } = null!;
	public string? Notes { get; set; }
	public bool IsGroupWallet { get; set; }
}