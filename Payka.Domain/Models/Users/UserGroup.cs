using Payka.Domain.Models.Base;
using Payka.Domain.Models.Common;
using Payka.Domain.Models.Politics;

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

	private readonly List<UserGroupMember> _members = new();
	public IReadOnlyCollection<UserGroupMember> Members => _members;

	private readonly List<GroupWallet> _groupWallets = new();
	public IReadOnlyCollection<GroupWallet> GroupWallets => _groupWallets;

	public GroupSpendingPolicy? SpendingPolicy { get; private set; }

	private UserGroup() { }

	private UserGroup(Guid id, string name, User owner, GroupSpendingPolicy? policy)
	{
		Id = id;
		Name = name;
		Owner = owner;
		SpendingPolicy = policy;
	}

	public static UserGroup Create(Guid id, string name, User owner, GroupSpendingPolicy? policy = null)
	{
		return new UserGroup(id, name, owner, policy);
	}

	public void ChangeName(string name)
	{
		Name = name;
	}
}