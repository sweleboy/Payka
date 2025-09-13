using Payka.ReadModel.Models.Base;

namespace Payka.ReadModel.Models.Users;

public class UserEntity : ReadModelBase
{
	/// <summary>
	/// Представляет ник-нейм пользователя (логин).
	/// </summary>
	public string UserName
	{
		get;
		set;
	} = string.Empty;

	/// <summary>
	/// Представляет полное имя пользователя (ФИО).
	/// </summary>
	public string FullName
	{
		get;
		set;
	} = string.Empty;
}