using Payka.ReadModel.Models.Base;

namespace Payka.ReadModel.Models.Users;

public class UserGroupMemberEntity : ReadModelBase
{
	public Guid Id { get; set; }
	public UserEntity User { get; set; } = null!;
	public UserGroupRole Role { get; set; }
}