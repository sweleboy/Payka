namespace Payka.ReadModel.Models.Users;

public class UserCredentional
{
	public Guid UserId { get; set; }
	public string UserName { get; set; }
	public string Password { get; set; }

	public UserCredentional() { }

	public UserCredentional(Guid userId, string userName, string password)
	{
		UserId = userId;
		UserName = userName;
		Password = password;
	}
}