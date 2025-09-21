namespace Payka.Application.Contracts.Services;

public interface IAuthorizationService
{
	Task<string?> LoginAsync(string login, string password);
}