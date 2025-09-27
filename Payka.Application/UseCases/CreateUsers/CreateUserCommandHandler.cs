using Payka.Application.Contracts.CQRS;
using Payka.Application.Contracts.Services;
using Payka.Dal;
using Payka.Domain.Models.Users;
using Payka.ReadModel.Models.Users;

namespace Payka.Application.UseCases.CreateUsers;

public class CreateUserCommandHandler(WriteDbContext dbContext,
	IUserService userService,
	ICryptoService cryptoService)
	: ICommandHandler<CreateUserCommand>
{
	public async Task Handle(CreateUserCommand command, CancellationToken cancellationToken)
	{
		await userService.CheckUserNameUnique(command.UserName);
		var user = User.Create(
			Guid.NewGuid(),
			command.UserName,
			command.FullName
		);

		await dbContext.Users.AddAsync(user);
		await RegisterUserAsync(user, command.Password);
	}

	private async Task RegisterUserAsync(User user, string password)
	{
		string hashedPassword = cryptoService.HashText(password);
		var userCredentials = new UserCredentials(user.Id, user.UserName, hashedPassword);
		await dbContext.Set<UserCredentials>().AddAsync(userCredentials);
	}
}