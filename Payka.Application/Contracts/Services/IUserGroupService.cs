using Payka.Domain.Models.Users;

namespace Payka.Application.Contracts.Services;
public interface IUserGroupService
{
	Task<UserGroup> GetUserGroupByIdAsync(Guid id);
	Task<UserGroup> GetUserGroupByUserAsync(User user);
}