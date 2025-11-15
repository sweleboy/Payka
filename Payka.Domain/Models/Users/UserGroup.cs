using Payka.Domain.Models.Base;
using Payka.Domain.Models.Users.Rules;
using Payka.Domain.Models.Wallets;
using Payka.Domain.Models.Wallets.Rules;

namespace Payka.Domain.Models.Users;

public class UserGroup : DomainModelBase
{
	public string Name
	{
		get;
		private set;
	} = string.Empty;

	public User Owner
	{
		get;
		private set;
	}

	private readonly List<User> _members = new();
	public IReadOnlyCollection<User> Members => _members;

	private readonly List<Wallet> _wallets = new();
	public IReadOnlyCollection<Wallet> Wallets => _wallets;

	private UserGroup() { }

	private UserGroup(Guid id, string name, User owner)
	{
		Id = id;
		Name = name;
		Owner = owner;
	}

	public static UserGroup Create(Guid id, string name, User owner)
	{
		return new UserGroup(id, name, owner);
	}

	public void ChangeName(string name)
	{
		Name = name;
	}
	public void AddMember(User member)
	{
		CheckRule(new CheckUserIsNotContainsInMembersRule(_members, member));
		_members.Add(member);
	}
	public void RemoveMemberById(Guid memberId)
	{
		CheckRule(new CheckUserIsContainsInMembersRule(_members, memberId));
		_members.RemoveAll(x => x.Id == memberId);
	}
	public void AddWallet(Wallet wallet)
	{
		CheckRule(new CheckWalletIsNotContainsInGroupWalletsRule(_wallets, wallet));
		wallet.MarkAsGrouped();
		_wallets.Add(wallet);
	}
}