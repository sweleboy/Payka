using Payka.Domain.Models.Base;
using Payka.Domain.Models.Users;
using Payka.Domain.Models.Wallets.Rules;

namespace Payka.Domain.Models.Wallets;

public class Wallet : DomainModelBase
{
	public string Name { get; private set; } = string.Empty;
	public Money Balance { get; private set; }
	public User Owner { get; private set; }
	public string? Notes { get; private set; }
	public bool IsGroupWallet { get; private set; }

	private Wallet() { }

	private Wallet(Guid id, string name, Money initialBalance, User owner, string? notes)
	{
		Id = id;
		Name = name;
		Balance = initialBalance;
		Owner = owner;
		Notes = notes;
	}

	public static Wallet Create(Guid id, string name, Money initialBalance, User owner, string? notes = null)
	{
		return new Wallet(id, name, initialBalance, owner, notes);
	}
	public void MarkAsGrouped()
	{
		CheckRule(new CheckWalletCanBeMarkedAsGroupedRulepublic(this));
		IsGroupWallet = true;
	}
}