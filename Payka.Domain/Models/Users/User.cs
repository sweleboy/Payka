using Payka.Domain.Models.Base;

namespace Payka.Domain.Models.Users
{
	/// <summary>
	/// Представляет модель пользователя.
	/// </summary>
	public class User : DomainModelBase
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

		private User(Guid id, string userName, string fullName)
		{
			Id = id;
			UserName = userName;
			FullName = fullName;
		}

		/// <summary>
		/// Создаёт пользователя.
		/// </summary>
		/// <param name="id">Идентификатор пользователя.</param>
		/// <param name="userName">Ник-нейм пользователя (логин).</param>
		/// <param name="fullName">полное имя пользователя (ФИО).</param>
		/// <returns>Пользователь.</returns>
		public static User Create(Guid id, string userName, string fullName)
		{
			return new User(
				id,
				userName,
				fullName
			);
		}
	}
}