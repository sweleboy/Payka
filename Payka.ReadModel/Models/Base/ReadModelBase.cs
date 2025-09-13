namespace Payka.ReadModel.Models.Base;

public abstract class ReadModelBase
{
	public Guid Id
	{
		get;
		set;
	}

	public DateTime CreateDate
	{
		get;
		set;
	}

	public bool IsDeleted
	{
		get;
		set;
	}
}