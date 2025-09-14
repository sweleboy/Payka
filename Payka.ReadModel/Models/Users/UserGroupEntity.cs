using Payka.ReadModel.Models.Base;

namespace Payka.ReadModel.Models.Users;

public class UserGroupEntity : ReadModelBase
{
	public string Name { get; set; } = string.Empty;

	public UserEntity Owner { get; set; } = null!;

	public List<UserGroupMemberEntity> Members { get; set; } = new();

	public List<GroupWalletEntity> GroupWallets { get; set; } = new();

	public GroupSpendingPolicyEntity? SpendingPolicy { get; set; }
}