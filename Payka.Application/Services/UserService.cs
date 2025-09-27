using Microsoft.EntityFrameworkCore;
using Payka.Application.Contracts.Services;
using Payka.Application.Exceptions;
using Payka.Dal;
using Payka.Domain.Models.Users;

namespace Payka.Application.Services;

public class UserService(WriteDbContext dbContext) : IUserService
{
	public async Task<bool> CheckUserNameUnique(string userName)
	{
		var isUserNameAlreadyExist = await dbContext.Users.AnyAsync(x => x.UserName == userName);
		if (isUserNameAlreadyExist == true)
		{
			throw new ExceptionWithMessage("Имя пользователя уже занято.");
		}

		return true;
	}

	public async Task<User?> GetUserByUserNameAsync(string userName)
	{
		return await dbContext.Users.FirstOrDefaultAsync(x => x.UserName == userName);
	}
}