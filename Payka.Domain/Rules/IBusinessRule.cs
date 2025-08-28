namespace Payka.Domain.Rules
{
	public interface IBusinessRule
	{
		bool IsFailure();
		string Message { get; }
	}
}
