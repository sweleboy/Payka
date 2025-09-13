using Payka.ReadModel.Models.Base;

namespace Payka.ReadModel.Models;

public class CategoryEntity : ReadModelBase
{
	public Guid Id { get; set; }
	public string Name { get; set; } = string.Empty;
}