namespace Payka.ReadModel.Models.Base;

public abstract class ReadModelBase
{
	public Guid Id
	{
		get;
		set;
	}

	public DateTime CreateDat
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
