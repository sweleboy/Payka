using Payka.Domain.Models.Base;

namespace Payka.Domain.Models;

public class Category : DomainModelBase
{
	public string Name { get; private set; } = string.Empty;

	private Category() { }

	private Category(Guid id, string name)
	{
		Id = id;
		Name = name;
	}

	public static Category Create(Guid id, string name)
	{
		return new Category(id, name);
	}
}