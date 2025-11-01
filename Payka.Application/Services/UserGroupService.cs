using Payka.Application.Contracts.Services;
using Payka.Application.Exceptions;
using Payka.Dal;
using Payka.Domain.Models.Users;

namespace Payka.Application.Services;
public class UserGroupService(WriteDbContext dbContext) : IUserGroupService
{
	public async Task<UserGroup> GetUserGroupByIdAsync(Guid id)
	{
		var userGroup = await dbContext.Groups.FindAsync(id);
		if (userGroup == null)
		{
			throw new ExceptionWithMessage($"Группа пользователей с идентификатором: \"{id}\" не найдена или была null.");
		}

		return userGroup;
	}
}
