namespace Payka.ReadModel.Models.Users;

public class UserCredentials
{
	public Guid UserId { get; set; }
	public string UserName { get; set; }
	public string Password { get; set; }

	public UserCredentials() { }

	public UserCredentials(Guid userId, string userName, string password)
	{
		UserId = userId;
		UserName = userName;
		Password = password;
	}
}