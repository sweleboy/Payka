using Payka.ReadModel.Models.Base;

namespace Payka.ReadModel.Models;

public class WalletEntity : ReadModelBase
{
	public Guid Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public MoneyEntity Balance { get; set; } = null!;
	public UserEntity Owner { get; set; } = null!;
	public string? Notes { get; set; }
}