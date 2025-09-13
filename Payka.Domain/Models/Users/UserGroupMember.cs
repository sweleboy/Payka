using Payka.Domain.Models.Base;
using Payka.Domain.Models.Users;

namespace Payka.Domain.Models;

public class UserGroupMember : DomainModelBase
{
	public User User { get; private set; }
	public UserGroupRole Role { get; private set; }

	private UserGroupMember() { }

	private UserGroupMember(Guid id, User user, UserGroupRole role)
	{
		Id = id;
		User = user;
		Role = role;
	}

	public static UserGroupMember Create(Guid id, User user, UserGroupRole role)
	{
		return new UserGroupMember(id, user, role);
	}
}