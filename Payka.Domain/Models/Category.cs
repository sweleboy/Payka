using Payka.Domain.Models.Base;
using Payka.Domain.Models.Users;

namespace Payka.Domain.Models;

public class Category : DomainModelBase
{
	public string Name { get; private set; } = string.Empty;
	public User Owner { get; private set; }

	private Category() { }

	private Category(Guid id, string name, User owner)
	{
		Id = id;
		Name = name;
		Owner = owner;
	}

	public static Category Create(Guid id, string name, User owner)
	{
		return new Category(id, name, owner);
	}
}