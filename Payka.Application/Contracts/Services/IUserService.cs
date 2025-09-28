using Payka.Domain.Models.Users;

namespace Payka.Application.Contracts.Services;

public interface IUserService
{
	Task<User?> GetUserByUserNameAsync(string userName);
	Task<bool> CheckUserNameUnique(string userName);
	Task<User> GetUserByIdAsync(Guid id);
}